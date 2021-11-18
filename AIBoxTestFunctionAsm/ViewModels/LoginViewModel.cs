using AIBoxTestFunctionAsm.Commands;
using AIBoxTestFunctionAsm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIBoxTestFunctionAsm.ViewModels {
    public class LoginViewModel {

        public LoginViewModel() {
            _lm = new LoginModel();
            GoCommand = new LoginGoCommand(this);
        }

        LoginModel _lm;
        public LoginModel LM {
            get => _lm;
        }

        public ICommand GoCommand {
            get;
            private set;
        }

    }
}
