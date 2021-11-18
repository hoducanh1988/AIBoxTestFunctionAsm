using AIBoxTestFunctionAsm.Asset.Protocol;
using AIBoxTestFunctionAsm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBoxTestFunctionAsm.Asset.IO {
    public class DhcpHelper : IDisposable {

        IProtocol dhcp = null;
        SettingModel setting;
        RunModel testing;

        public DhcpHelper(SettingModel sm, RunModel rm) {
            setting = sm;
            testing = rm;
        }

        public bool is_login_success() {
            switch (setting.dhcpServerProtocol) {
                case "Telnet": { dhcp = new Telnet<RunModel>(testing, "logDhcp"); break; }
                case "SSH": { dhcp = new Ssh<RunModel>(testing, "logDhcp"); break; }
            }
            return dhcp.Login(setting.dhcpServerIP, setting.dhcpServerUser, setting.dhcpServerPassword, "#");
        }

        public bool resetDhcp() {
            if (!dhcp.IsConnected) return false;
            string s;
            bool r = dhcp.Query("rm -rf /etc/udhcpd.leases", "#", 3000, out s);
            if (!r) return false;
            r = dhcp.Query("tcapi commit Dhcpd", "#", 10000, out s);
            return r;
        }

        public void Dispose() {
            if (dhcp != null) dhcp.Close();
        }
    }
}
