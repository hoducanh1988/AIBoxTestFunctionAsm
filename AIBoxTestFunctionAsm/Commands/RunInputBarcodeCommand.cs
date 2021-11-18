using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;
using System.Diagnostics;
using AIBoxTestFunctionAsm.Asset.Global;
using AIBoxTestFunctionAsm.Asset.IO;
using AIBoxTestFunctionAsm.Models;
using AIBoxTestFunctionAsm.ViewModels;
using UtilityPack.Converter;

namespace AIBoxTestFunctionAsm.Commands {
    public class RunInputBarcodeCommand : ICommand {

        public struct RESULT {
            public static string Wait = "Waiting...";
            public static string Pass = "Passed";
            public static string Fail = "Failed";
            public static string None = "-";
        }

        RunModel rm = null;
        SettingModel sm = null;

        private RunViewModel _rvm;
        public RunInputBarcodeCommand(RunViewModel rvm) {
            _rvm = rvm;
            rm = _rvm.RN;
            sm = _rvm.SM;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //enable button save setting
        public bool CanExecute(object parameter) {
            return true;
        }

        //save setting
        public void Execute(object parameter) {

            Thread t = new Thread(new ThreadStart(() => {
                bool r = test_all();
            }));
            t.IsBackground = true;
            t.Start();

            Thread z = new Thread(new ThreadStart(() => {
                int count = 0;
            RE:
                count++;
                Thread.Sleep(500);
                if (t.IsAlive) {
                    rm.totalTime = myConverter.intToTimeSpan(count * 500);
                    goto RE;
                }

            }));
            z.IsBackground = true;
            z.Start();
        }

        #endregion

        #region test function

        private bool test_all() {
            bool r = false;

            rm.Init_Value();
            rm.Wait();

            DutHelper dut = new DutHelper(sm, rm);
            DhcpHelper dhcp = new DhcpHelper(sm, rm);

            //login dut
            if (sm.isLogin) {
                r = login_to_dut(dut, sm, rm); if (!r) goto END;
            }
            //check mac ethernet
            if (sm.isCheckMac) {
                r = check_mac_address(dut, sm, rm); if (!r) goto END;
            }
            //check firmware version
            if (sm.isCheckFw) {
                r = check_firmware_version(dut, sm, rm); if (!r) goto END;
            }
            //check lan1
            if (sm.isCheckLAN1) {
                r = check_lan1(dut, sm, rm); if (!r) goto END;
            }
            //check lan2
            if (sm.isCheckLAN2) {
                r = check_lan2(dut, sm, rm); if (!r) goto END;
            }
            //check usb1
            if (sm.isCheckUSB1) {
                r = check_usb1(dut, sm, rm); if (!r) goto END;
            }
            //check usb2
            if (sm.isCheckUSB2) {
                r = check_usb2(dut, sm, rm); if (!r) goto END;
            }
            //check sd card
            if (sm.isCheckSDCard) {
                r = check_sd_card(dut, sm, rm); if (!r) goto END;
            }
            //check hdmi
            if (sm.isCheckHDMI) {
                r = check_hdmi(dut, sm, rm); if (!r) goto END;
            }
            //check power button & LED
            if (sm.isCheckPowerButton) {
                r = check_power_button(dut, sm, rm); if (!r) goto END;
            }

        END:
            reset_dhcp_client(dhcp, sm, rm);
            dut.Dispose();
            dhcp.Dispose();
            bool ___ = r ? rm.Passed() : rm.Failed();
            rm.logSystem += $"-\n{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, Phán định sản phẩm:\n";
            rm.logSystem += $"Mac address: {rm.macStamp}\n";
            rm.logSystem += $"Tổng phán định: {rm.totalResult}\n";
            rm.logSystem += $"Tổng thời gian: {rm.totalTime}\n";
            LogHelper log = new LogHelper();
            log.to_file();
            return r;
        }

        #endregion

        #region sub function

        private bool login_to_dut(DutHelper dut, SettingModel sm, RunModel rm) {
            Stopwatch st = new Stopwatch();
            st.Start();

            bool r = false;
            rm.loginResult = RESULT.Wait;
            rm.logSystem += $"-\n{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, Login {sm.dutProtocol} vào sản phẩm:\n";
            rm.logSystem += $"...IP={sm.dhcpServerStartIP}\n";
            rm.logSystem += $"...User={sm.dutUser}\n";
            rm.logSystem += $"...Pass={sm.dutPassword}\n";

            int count = 0;

        RE:
            count++;
            r = dut.is_login_success();
            if (!r) { if (count < 3) goto RE; }

            //end
            st.Stop();
            rm.loginResult = r ? RESULT.Pass : RESULT.Fail;
            rm.loginTime = $"{st.ElapsedMilliseconds} ms";
            rm.logSystem += $"Kết quả: {rm.loginResult}\n";
            rm.logSystem += $"Elapsed time: {rm.loginTime}\n";

            return r;
        }

        private bool check_mac_address(DutHelper dut, SettingModel sm, RunModel rm) {
            Stopwatch st = new Stopwatch();
            st.Start();

            bool r = false;
            rm.checkMacResult = RESULT.Wait;
            rm.logSystem += $"-\n{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, Kiểm tra mac ethernet:\n";
            rm.logSystem += $"...Mac nhập từ tem={rm.macStamp}\n";

            int count = 0;
        RE:
            count++;
            string mac = dut.get_mac_address();
            rm.logSystem += $"...Mac đọc ra từ sản phẩm [{count}]={mac}\n";
            r = mac == null;
            if (r) {
                if (count < 3) goto RE;
                else goto END;
            }
            r = rm.macStamp.ToUpper().Equals(mac);
            if (!r) { if (count < 3) goto RE; }

        END:
            st.Stop();
            rm.checkMacResult = r ? RESULT.Pass : RESULT.Fail;
            rm.checkMacTime = $"{st.ElapsedMilliseconds} ms";
            rm.logSystem += $"Kết quả: {rm.checkMacResult}\n";
            rm.logSystem += $"Elapsed time: {rm.checkMacTime}\n";

            return r;
        }

        private bool check_firmware_version(DutHelper dut, SettingModel sm, RunModel rm) {
            Stopwatch st = new Stopwatch();
            st.Start();

            bool r = false;
            rm.checkFwResult = RESULT.Wait;
            rm.logSystem += $"-\n{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, Kiểm tra firmware version:\n";
            rm.logSystem += $"...Firmware version setting={sm.dutFwVersion}\n";

            int count = 0;
        RE:
            count++;
            string fw = dut.get_firmware_version();
            rm.logSystem += $"...Firmware version đọc ra từ sản phẩm [{count}]={fw}\n";
            r = fw == null;
            if (r) {
                if (count < 3) goto RE;
                else goto END;
            }
            r = sm.dutFwVersion.ToUpper().Equals(fw);
            if (!r) { if (count < 3) goto RE; }

        END:
            st.Stop();
            rm.checkFwResult = r ? RESULT.Pass : RESULT.Fail;
            rm.checkFwTime = $"{st.ElapsedMilliseconds} ms";
            rm.logSystem += $"Kết quả: {rm.checkFwResult}\n";
            rm.logSystem += $"Elapsed time: {rm.checkFwTime}\n";
            return r;
        }

        private bool check_lan1(DutHelper dut, SettingModel sm, RunModel rm) {
            Stopwatch st = new Stopwatch();
            st.Start();

            bool r = false;
            rm.checkLan1Result = RESULT.Wait;
            rm.logSystem += $"-\n{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, Kiểm tra cổng LAN1:\n";
            rm.logSystem += $"...Trạng thái tiêu chuẩn=UP\n";

            int count = 0;
        RE:
            count++;
            string state = dut.get_lan_state(1);
            rm.logSystem += $"...Trạng thái thực tế [{count}]={state}\n";
            r = state == null;
            if (r) {
                if (count < 3) goto RE;
                else goto END;
            }
            r = state.Equals("UP");
            if (!r) {
                if (count < 3) goto RE;
                else goto END;
            }

            rm.logSystem += $"...Tốc độ trong setting={sm.dutLAN1Speed}\n";
            string speed = dut.get_lan_speed(1);
            rm.logSystem += $"...Tốc độ thực tế [{count}]={speed}\n";
            r = speed == null;
            if (r) {
                if (count < 3) goto RE;
                else goto END;
            }
            r = speed.Equals(sm.dutLAN1Speed);
            if (!r) { if (count < 3) goto RE; }

        END:
            st.Stop();
            rm.checkLan1Result = r ? RESULT.Pass : RESULT.Fail;
            rm.checkLan1Time = $"{st.ElapsedMilliseconds} ms";
            rm.logSystem += $"Kết quả: {rm.checkLan1Result}\n";
            rm.logSystem += $"Elapsed time: {rm.checkLan1Time}\n";

            return r;
        }

        private bool check_lan2(DutHelper dut, SettingModel sm, RunModel rm) {
            Stopwatch st = new Stopwatch();
            st.Start();

            bool r = false;
            rm.checkLan2Result = RESULT.Wait;
            rm.logSystem += $"-\n{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, Kiểm tra cổng LAN2:\n";
            rm.logSystem += $"...Trạng thái tiêu chuẩn=UP\n";
            int count = 0;

        RE:
            count++;
            string state = dut.get_lan_state(2);
            rm.logSystem += $"...Trạng thái thực tế [{count}]={state}\n";
            r = state == null;
            if (r) {
                if (count < 3) goto RE;
                else goto END;
            }
            r = state.Equals("UP");
            if (!r) {
                if (count < 3) goto RE;
                else goto END;
            }

            rm.logSystem += $"...Tốc độ trong setting={sm.dutLAN2Speed}\n";
            string speed = dut.get_lan_speed(2);
            rm.logSystem += $"...Tốc độ thực tế [{count}]={speed}\n";
            r = speed == null;
            if (r) {
                if (count < 3) goto RE;
                else goto END;
            }
            r = speed.Equals(sm.dutLAN2Speed);
            if (!r) { if (count < 3) goto RE; }

        END:
            st.Stop();
            rm.checkLan2Result = r ? RESULT.Pass : RESULT.Fail;
            rm.checkLan2Time = $"{st.ElapsedMilliseconds} ms";
            rm.logSystem += $"Kết quả: {rm.checkLan2Result}\n";
            rm.logSystem += $"Elapsed time: {rm.checkLan2Time}\n";

            return r;
        }

        private bool check_usb1(DutHelper dut, SettingModel sm, RunModel rm) {
            Stopwatch st = new Stopwatch();
            st.Start();

            bool r = false;
            rm.checkUsb1Result = RESULT.Wait;
            rm.logSystem += $"-\n{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, Kiểm tra cổng USB1:\n";

            int count = 0;
        RE:
            count++;
            r = dut.is_usb1_plugged();
            if (!r) { if (count < 3) goto RE; }

            //end
            st.Stop();
            rm.checkUsb1Result = r ? RESULT.Pass : RESULT.Fail;
            rm.checkUsb1Time = $"{st.ElapsedMilliseconds} ms";
            rm.logSystem += $"Kết quả: {rm.checkUsb1Result}\n";
            rm.logSystem += $"Elapsed time: {rm.checkUsb1Time}\n";
            return r;
        }

        private bool check_usb2(DutHelper dut, SettingModel sm, RunModel rm) {
            Stopwatch st = new Stopwatch();
            st.Start();

            bool r = false;
            rm.checkUsb2Result = RESULT.Wait;
            rm.logSystem += $"-\n{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, Kiểm tra cổng USB2:\n";

            int count = 0;
        RE:
            count++;
            r = dut.is_usb2_plugged();
            if (!r) { if (count < 3) goto RE; }

            //end
            st.Stop();
            rm.checkUsb2Result = r ? RESULT.Pass : RESULT.Fail;
            rm.checkUsb2Time = $"{st.ElapsedMilliseconds} ms";
            rm.logSystem += $"Kết quả: {rm.checkUsb2Result}\n";
            rm.logSystem += $"Elapsed time: {rm.checkUsb2Time}\n";
            return r;
        }

        private bool check_sd_card(DutHelper dut, SettingModel sm, RunModel rm) {
            Stopwatch st = new Stopwatch();
            st.Start();

            bool r = false;
            rm.checkSDCardResult = RESULT.Wait;
            rm.logSystem += $"-\n{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, Kiểm tra cổng SD Card:\n";

            int count = 0;
        RE:
            count++;
            r = dut.is_sdcard_plugged();
            if (!r) { if (count < 3) goto RE; }

            //end
            st.Stop();
            rm.checkSDCardResult = r ? RESULT.Pass : RESULT.Fail;
            rm.checkSDCardTime = $"{st.ElapsedMilliseconds} ms";
            rm.logSystem += $"Kết quả: {rm.checkSDCardResult}\n";
            rm.logSystem += $"Elapsed time: {rm.checkSDCardTime}\n";

            return r;
        }

        private bool check_hdmi(DutHelper dut, SettingModel sm, RunModel rm) {
            Stopwatch st = new Stopwatch();
            st.Start();

            bool r = false;
            rm.checkHdmiResult = RESULT.Wait;
            rm.logSystem += $"-\n{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, Kiểm tra cổng HDMI:\n";
            int count = 0;

        RE:
            count++;
            r = dut.is_hdmi_plugged();
            rm.logSystem += $"...Check log [{count}]: {r}\n";
            if (!r) {
                if (count < 3) goto RE;
                else goto END;
            }

            rm.showIndex = 1;
        RE_2:
            Thread.Sleep(1000);
            r = rm.showIndex == 0;
            if (!r) goto RE_2;
            r = rm.hdmiIdResult == 0;
            rm.logSystem += $"...Check hình ảnh hiển thị: {r}, {rm.hdmiIdResult}\n";

        END:
            st.Stop();
            rm.checkHdmiResult = r ? RESULT.Pass : RESULT.Fail;
            rm.checkHdmiTime = $"{st.ElapsedMilliseconds} ms";
            rm.logSystem += $"Kết quả: {rm.checkHdmiResult}\n";
            rm.logSystem += $"Elapsed time: {rm.checkHdmiTime}\n";

            return r;
        }

        private bool check_power_button(DutHelper dut, SettingModel sm, RunModel rm) {
            Stopwatch st = new Stopwatch();
            st.Start();

            bool r = false;
            rm.checkPowerButtonResult = RESULT.Wait;
            rm.logSystem += $"-\n{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, Kiểm tra nút nguồn và LED:\n";

            rm.showIndex = 2;
        RE:
            Thread.Sleep(1000);
            r = rm.showIndex == 0;
            if (!r) goto RE;
            r = rm.buttonIdResult == 0;
            rm.logSystem += $"...Check trạng thái LED: {r}, {rm.buttonIdResult}\n";

            st.Stop();
            rm.checkPowerButtonResult = r ? RESULT.Pass : RESULT.Fail;
            rm.checkPowerButtonTime = $"{st.ElapsedMilliseconds} ms";
            rm.logSystem += $"Kết quả: {rm.checkPowerButtonResult}\n";
            rm.logSystem += $"Elapsed time: {rm.checkPowerButtonTime}\n";
            return r;
        }

        private bool reset_dhcp_client(DhcpHelper dhcp, SettingModel sm, RunModel rm) {
            Stopwatch st = new Stopwatch();
            st.Start();

            bool r = false;
            rm.logSystem += $"-\n{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, Reset dhcp client:\n";
            rm.logSystem += $"...IP={sm.dhcpServerIP}\n";
            rm.logSystem += $"...User={sm.dhcpServerUser}\n";
            rm.logSystem += $"...Pass={sm.dhcpServerPassword}\n";

            int count = 0;

        RE:
            count++;
            r = dhcp.is_login_success();
            if (!r) {
                if (count < 3) goto RE;
                else goto END;
            }

            r = dhcp.resetDhcp();
            if (!r) { if (count < 3) goto RE; }

        END:
            st.Stop();
            rm.logSystem += $"Kết quả: {r}\n";
            rm.logSystem += $"Elapsed time: {st.ElapsedMilliseconds} ms\n";
            return r;
        }

        #endregion

    }
}
