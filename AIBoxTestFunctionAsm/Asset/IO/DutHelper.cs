using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIBoxTestFunctionAsm.Asset.Protocol;
using System.Text.RegularExpressions;
using AIBoxTestFunctionAsm.Models;

namespace AIBoxTestFunctionAsm.Asset.IO {
    public class DutHelper : IDisposable {
        IProtocol dut = null;
        SettingModel setting;
        RunModel testing;

        public DutHelper(SettingModel sm, RunModel rm) {
            setting = sm;
            testing = rm;
        }

        public bool is_login_success() {
            switch (setting.dutProtocol) {
                case "Telnet": { dut = new Telnet<RunModel>(testing, "logDut"); break; }
                case "SSH": { dut = new Ssh<RunModel>(testing, "logDut"); break; }
            }
            return dut.Login(setting.dhcpServerStartIP, setting.dutUser, setting.dutPassword, "@linux:~$");
        }

        public bool is_hdmi_plugged() {
            if (!dut.IsConnected) return false;
            string data = "";
            dut.Query("dmesg | grep -i hdmi", "@linux:~$", 5000, 3, out data);
            bool r = false;
            r = string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data);
            if (r) return false;
            r = data.Contains("tegradc tegradc.0:");
            if (!r) return false;

            string[] buffer = data.Split('\n');
            int max = buffer.Length - 1;
            string s = "";
            for (int i = max; i >= 0; i--) {
                if (buffer[i].Contains("tegradc tegradc.0:")) {
                    s = buffer[i];
                    break;
                }
            }

            buffer = s.Split(':');
            string hdmi_status = buffer[buffer.Length - 1].Replace("\r", "").Trim();
            r = hdmi_status.Contains("unplugged");

            return !r;
        }

        public string get_mac_address() {
            if (!dut.IsConnected) return null;
            string data = "";
            dut.Query("cat /sys/class/net/eth1/address", "@linux:~$", 3000, 3, out data);
            bool r = false;
            r = string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data);
            if (r) return null;

            string[] buffer = data.Split('\n');
            r = buffer.Length == 3;
            if (!r) return null;

            string mac = buffer[1].Replace(":", "").Replace("\r", "").Trim().ToUpper();
            return mac;
        }

        public string get_firmware_version() {
            if (!dut.IsConnected) return null;
            string data = "";
            dut.Query("cat /etc/fw_info.txt", "@linux:~$", 3000, 3, out data);
            bool r = false;
            r = string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data);
            if (r) return null;

            string[] buffer = data.Split('\n');
            r = buffer.Length == 3;
            if (!r) return null;

            string fw = buffer[1].Replace(":", "").Replace("\r", "").Trim().ToUpper();
            return fw;
        }

        public string get_lan_state(int index) {
            if (!dut.IsConnected) return null;
            string data = "";
            dut.Query($"cat /sys/class/net/eth{index - 1}/operstate", "@linux:~$", 3000, 3, out data);
            bool r = false;
            r = string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data);
            if (r) return null;

            string[] buffer = data.Split('\n');
            r = buffer.Length == 3;
            if (!r) return null;

            string state = buffer[1].Replace("\r", "").Trim().ToUpper();
            return state;
        }

        public string get_lan_speed(int index) {
            if (!dut.IsConnected) return null;
            string data = "";
            dut.Query($"cat /sys/class/net/eth{index - 1}/speed", "@linux:~$", 3000, 3, out data);
            bool r = false;
            r = string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data);
            if (r) return null;

            string[] buffer = data.Split('\n');
            r = buffer.Length == 3;
            if (!r) return null;

            string speed = buffer[1].Replace("\r", "").Trim().ToUpper();
            return speed;
        }

        public bool is_usb1_plugged() {
            if (!dut.IsConnected) return false;
            string data = "";
            dut.Query("lsusb -t", "@linux:~$", 3000, 3, out data);
            bool r = false;
            r = string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data);
            if (r) return false;

            r = data.Contains("        |__ Port 1: Dev");
            return r;
        }

        public bool is_usb2_plugged() {
            if (!dut.IsConnected) return false;
            string data = "";
            dut.Query("lsusb -t", "@linux:~$", 3000, 3, out data);
            bool r = false;
            r = string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data);
            if (r) return false;

            r = data.Contains("        |__ Port 2: Dev");

            return r;
        }

        public bool is_sdcard_plugged() {
            if (!dut.IsConnected) return false;
            string data = "";
            dut.Query("dmesg | grep -i card", "@linux:~$", 3000, 3, out data);
            bool r = false;
            r = string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data);
            if (r) return false;
            r = data.Contains("mmc1:");
            if (!r) return false;

            string[] buffer = data.Split('\n');
            int max = buffer.Length - 1;
            string s = "";
            for (int i = max; i >= 0; i--) {
                if (buffer[i].Contains("mmc1:")) {
                    s = buffer[i];
                    break;
                }
            }
            r = s.Contains("removed");
            
            return !r;
        }


        public void Dispose() {
            if (dut != null) dut.Close();
        }

    }
}
