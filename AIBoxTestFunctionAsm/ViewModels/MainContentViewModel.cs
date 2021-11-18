using AIBoxTestFunctionAsm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBoxTestFunctionAsm.ViewModels {
    public class MainContentViewModel {

        public MainContentViewModel() {
            _mcm = new MainContentModel();
        }

        MainContentModel _mcm;
        public MainContentModel MCM {
            get => _mcm;
        }
    }
}
