using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST_Editor
{
    public class Module : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Module()
        {
            Pages = new ObservableCollection<Page>();
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

        public ObservableCollection<Page> Pages { get; set; }

    }
}
