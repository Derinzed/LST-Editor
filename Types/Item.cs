using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST_Editor
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Item()
        {
            Data = new ObservableCollection<Param>();
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

        public ObservableCollection<Param> Data { get; set; }

    }
}
