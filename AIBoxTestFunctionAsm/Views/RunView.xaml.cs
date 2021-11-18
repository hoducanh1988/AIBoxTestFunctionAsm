using AIBoxTestFunctionAsm.Asset.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AIBoxTestFunctionAsm.Views {
    /// <summary>
    /// Interaction logic for RunView.xaml
    /// </summary>
    public partial class RunView : UserControl {
        public RunView() {
            InitializeComponent();
            this.DataContext = myGlobal.runviewmodel;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            int old_value = -1;
            timer.Tick += (s, e) => {
                if (myGlobal.runviewmodel.RN.totalResult != "Waiting...") {
                    this.txtInput.Focus();
                }
                if (old_value == myGlobal.runviewmodel.RN.showIndex) return;
                old_value = myGlobal.runviewmodel.RN.showIndex;
                switch (myGlobal.runviewmodel.RN.showIndex) {
                    case 0: {
                            this.grid_log.Children.Clear();
                            this.grid_log.Children.Add(new LogView());
                            break;
                        }
                    case 1: {
                            this.grid_log.Children.Clear();
                            this.grid_log.Children.Add(new HDMIView());
                            break;
                        }
                    case 2: {
                            this.grid_log.Children.Clear();
                            this.grid_log.Children.Add(new PowerButtonView());
                            break;
                        }
                }
            };
            timer.Start();
        }
    }
}
