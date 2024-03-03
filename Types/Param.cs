using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST_Editor
{
    public class Param : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

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
        private string _data;
        public string Data
        {
            get { return _data; }

            set
            {
                _data = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Data"));
            }

        }
    }
}
