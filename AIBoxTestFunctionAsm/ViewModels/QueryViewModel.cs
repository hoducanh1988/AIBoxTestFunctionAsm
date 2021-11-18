using AIBoxTestFunctionAsm.Commands;
using AIBoxTestFunctionAsm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIBoxTestFunctionAsm.ViewModels {
    public class QueryViewModel {

        public QueryViewModel() {
            _lm = new QueryModel();
            GoCommand = new LogGoCommand(this);
        }

        QueryModel _lm;
        public QueryModel LM {
            get => _lm;
        }

        public ICommand GoCommand {
            get;
            private set;
        }
    }
}
