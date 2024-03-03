using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST_Editor
{
    public class Page : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Page()
        {
            Items = new ObservableCollection<Item>();
        }

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }

            set
            {
                _filePath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FilePath"));
            }

        }

        private string _name;
        public string Name
        {
            get { return _name; }

            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }

        }

        public ObservableCollection<Item> Items { get; set; }


        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }

            set
            {
                _selectedItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedItem"));
            }

        }
    }
}
