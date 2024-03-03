using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LST_Editor
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowVM()
        {
            DataModel = new Model();
        }

        public void Save(Page page)
        {
            DataModel.writeFile(page.FilePath, page);
        }

        public void SaveAs(Page page)
        {
            string file = DataModel.createFile();
            DataModel.writeFile(file, page);
        }

        public void OpenFile()
        {
            DataModel.OpenFile();
        }

        public void ClearSearch()
        {
            DataModel.clearSearch();
        }

        public void GetDirectory()
        {
            DataModel.getSearchFolder();
        }

        public void SearchPath()
        {
            DataModel.SearchDirectory();
        }

        public void OpenSearchItem(string file) 
        {
            foreach(var item in DataModel.lstData)
            {
                if (item.FilePath == file)
                {
                    CurrentPage = item;
                }
            }

            DataModel.selectedFiles.Add(file);
            DataModel.ParseLSTFile();
        }

        public Model DataModel { get; set; }
        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }

            set
            {
                _currentPage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentPage"));
            }

        }
        public Module CurrentModule { get; set; }
        public LSTEditorSystem CurrentLSTEditorSystem { get; set; }
    }
}
