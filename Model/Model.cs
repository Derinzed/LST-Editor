using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace LST_Editor
{
    public class Model
    {
        public Model()
        {
            lstData = new ObservableCollection<Page>();
            SearchResults = new ObservableCollection<SearchResult>();
            SearchData = new SearchProperties();
            selectedFiles = new List<string>();
        }
        public void OpenFile()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".lst"; // Default file extension
            dialog.Filter = "List Files (.lst)|*.lst"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                selectedFiles.Add(dialog.FileName); 
            }

            ParseLSTFile();
        }

        public void ParseLSTFile()
        {
            if (selectedFiles.Count() == 0)
            {
                return;
            }

            foreach (var FileToOpen in selectedFiles)
            {
                
                foreach(var sheet in lstData)
                {
                    if(sheet.FilePath == FileToOpen)
                    {
                        return;
                    }
                }
                
                FileStream fs = File.Open(FileToOpen, FileMode.Open, FileAccess.Read, FileShare.None);

                StreamReader file = new StreamReader(fs);

                Page page = new Page();

                string? line = file.ReadLine();

                while (line != null)
                {

                    if (line.Length > 0)
                    {
                        if (line.Substring(0, 1) != "#")
                        {

                            Item item = new Item();
                            string itemName = line.Split("\t")[0];
                            item.Name = itemName;

                            //Trace.WriteLine(itemName);
                            string[] element = line.Split("\t");
                            for (int i = 1; i != element.Length; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(element[i]))
                                {
                                    Trace.WriteLine(element[i]);
                                    Param param = new Param();
                                    param.Name = element[i].Split(":")[0];
                                    param.Data = element[i].Split(":")[1];

                                    item.Data.Add(param);
                                }

                            }
                            page.FilePath = FileToOpen;
                            page.Name = FileToOpen.Split("\\")[^1];
                            page.Items.Add(item);

                        }
                    }
                    line = file.ReadLine();
                    //Trace.WriteLine(line);
                }
                lstData.Add(page);
                fs.Close();
            }
            selectedFiles.Clear();
        }



        public string createFile()
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "LSTFile|*.lst";
            saveFileDialog1.Title = "Save a List File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
            {
                return "";
            }


            System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

            fs.Close();

            return saveFileDialog1.FileName;
        }

        public void writeFile(string fileName, Page page)
        {
            FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Write, FileShare.None);
            using (StreamWriter file = new StreamWriter(fs))
            {

                file.WriteLine("#This file was generated using the LST Editor created by WWJD.");
                file.WriteLine("#Editing this file manually will not cause issues as long as it is not currently opened by the LST Editor.");


                if (page.Items.Count > 0)
                {

                    string paramString = "";
                    foreach (var thing in page.Items)
                    {

                        //build the item string
                        foreach (var paramElement in thing.Data)
                        {
                            paramString = paramString + "\t" + paramElement.Name + ":" + paramElement.Data;
                        }

                        file.WriteLine(thing.Name + paramString);
                        paramString = "";
                    }

                }

                file.Close();
            }
            fs.Close();

        }

        public void Search(List<string> files, string criteria)
        {
            foreach(var item in files)
            {
                var line = File.ReadLines(item);
                foreach(var entry in line)
                {
                    if (entry.Contains(criteria))
                    {
                        SearchResult result = new SearchResult();
                        result.FileName = item;
                        result.Line = entry;
                        SearchResults.Add(result);
                    }
                }

            }
        }

        public void SearchOpened()
        {
            List<string> files = new List<string>();
            foreach (var file in lstData)
            {
                files.Add(file.FilePath);
            }

            Search(files, SearchData.SearchCriteria);
        }

        public void SearchDirectory()
        {
            List<string> files = new List<string>(); ;
            string[] allfiles = Directory.GetFiles(SearchData.GlobalDirectory, "*.lst", SearchOption.AllDirectories);
            foreach(var item in allfiles)
            {
                files.Add(item);
            }

            Search(files, SearchData.SearchCriteria);
        }

        public void clearSearch()
        {
            SearchResults.Clear();
        }

        public void getSearchFolder()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    SearchData.GlobalDirectory= fbd.SelectedPath;
                }
            }
        }


        public List<string> selectedFiles;
        public ObservableCollection<Page> lstData { get; set; }

        public SearchProperties SearchData { get; set; }
        public ObservableCollection<SearchResult> SearchResults { get; set; }
    }
}
