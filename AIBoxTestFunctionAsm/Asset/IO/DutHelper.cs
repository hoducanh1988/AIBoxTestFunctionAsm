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
            switch (setting.dutProtocol) {
                case "Telnet": { dut = new Telnet<RunModel>(testing, "logDut"); break; }
                case "SSH": { dut = new Ssh<RunModel>(testing, "logDut"); break; }
            }
            dut.Login(setting.dhcpServerStartIP, setting.dutUser, setting.dutPassword, "@linux:~$");
        }


        public bool is_hdmi_plugged() {
            if (!dut.IsConnected) return false;
            string data = "";
            dut.Query("dmesg | grep -i hdmi", "@linux:~$", 3000, 3, out data);
            bool r = false;
            r = string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data);
            if (r) return false;

            int count = new Regex(Regex.Escape("unplugged")).Matches(data).Count;
            r = count == 1;
            return r;
        }

        public bool is_usb1_plugged() {
            if (!dut.IsConnected) return false;
            string data = "";
            dut.Query("lsusb -t", "@linux:~$", 3000, 3, out data);
            bool r = false;
            r = string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data);
            if (r) return false;

            r = data.Contains("        |__ Port 1: Dev 6, If 0, Class=Mass Storage, Driver=usb-storage, 480M");
           
            return r;
        }

        public bool is_usb2_plugged() {
            if (!dut.IsConnected) return false;
            string data = "";
            dut.Query("lsusb -t", "@linux:~$", 3000, 3, out data);
            bool r = false;
            r = string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data);
            if (r) return false;

            r = data.Contains("        |__ Port 2: Dev 5, If 0, Class=Mass Storage, Driver=usb-storage, 480M");

            return r;
        }


        public void Dispose() {
            if (dut != null) dut.Close();
        }

    }
}
