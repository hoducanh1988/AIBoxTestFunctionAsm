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
    /// Interaction logic for HDMIView.xaml
    /// </summary>
    public partial class HDMIView : UserControl {
        public HDMIView() {
            InitializeComponent();
            this.DataContext = myGlobal.runviewmodel;

            Thread t = new Thread(new ThreadStart(() => {
            RE:
                Thread.Sleep(1000);
                if (myGlobal.runviewmodel.RN.hdmiTimeout > 0) myGlobal.runviewmodel.RN.hdmiTimeout -= 1;
                else myGlobal.runviewmodel.RN.showIndex = 0;
                if (myGlobal.runviewmodel.RN.showIndex != 0) goto RE;
            }));
            t.IsBackground = true;
            t.Start();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            RadioButton rb = sender as RadioButton;
            switch (rb.Tag) {
                case "0": { myGlobal.runviewmodel.RN.hdmiIdResult = 0; break; };
                case "1": { myGlobal.runviewmodel.RN.hdmiIdResult = 1; break; };
                case "2": { myGlobal.runviewmodel.RN.hdmiIdResult = 2; break; };
                case "3": { myGlobal.runviewmodel.RN.hdmiIdResult = 3; break; };
                case "4": { myGlobal.runviewmodel.RN.hdmiIdResult = 4; break; };
            }
        }
    }
}
