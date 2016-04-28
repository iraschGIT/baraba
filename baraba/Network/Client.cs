using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace baraba.Network
{
    class Client
    {
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
                // Wait ...
                Thread.Sleep(ReceiveSpeed);
            }
        }
    }
}
