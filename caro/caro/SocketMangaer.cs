﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace caro
{
    class SocketMangaer
    {
        public string IP = "127.0.0.1";
        public int PORT = 9999;
        public const int BUFFER = 1024;
        public bool isServer = true;

        Socket server;
        Socket client = null;
        #region server
        public void CreateServer(out bool kq )
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            try
            {

                server.Bind(ep);
                server.Listen(10);
                
            }
            catch
            {
                kq = false;
                return;
            }
        
            kq = true;
            try
            {
                Thread acceptClient = new Thread(() =>
                {
                    try
                    {
                        client = server.Accept();
                    }
                    catch
                    {

                    }
                });
                acceptClient.IsBackground = true;
                acceptClient.Start();
            }
            catch (Exception)
            {
                throw;
            }
        
        }
        public bool HasClient()
        {
            return client.Connected;

        }
        #endregion


        #region  client

        public bool ConnectServer()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), PORT);

            try
            {
                client.Connect(ep);
                isServer = false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        #endregion
        #region Both


        public void SendData(object data )
        {
            byte[] dataByteArray = SerializeData(data);
            try
            {
                client.Send(dataByteArray);
            }
            catch
            {

            }
        }

        public object ReceiveData()
        {
            byte[] receiveData = new byte[BUFFER];
            client.Receive(receiveData);
            return DeserializeData(receiveData); 
        }
   
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }
        public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }

        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }

        internal void Close()
        {
            if (this.server != null) this.server.Close();
            if (this.client != null) this.client.Close();
        }

        internal void CloseClient()
        {
            if (this.client != null) this.client.Close();
        }

        #endregion
    }
}
