using AIBoxTestFunctionAsm.Asset.Global;
using AIBoxTestFunctionAsm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AIBoxTestFunctionAsm.Views {
    /// <summary>
    /// Interaction logic for MainContentView.xaml
    /// </summary>
    public partial class MainContentView : UserControl {
        MainContentViewModel mcvm = null;

        RunView ruv = new RunView();
        SettingView stv = new SettingView();
        QueryView qrv = new QueryView();
        HelpView hpv = new HelpView();
        LoginView liv = new LoginView();
        AboutView abv = new AboutView();
        public bool isBreak = false;

        public MainContentView() {
            InitializeComponent();
            mcvm = new MainContentViewModel();
            this.DataContext = mcvm;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e) {
            string control_tag = "";
            if (sender is Label) control_tag = (sender as Label).Tag.ToString();
            if (sender is Image) control_tag = (sender as Image).Tag.ToString();

            if (e.LeftButton == MouseButtonState.Pressed) {
                mcvm.MCM.Init();
                this.grid_content.Children.Clear();
                isBreak = true;
                myGlobal.runviewmodel.RN.isLogin = false;

                switch (control_tag) {
                    case "run": {
                            mcvm.MCM.isRun = true;
                            this.grid_content.Children.Add(ruv);
                            break;
                        }
                    case "setting": {
                            mcvm.MCM.isSetting = true;
                            isBreak = false;
                            liv.lvm.LM.Clear();
                            this.grid_content.Children.Add(liv);
                            Thread t = new Thread(new ThreadStart(() => {
                            RE:
                                Thread.Sleep(100);
                                if (myGlobal.runviewmodel.RN.isLogin == true) {
                                    App.Current.Dispatcher.Invoke(new Action(() => { this.grid_content.Children.Add(stv); }));
                                }
                                else {
                                    if (isBreak == false) goto RE;
                                }

                            }));
                            t.IsBackground = true;
                            t.Start();
                            break; 
                        }
                    case "log": {
                            mcvm.MCM.isQuery = true;
                            this.grid_content.Children.Add(qrv);
                            break;
                        }
                    case "help": {
                            mcvm.MCM.isHelp = true;
                            this.grid_content.Children.Add(hpv);
                            break;
                        }
                    case "about": {
                            mcvm.MCM.isAbout = true;
                            this.grid_content.Children.Add(abv);
                            break; 
                        }
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) {
            this.grid_main.ColumnDefinitions[0].Width = new GridLength(45, GridUnitType.Pixel);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e) {
            this.grid_main.ColumnDefinitions[0].Width = new GridLength(200, GridUnitType.Pixel);
        }

    }

}
