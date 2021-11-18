using AIBoxTestFunctionAsm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIBoxTestFunctionAsm.Commands {
    public class RunInputBarcodeCommand : ICommand {

        private RunViewModel _rvm;
        public RunInputBarcodeCommand(RunViewModel rvm) {
            _rvm = rvm;
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
        }

        #endregion

    }
}
