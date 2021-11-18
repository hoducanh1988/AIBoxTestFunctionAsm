using AIBoxTestFunctionAsm.Models;
using AIBoxTestFunctionAsm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIBoxTestFunctionAsm.Commands {
    public class RunConfirmHDMICommand : ICommand {

        private RunViewModel _rvm;
        RunModel rm = null;
        SettingModel sm = null;

        public RunConfirmHDMICommand(RunViewModel rvm) {
            _rvm = rvm;
            rm = _rvm.RN;
            sm = _rvm.SM;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //enable button save setting
        public bool CanExecute(object parameter) {
            return true;
        }

        //save setting
        public void Execute(object parameter) {
            rm.showIndex = 0;
        }

        #endregion
    }
}
