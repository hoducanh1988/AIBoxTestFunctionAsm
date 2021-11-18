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
    /// Interaction logic for LogView.xaml
    /// </summary>
    public partial class LogView : UserControl {
        public LogView() {
            InitializeComponent();
            this.DataContext = myGlobal.runviewmodel;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += (s, e) => {
                var rm = myGlobal.runviewmodel.RN;
                if (rm.totalResult.Equals("Waiting...")) {
                    this.scr_dut.ScrollToEnd();
                    this.scr_system.ScrollToEnd();
                    this.scr_dhcp.ScrollToEnd();
                }
            };
            timer.Start();
        }
    }
}
