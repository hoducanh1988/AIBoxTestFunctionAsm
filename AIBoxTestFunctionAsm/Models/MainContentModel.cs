using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBoxTestFunctionAsm.Models {

    public class MainContentModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public MainContentModel() {
            Init();
            isSmall = true;
        }

        public void Init() {
            isRun = isSetting = isQuery = isHelp = isAbout = false;
        }

        bool _is_run;
        public bool isRun {
            get { return _is_run; }
            set {
                _is_run = value;
                OnPropertyChanged(nameof(isRun));
            }
        }
        bool _is_setting;
        public bool isSetting {
            get { return _is_setting; }
            set {
                _is_setting = value;
                OnPropertyChanged(nameof(isSetting));
            }
        }
        bool _is_query;
        public bool isQuery {
            get { return _is_query; }
            set {
                _is_query = value;
                OnPropertyChanged(nameof(isQuery));
            }
        }
        bool _is_help;
        public bool isHelp {
            get { return _is_help; }
            set {
                _is_help = value;
                OnPropertyChanged(nameof(isHelp));
            }
        }
        bool _is_about;
        public bool isAbout {
            get { return _is_about; }
            set {
                _is_about = value;
                OnPropertyChanged(nameof(isAbout));
            }
        }
        bool _is_small;
        public bool isSmall {
            get { return _is_small; }
            set {
                _is_small = value;
                OnPropertyChanged(nameof(isSmall));
            }
        }
    }
}
