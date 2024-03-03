using LST_Editor;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LST_Editor
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            selectedFile = "";
            vm = new MainWindowVM();
            InitializeComponent();
            this.DataContext = vm;
            Pages.DataContext = vm;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Page page = (Page)Pages.SelectedValue;
            vm.Save(page);
        }

        private void Save_As(object sender, RoutedEventArgs e)
        {
            Page page = (Page)Pages.SelectedValue;
            vm.SaveAs(page);
        }

        public void Open_File_Click(object sender, RoutedEventArgs e)
        {

            vm.OpenFile();
        }

        public void Add_Item_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public void Open_Search_Window(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow(vm);
            searchWindow.Show();
            searchWindow.DataContext = vm.DataModel;
        }

        MainWindowVM vm;

        string selectedFile;



    }
}
