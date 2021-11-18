using AIBoxTestFunctionAsm.Asset.Global;
using AIBoxTestFunctionAsm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AIBoxTestFunctionAsm.Asset.IO {
    public class LogHelper {

        RunModel rm;
        string dir_log;

        public LogHelper() {
            rm = myGlobal.runviewmodel.RN;
            dir_log = $"{AppDomain.CurrentDomain.BaseDirectory}Log\\{DateTime.Now.ToString("yyyy-MM-dd")}\\{rm.macStamp}_{DateTime.Now.ToString("HHmmss")}_{rm.totalResult}";
            if (!Directory.Exists(dir_log)) Directory.CreateDirectory(dir_log);
        }

        public void to_file() {
            save_log_total();
            save_log_system();
            save_log_dut();
            save_log_dhcp_server();
        }

        void save_log_total() {
            string f = $"{AppDomain.CurrentDomain.BaseDirectory}Log\\{DateTime.Now.ToString("yyyy-MM-dd")}.csv";
            string title = "DATETIME,MAC,RESULT,TIME,LOGIN,CHECK_MAC,CHECK_FW,CHECK_LAN1,CHECK_LAN2,CHECK_USB1,CHECK_USB2,CHECK_SDCARD,CHECK_HDMI,CHECK_POWER";
            string content = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
                                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                            rm.macStamp,
                                            rm.totalResult,
                                            rm.totalTime,
                                            rm.loginResult,
                                            rm.checkMacResult,
                                            rm.checkFwResult,
                                            rm.checkLan1Result,
                                            rm.checkLan2Result,
                                            rm.checkUsb1Result,
                                            rm.checkUsb2Result,
                                            rm.checkSDCardResult,
                                            rm.checkHdmiResult,
                                            rm.checkPowerButtonResult);

            bool is_write_title = !File.Exists(f);
            
            using (var sw = new StreamWriter(f, true, Encoding.Unicode)) {
                if (is_write_title) sw.WriteLine(title);
                sw.WriteLine(content);
            }
        }

        void save_log_system() {
            string f = $"{dir_log}\\{rm.macStamp}_{DateTime.Now.ToString("yyyyMMddHHmmss")}_{rm.totalResult}_sys.txt";
            File.WriteAllText(f, rm.logSystem, Encoding.Unicode);
        }

        void save_log_dut() {
            string f = $"{dir_log}\\{rm.macStamp}_{DateTime.Now.ToString("yyyyMMddHHmmss")}_{rm.totalResult}_dut.txt";
            File.WriteAllText(f, rm.logDut, Encoding.Unicode);
        }

        void save_log_dhcp_server() {
            string f = $"{dir_log}\\{rm.macStamp}_{DateTime.Now.ToString("yyyyMMddHHmmss")}_{rm.totalResult}_dhcp.txt";
            File.WriteAllText(f, rm.logDhcp, Encoding.Unicode);
        }

    }
}
