using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
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
using System.Xml.Linq;

namespace LST_Editor
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow(MainWindowVM vm)
        {
            InitializeComponent();
            this.vm = vm;
        }


        public void Search_Opened(object sender, RoutedEventArgs e)
        {
            vm.DataModel.SearchOpened();
        }

        public void Search_Path(object sender, RoutedEventArgs e)
        {
            vm.SearchPath();
        }

        public void Clear_Search(object sender, RoutedEventArgs e)
        {
            vm.ClearSearch();
        }

        MainWindowVM vm;

        private void Get_Directory(object sender, RoutedEventArgs e)
        {
            vm.GetDirectory();
        }

        private void Open_Search_Item(object sender, MouseButtonEventArgs e)
        {
            SearchResult value = dataGrid.SelectedValue as SearchResult;
            string? file = value.FileName;
            vm.OpenSearchItem(file);
        }

        void DataGrid_Unloaded(object sender, RoutedEventArgs e)
        {
            var grid = (DataGrid)sender;
            grid.CommitEdit(DataGridEditingUnit.Row, true);
        }
    }
}
