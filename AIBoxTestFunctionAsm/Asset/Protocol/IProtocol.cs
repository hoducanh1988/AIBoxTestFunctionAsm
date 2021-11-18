using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBoxTestFunctionAsm.Asset.Protocol {
    public interface IProtocol {

        bool IsConnected { get; set; }
        bool Login(string ip, string user, string password, string data_success);
        bool Write(string cmd);
        bool WriteLine(string cmd);
        string Read();
        string Query(string cmd, int delay_time);
        bool Query(string cmd, string pattern, int timeout_ms, out string data_feedback);
        bool Query(string cmd, string pattern, int timeout_ms, int retry_time, out string data_feedback);
        void Disconnect();
        void Close();
    }
}
