using AIBoxTestFunctionAsm.Asset.Global;
using AIBoxTestFunctionAsm.Commands;
using AIBoxTestFunctionAsm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using UtilityPack.IO;

namespace AIBoxTestFunctionAsm.ViewModels {
    public class SettingViewModel {

        public SettingViewModel() {

            //load setting file
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "setting.xml") == false) _sm = new SettingModel();
            else _sm = XmlHelper<SettingModel>.FromXmlFile(AppDomain.CurrentDomain.BaseDirectory + "setting.xml");
            _collection_dut_protocol = new CollectionView(new List<string>() { "Telnet", "SSH" });
            _collection_dhcp_protocol = new CollectionView(new List<string>() { "Telnet", "SSH" });
            SaveCommand = new SettingSaveCommand(this);
        }

        SettingModel _sm;
        public SettingModel SM {
            get => _sm;
        }

        CollectionView _collection_dut_protocol;
        public CollectionView collectionDutProtocol {
            get => _collection_dut_protocol;
        }

        CollectionView _collection_dhcp_protocol;
        public CollectionView collectionDhcpProtocol {
            get => _collection_dhcp_protocol;
        }

        //command
        public ICommand SaveCommand {
            get;
            private set;
        }

    }
}
