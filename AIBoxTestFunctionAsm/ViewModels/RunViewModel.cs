using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AIBoxTestFunctionAsm.Asset.Global;
using AIBoxTestFunctionAsm.Commands;
using AIBoxTestFunctionAsm.Models;

namespace AIBoxTestFunctionAsm.ViewModels {
    public class RunViewModel {

        public RunViewModel() {
            _run = new RunModel();
            _sm = myGlobal.settingviewmodel.SM;
            InputCommand = new RunInputBarcodeCommand(this);
        }

        RunModel _run;
        public RunModel RN {
            get => _run;
        }
        SettingModel _sm;
        public SettingModel SM {
            get => _sm;
        }
        public ICommand InputCommand {
            get;
            private set;
        }

    }
}
