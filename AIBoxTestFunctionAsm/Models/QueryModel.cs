using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBoxTestFunctionAsm.Models {
    public class QueryModel : INotifyPropertyChanged {

        public QueryModel() {
             isSetting = isSoftware = isLog = false;
        }


        bool _is_setting;
        public bool isSetting {
            get { return _is_setting; }
            set {
                _is_setting = value;
                OnPropertyChanged(nameof(isSetting));
            }
        }
        bool _is_software;
        public bool isSoftware {
            get { return _is_software; }
            set {
                _is_software = value;
                OnPropertyChanged(nameof(isSoftware));
            }
        }
        bool _is_log;
        public bool isLog {
            get { return _is_log; }
            set {
                _is_log = value;
                OnPropertyChanged(nameof(isLog));
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
