using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using baraba.Network;
using baraba.Commands;

namespace baraba
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug.Print("Hello!");

            while (true)
            {
                Thread.Sleep(10000);
            }
            
        }
    }
}
