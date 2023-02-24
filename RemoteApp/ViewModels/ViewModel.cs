using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RemoteApp.Model;
namespace RemoteApp.ViewModels
{
    class ViewModel : ViewModelBase
    {
        private List<MiniProject> _items = new List<MiniProject>();
        public List<MiniProject> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }
        public Thread remoteConnect { get; set; }
        Client client;
        public static ViewModel vm;
        public ViewModel()
        {
            vm = this;
            Client.SeConnecter();
            Items.Add(new MiniProject() { name = "test", progression = "50", state = "running" });

            remoteConnect = new Thread(new ParameterizedThreadStart(Client.Communiquer));
            remoteConnect.Start();
        }
    }
}
