using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIBoxTestFunctionAsm.Asset.Protocol {
    public class Ssh <T> : IProtocol where T: class, new() {

        private ShellStream shellStreamSSH;
        private SshClient sshClient;
        protected T obj = null;
        public bool IsConnected { get; set; }
        string log_name;

        public Ssh(T t, string lg_name) {
            this.obj = t;
            this.log_name = lg_name;
            IsConnected = false;
        }

        public bool Login(string ip, string user, string password, string data_success) {
            try {
                this.sshClient = new SshClient(ip, 22, user, password);

                //Thực hiện kết nối
                this.sshClient.ConnectionInfo.Timeout = TimeSpan.FromSeconds(3);
                this.sshClient.Connect();

                // tạo shell stream để điều khiển command ssh
                this.shellStreamSSH = this.sshClient.CreateShellStream("vt100", 80, 60, 800, 600, 65535);

                this.Write("\n");
                Thread.Sleep(500);
                string data = this.Read();

                IsConnected = data.Contains(data_success);
            }
            catch {
                IsConnected = false;
            }
            return IsConnected;
        }

        public bool Write(string cmd) {
            try {
                if (!IsConnected) return false;
                this.shellStreamSSH.Write(cmd);
                this.shellStreamSSH.Flush();
                return true;
            } catch { return false; }
            
        }

        public bool WriteLine(string cmd) {
            return this.Write(cmd + "\n");
        }

        public string Read() {
            string value = "NULL";
            try {
                value = shellStreamSSH.Read();

                PropertyInfo log = this.obj.GetType().GetProperty(this.log_name);
                string data = (string)log.GetValue(this.obj, null);
                data += value;
                log.SetValue(this.obj, Convert.ChangeType(data, log.PropertyType), null);

                return value;
            }
            catch {
                return value;
            };
        }

        public string Query(string cmd, int delay_time) {
            this.WriteLine(cmd);
            Thread.Sleep(delay_time);
            return this.Read();
        }

        public bool Query(string cmd, string pattern, int timeout_ms, out string data_feedback) {
            this.WriteLine(cmd);

            bool r = false;
            int count = 0;
            int max_count = timeout_ms / 100;
            string data = "";
            data_feedback = "";

        RE:
            count++;
            data += this.Read();
            r = data.ToLower().Contains(pattern.ToLower());
            if (!r) {
                if (count < max_count) {
                    Thread.Sleep(100);
                    goto RE;
                }
            }
            data_feedback = data;
            return r;
        }

        public bool Query(string cmd, string pattern, int timeout_ms, int retry_time, out string data_feedback) {
            data_feedback = "";

            string data_out = "";
            bool r = false;
            int count = 0;

        RE:
            count++;
            r = this.Query(cmd, pattern, timeout_ms, out data_out);
            data_feedback += data_out;
            if (!r) {
                if (count < retry_time) {
                    goto RE;
                }
            }
            return r;
        }

        public void Disconnect() {
            if (this.shellStreamSSH != null) this.shellStreamSSH.Close();
            if (this.sshClient != null) this.sshClient.Disconnect();
        }

        public void Close() {
            if (this.shellStreamSSH != null) this.shellStreamSSH.Close();
            if (this.sshClient != null) this.sshClient.Dispose();
        }

    }
}
