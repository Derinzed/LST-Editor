using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LST_Editor
{

    public class SearchResult : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }

            set
            {
                _fileName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FileName"));
            }

        }
        private string _line;
        public string Line
        {
            get { return _line; }

            set
            {
                _line = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Line"));
            }

        }

    }
   
    public class SearchProperties : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _globalDirectory;
        public string GlobalDirectory
        {
            get { return _globalDirectory; }

            set
            {
                _globalDirectory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GlobalDirectory"));
            }

        }

        private string _searchCriteria;
        public string SearchCriteria
        {
            get { return _searchCriteria; }

            set
            {
                _searchCriteria = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchCriteria"));
            }

        }

    }
}
