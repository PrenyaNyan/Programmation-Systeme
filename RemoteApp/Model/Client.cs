using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json.Bson;
using Rebus.Messages;
using Newtonsoft.Json;

namespace RemoteApp.Model
{

    class Client
    {
        public static Socket Socket;
        public static void SeConnecter()
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
            Socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Trace.WriteLine("Waiting for connection");
            Socket.Connect(remoteEP);
            Trace.WriteLine("Connection done client");
        }
        public static void Communiquer(object obj)
        {
            Console.WriteLine("Socket connected to {0}", Socket.RemoteEndPoint.ToString());
            byte[] bytes = new byte[1024];
            while (true)
            {
                // Receive the response from the remote device.
                Socket.Receive(bytes);
                Trace.WriteLine("message reçu");
                var msg = Deserialize(bytes);
                if (msg is List<MiniProject>)
                {
                    ViewModels.ViewModel.vm.Items.Add(msg as MiniProject);
                }
            }
        }
        public static object Deserialize(byte[] message)
        {
            string result = System.Text.Encoding.UTF8.GetString(message);
            var proj = JsonConvert.DeserializeObject<MiniProject>(result);
            return proj;
/*            using (var memoryStream = new MemoryStream(message))
            {
                BinaryFormatter b = new BinaryFormatter();
                memoryStream.Seek(0, SeekOrigin.Begin);

                MiniProject proj = b.Deserialize(memoryStream) as MiniProject;
                return proj;
            }*/
        }
    }
}
