using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBoxTestFunctionAsm.Models {
    public class RunModel : INotifyPropertyChanged {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public RunModel() {
            Init_Value();
        }

        #region method

        public void Init_Value() {
            allowInput = true;
            loginResult = loginTime = "-";
            checkMacResult = checkMacTime = "-";
            checkFwResult = checkFwTime = "-";
            checkLan1Result = checkLan1Time = "-";
            checkLan2Result = checkLan2Time = "-";
            checkUsb1Result = checkUsb1Time = "-";
            checkUsb2Result = checkUsb2Time = "-";
            checkSDCardResult = checkSDCardTime = "-";
            checkHdmiResult = checkHdmiTime = "-";
            checkPowerButtonResult = checkPowerButtonTime = "-";
            inputBarcode = macDut = macStamp = "";
            totalTime = "00:00:00";
            totalResult = "-";
            logDut = logSystem = "";
            showIndex = 0;
        }

        public void Wait() {
            allowInput = false;
            totalResult = "Waiting...";
        }

        public bool Passed() {
            allowInput = true;
            totalResult = "Passed";
            return true;
        }

        public bool Failed() {
            allowInput = true;
            totalResult = "Failed";
            return false;
        }

        #endregion

        #region choose display

        int _index;
        public int showIndex {
            get { return _index; }
            set {
                _index = value;
                OnPropertyChanged(nameof(showIndex));
            }
        }
        bool _allow_input;
        public bool allowInput {
            get { return _allow_input; }
            set {
                _allow_input = value;
                OnPropertyChanged(nameof(allowInput));
            }
        }


        public bool isLogin { get; set; }

        #endregion

        #region login dut

        string _login_result;
        public string loginResult {
            get { return _login_result; }
            set { _login_result = value; OnPropertyChanged(nameof(loginResult)); }
        }
        string _login_time;
        public string loginTime {
            get { return _login_time; }
            set { _login_time = value; OnPropertyChanged(nameof(loginTime)); }
        }

        #endregion

        #region check mac

        string _check_mac_result;
        public string checkMacResult {
            get { return _check_mac_result; }
            set { _check_mac_result = value; OnPropertyChanged(nameof(checkMacResult)); }
        }
        string _check_mac_time;
        public string checkMacTime {
            get { return _check_mac_time; }
            set { _check_mac_time = value; OnPropertyChanged(nameof(checkMacTime)); }
        }

        #endregion

        #region check firmware version

        string _check_fw_result;
        public string checkFwResult {
            get { return _check_fw_result; }
            set { _check_fw_result = value; OnPropertyChanged(nameof(checkFwResult)); }
        }
        string _check_fw_time;
        public string checkFwTime {
            get { return _check_fw_time; }
            set { _check_fw_time = value; OnPropertyChanged(nameof(checkFwTime)); }
        }

        #endregion

        #region check LAN 1

        string _check_lan1_result;
        public string checkLan1Result {
            get { return _check_lan1_result; }
            set { _check_lan1_result = value; OnPropertyChanged(nameof(checkLan1Result)); }
        }
        string _check_lan1_time;
        public string checkLan1Time {
            get { return _check_lan1_time; }
            set { _check_lan1_time = value; OnPropertyChanged(nameof(checkLan1Time)); }
        }

        #endregion

        #region check LAN 2

        string _check_lan2_result;
        public string checkLan2Result {
            get { return _check_lan2_result; }
            set { _check_lan2_result = value; OnPropertyChanged(nameof(checkLan2Result)); }
        }
        string _check_lan2_time;
        public string checkLan2Time {
            get { return _check_lan2_time; }
            set { _check_lan2_time = value; OnPropertyChanged(nameof(checkLan2Time)); }
        }

        #endregion

        #region check USB 1

        string _check_usb1_result;
        public string checkUsb1Result {
            get { return _check_usb1_result; }
            set { _check_usb1_result = value; OnPropertyChanged(nameof(checkUsb1Result)); }
        }
        string _check_usb1_time;
        public string checkUsb1Time {
            get { return _check_usb1_time; }
            set { _check_usb1_time = value; OnPropertyChanged(nameof(checkUsb1Time)); }
        }

        #endregion

        #region check USB 2

        string _check_usb2_result;
        public string checkUsb2Result {
            get { return _check_usb2_result; }
            set { _check_usb2_result = value; OnPropertyChanged(nameof(checkUsb2Result)); }
        }
        string _check_usb2_time;
        public string checkUsb2Time {
            get { return _check_usb2_time; }
            set { _check_usb2_time = value; OnPropertyChanged(nameof(checkUsb2Time)); }
        }

        #endregion

        #region check SD Card

        string _check_sdcard_result;
        public string checkSDCardResult {
            get { return _check_sdcard_result; }
            set { _check_sdcard_result = value; OnPropertyChanged(nameof(checkSDCardResult)); }
        }
        string _check_sdcard_time;
        public string checkSDCardTime {
            get { return _check_sdcard_time; }
            set { _check_sdcard_time = value; OnPropertyChanged(nameof(checkSDCardTime)); }
        }

        #endregion

        #region check HDMI

        string _check_hdmi_result;
        public string checkHdmiResult {
            get { return _check_hdmi_result; }
            set { _check_hdmi_result = value; OnPropertyChanged(nameof(checkHdmiResult)); }
        }
        string _check_hdmi_time;
        public string checkHdmiTime {
            get { return _check_hdmi_time; }
            set { _check_hdmi_time = value; OnPropertyChanged(nameof(checkHdmiTime)); }
        }

        #endregion

        #region check Power Button

        string _check_power_button_result;
        public string checkPowerButtonResult {
            get { return _check_power_button_result; }
            set { _check_power_button_result = value; OnPropertyChanged(nameof(checkPowerButtonResult)); }
        }
        string _check_power_button_time;
        public string checkPowerButtonTime {
            get { return _check_power_button_time; }
            set { _check_power_button_time = value; OnPropertyChanged(nameof(checkPowerButtonTime)); }
        }

        #endregion

        #region result

        string _input_barcode;
        public string inputBarcode {
            get { return _input_barcode; }
            set {
                _input_barcode = value;
                OnPropertyChanged(nameof(inputBarcode));
            }
        }
        string _mac_stamp;
        public string macStamp {
            get { return _mac_stamp; }
            set {
                _mac_stamp = value;
                OnPropertyChanged(nameof(macStamp));
            }
        }
        string _mac_dut;
        public string macDut {
            get { return _mac_dut; }
            set {
                _mac_dut = value;
                OnPropertyChanged(nameof(macDut));
            }
        }
        string _total_time;
        public string totalTime {
            get { return _total_time; }
            set {
                _total_time = value;
                OnPropertyChanged(nameof(totalTime));
            }
        }
        string _total_result;
        public string totalResult {
            get { return _total_result; }
            set {
                _total_result = value;
                OnPropertyChanged(nameof(totalResult));
            }
        }

        #endregion

        #region log

        string _log_dut;
        public string logDut {
            get { return _log_dut; }
            set {
                _log_dut = value;
                OnPropertyChanged(nameof(logDut));
            }
        }
        string _log_dhcp;
        public string logDhcp {
            get { return _log_dhcp; }
            set {
                _log_dhcp = value;
                OnPropertyChanged(nameof(logDhcp));
            }
        }
        string _log_system;
        public string logSystem {
            get { return _log_system; }
            set {
                _log_system = value;
                OnPropertyChanged(nameof(logSystem));
            }
        }

        #endregion
    }
}
