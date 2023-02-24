using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Programmation_Systeme_Groupe_B.Model
{
    class Server
    {
        private static Socket socket;
        private static List<Socket> sockets = new List<Socket>();
        public static void SeConnecter()
        {
            if (socket is null)
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
                socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(localEndPoint);
                socket.Listen(1000);
            }
        }
        public static void AccepterConnexion(object obj)
        {
            while (true)
            {
                Trace.WriteLine("trying new connection");
                Socket newsocket = socket.Accept();
                //byte[] msg = Serialize(ModelClass.GetModelClass().ModelSave.Projects[0].miniProjects);
                //newsocket.Send(msg);
                sockets.Add(newsocket);
            }
        }
        public static void EcouterReseau()
        {

            byte[] bytes = new byte[1024];
            int rec;
            byte[] msg;
            string data;
            while (true)
            {
                try
                {
                    rec = socket.Receive(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, rec);
                    Console.WriteLine(data);

                    msg = Encoding.ASCII.GetBytes("Ok msg");
                    socket.Send(msg);
                }
                catch (Exception)
                {
                    ;
                }
            }
        }
        public static void SendMessage(object item)
        {
            byte[] msg = Serialize(item);
            if (sockets.Count == 0) return;
            foreach (Socket socket in sockets)
            {
                Trace.WriteLine("Message sent");
                lock (socket)
                {
                    socket.Send(msg);
                }
            }
        }
        public static void Deconnecter()
        {
            lock (socket)
            {
                socket.Disconnect(false);
            }
        }
        public static byte[] Serialize(object anySerializableObject)
        {
            var stringMessage = JsonConvert.SerializeObject(anySerializableObject, Formatting.None);
            var bytes = Encoding.UTF8.GetBytes(stringMessage);
            return bytes;
            /*
            using (var memoryStream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(memoryStream, anySerializableObject);
                return memoryStream.ToArray();
            }
            */
        }
    }
}