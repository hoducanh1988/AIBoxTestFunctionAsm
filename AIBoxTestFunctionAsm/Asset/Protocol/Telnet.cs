using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIBoxTestFunctionAsm.Asset.Protocol {
    public class Telnet <T> : IProtocol where T: class, new() {

        protected T obj = null;
        public bool IsConnected { get; set; }
        string log_name;

        TcpClient client;
        enum Verbs { WILL = 251, WONT = 252, DO = 253, DONT = 254, IAC = 255 }
        enum Options { SGA = 3 }


        public Telnet(T t, string lg_name) {
            this.obj = t;
            IsConnected = false;
            this.log_name = lg_name;
        }

        private void configTCP() {
            // Don't allow another process to bind to this port.
            this.client.ExclusiveAddressUse = false;
            // sets the amount of time to linger after closing, using the LingerOption public property.
            this.client.LingerState = new LingerOption(false, 0);
            // Sends data immediately upon calling NetworkStream.Write.
            this.client.NoDelay = true;
            // Sets the receive buffer size using the ReceiveBufferSize public property.
            this.client.ReceiveBufferSize = 1024;
            // Sets the receive time out using the ReceiveTimeout public property.
            this.client.ReceiveTimeout = 5000;
            // Sets the send buffer size using the SendBufferSize public property.
            this.client.SendBufferSize = 1024;
            // sets the send time out using the SendTimeout public property.
            this.client.SendTimeout = 5000;
        }

        bool Connection(string ip) {
            IsConnected = false;
            this.client = new TcpClient();
            this.configTCP();
            try {
                IsConnected = this.client.ConnectAsync(ip, 23).Wait(3000);
            }
            catch {
                IsConnected = false;
            }
            return IsConnected;
        }

        public bool Login(string ip, string user, string password, string data_success) {
            try {
                Connection(ip);
                if (!IsConnected) return false;
                
                string msg = Read();
                WriteLine(user);
                Thread.Sleep(300);

                msg += Read();
                WriteLine(password);
                Thread.Sleep(300);

                msg += Read();
                return msg.Contains(data_success);

            } catch { return false; }
        }

        public bool Write(string cmd) {
            if (!IsConnected) return false;
            try {
                Byte[] sendBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(cmd.Replace("\0xFF", "\0xFF\0xFF")); //convert string to array[bytes]
                this.client.GetStream().Write(sendBytes, 0, sendBytes.Length);
                return true;
            } catch { return false; }
            
        }

        public bool WriteLine(string cmd) {
            return this.Write(cmd + "\n");
        }

        void ParseTelnet(StringBuilder sb) {

            while (this.client.Available > 0) {
                int input = this.client.GetStream().ReadByte();
                switch (input) {
                    case -1:
                        break;
                    case (int)Verbs.IAC:
                        // interpret as command
                        int inputverb = this.client.GetStream().ReadByte();
                        if (inputverb == -1) break;
                        switch (inputverb) {
                            case (int)Verbs.IAC:
                                //literal IAC = 255 escaped, so append char 255 to string
                                sb.Append(inputverb);
                                break;
                            case (int)Verbs.DO:
                            case (int)Verbs.DONT:
                            case (int)Verbs.WILL:
                            case (int)Verbs.WONT:
                                // reply to all commands with "WONT", unless it is SGA (suppres go ahead)
                                int inputoption = this.client.GetStream().ReadByte();
                                if (inputoption == -1) break;
                                this.client.GetStream().WriteByte((byte)Verbs.IAC);
                                if (inputoption == (int)Options.SGA)
                                    this.client.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WILL : (byte)Verbs.DO);
                                else
                                    this.client.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WONT : (byte)Verbs.DONT);
                                this.client.GetStream().WriteByte((byte)inputoption);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        sb.Append((char)input);
                        break;
                }
            }
        }

        public string Read() {
            if (!this.client.Connected) return null;
            StringBuilder sb = new StringBuilder();
            do {
                ParseTelnet(sb);
                Thread.Sleep(400);
            } while (this.client.Available > 0);
            string s = sb.ToString();

            PropertyInfo log = this.obj.GetType().GetProperty(this.log_name);
            string data = (string)log.GetValue(this.obj, null);
            data += s;
            log.SetValue(this.obj, Convert.ChangeType(data, log.PropertyType), null);

            return s;
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
            if (this.client != null) this.client.Close();
        }

        public void Close() {
            if (this.client != null) this.client.Close();
        }


    }
}
