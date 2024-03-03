using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST_Editor
{
    public class LSTEditorSystem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LSTEditorSystem()
        {
            Modules = new ObservableCollection<Module>();
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

        public ObservableCollection<Module> Modules { get; set; }

    }
}
