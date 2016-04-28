using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baraba.Commands
{
    class EditConfig
    {
        /// <summary>
        /// Edit Application Config.
        /// </summary>
        public static void Perform(string Parameter, string Value)
        {
            // Create a new Instance of Application Setiings.
            Properties.Settings Config = new Properties.Settings();
            if ((Parameter.ToLower() == "webserver"))
                Config.WebServer = Value;
            else
                Config.MasterID = Value;
            // Save Config.
            Config.Save();
            // Restart Computer.
            Shutdown.Perform("restart", 0);
        }
    }
}
