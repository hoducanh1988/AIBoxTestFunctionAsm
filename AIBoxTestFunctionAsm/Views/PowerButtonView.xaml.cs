using AIBoxTestFunctionAsm.Asset.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for PowerButtonView.xaml
    /// </summary>
    public partial class PowerButtonView : UserControl {
        public PowerButtonView() {
            InitializeComponent();
            this.DataContext = myGlobal.runviewmodel;

            Thread t = new Thread(new ThreadStart(() => {
            RE:
                Thread.Sleep(1000);
                if (myGlobal.runviewmodel.RN.buttonTimeout > 0) myGlobal.runviewmodel.RN.buttonTimeout -= 1;
                else myGlobal.runviewmodel.RN.showIndex = 0;
                if (myGlobal.runviewmodel.RN.showIndex != 0) goto RE;
            }));
            t.IsBackground = true;
            t.Start();
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            RadioButton rb = sender as RadioButton;
            switch (rb.Tag) {
                case "0": { myGlobal.runviewmodel.RN.buttonIdResult = 0; break; };
                case "1": { myGlobal.runviewmodel.RN.buttonIdResult = 1; break; };
            }
        }
    }
}
