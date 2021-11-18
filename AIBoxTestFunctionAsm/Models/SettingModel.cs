using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBoxTestFunctionAsm.Models {
    public class SettingModel : INotifyPropertyChanged {

        public SettingModel() {
            dutProtocol = dutUser = dutPassword = "";
            dutFwVersion = dutLAN1Speed = dutLAN2Speed = "";
            dhcpServerIP = dhcpServerProtocol = dhcpServerUser = dhcpServerPassword = dhcpServerStartIP = "";
            isLogin = isCheckMac = isCheckFw = true;
            isCheckLAN1 = isCheckLAN2 = true;
            isCheckUSB1 = isCheckUSB2 = true;
            isCheckSDCard = true;
            isCheckHDMI = true;
            isCheckLED = true;
            isCheckPowerButton = true;
        }

        string _dut_protocol;
        public string dutProtocol {
            get { return _dut_protocol; }
            set {
                _dut_protocol = value;
                OnPropertyChanged(nameof(dutProtocol));
            }
        }
        string _dut_user;
        public string dutUser {
            get { return _dut_user; }
            set {
                _dut_user = value;
                OnPropertyChanged(nameof(dutUser));
            }
        }
        string _dut_pass;
        public string dutPassword {
            get { return _dut_pass; }
            set {
                _dut_pass = value;
                OnPropertyChanged(nameof(dutPassword));
            }
        }
        string _dut_fw;
        public string dutFwVersion {
            get { return _dut_fw; }
            set {
                _dut_fw = value;
                OnPropertyChanged(nameof(dutFwVersion));
            }
        }
        string _dut_lan1;
        public string dutLAN1Speed {
            get { return _dut_lan1; }
            set {
                _dut_lan1 = value;
                OnPropertyChanged(nameof(dutLAN1Speed));
            }
        }
        string _dut_lan2;
        public string dutLAN2Speed {
            get { return _dut_lan2; }
            set {
                _dut_lan2 = value;
                OnPropertyChanged(nameof(dutLAN2Speed));
            }
        }
        string _dhcp_ip;
        public string dhcpServerIP {
            get { return _dhcp_ip; }
            set {
                _dhcp_ip = value;
                OnPropertyChanged(nameof(dhcpServerIP));
            }
        }
        string _dhcp_protocol;
        public string dhcpServerProtocol {
            get { return _dhcp_protocol; }
            set {
                _dhcp_protocol = value;
                OnPropertyChanged(nameof(dhcpServerProtocol));
            }
        }
        string _dhcp_user;
        public string dhcpServerUser {
            get { return _dhcp_user; }
            set {
                _dhcp_user = value;
                OnPropertyChanged(nameof(dhcpServerUser));
            }
        }
        string _dhcp_pass;
        public string dhcpServerPassword {
            get { return _dhcp_pass; }
            set {
                _dhcp_pass = value;
                OnPropertyChanged(nameof(dhcpServerPassword));
            }
        }
        string _dhcp_start;
        public string dhcpServerStartIP {
            get { return _dhcp_start; }
            set {
                _dhcp_start = value;
                OnPropertyChanged(nameof(dhcpServerStartIP));
            }
        }
        bool _is_login;
        public bool isLogin {
            get { return _is_login; }
            set {
                _is_login = value;
                OnPropertyChanged(nameof(isLogin));
            }
        }
        bool _is_check_mac;
        public bool isCheckMac {
            get { return _is_check_mac; }
            set {
                _is_check_mac = value;
                OnPropertyChanged(nameof(isCheckMac));
            }
        }
        bool _is_check_fw;
        public bool isCheckFw {
            get { return _is_check_fw; }
            set {
                _is_check_fw = value;
                OnPropertyChanged(nameof(isCheckFw));
            }
        }
        bool _is_check_lan1;
        public bool isCheckLAN1 {
            get { return _is_check_lan1; }
            set {
                _is_check_lan1 = value;
                OnPropertyChanged(nameof(isCheckLAN1));
            }
        }
        bool _is_check_lan2;
        public bool isCheckLAN2 {
            get { return _is_check_lan2; }
            set {
                _is_check_lan2 = value;
                OnPropertyChanged(nameof(isCheckLAN2));
            }
        }
        bool _is_check_usb1;
        public bool isCheckUSB1 {
            get { return _is_check_usb1; }
            set {
                _is_check_usb1 = value;
                OnPropertyChanged(nameof(isCheckUSB1));
            }
        }
        bool _is_check_usb2;
        public bool isCheckUSB2 {
            get { return _is_check_usb2; }
            set {
                _is_check_usb2 = value;
                OnPropertyChanged(nameof(isCheckUSB2));
            }
        }
        bool _is_check_sdcard;
        public bool isCheckSDCard {
            get { return _is_check_sdcard; }
            set {
                _is_check_sdcard = value;
                OnPropertyChanged(nameof(isCheckSDCard));
            }
        }
        bool _is_check_hdmi;
        public bool isCheckHDMI {
            get { return _is_check_hdmi; }
            set {
                _is_check_hdmi = value;
                OnPropertyChanged(nameof(isCheckHDMI));
            }
        }
        bool _is_check_led;
        public bool isCheckLED {
            get { return _is_check_led; }
            set {
                _is_check_led = value;
                OnPropertyChanged(nameof(isCheckLED));
            }
        }
        bool _is_check_power_button;
        public bool isCheckPowerButton {
            get { return _is_check_power_button; }
            set {
                _is_check_power_button = value;
                OnPropertyChanged(nameof(isCheckPowerButton));
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
