using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace baraba.Commands
{
    class Shutdown
    {
        /// <summary>
        /// Shutdown Computer.
        /// </summary>
        public static void Perform(string mode, int time)
        {
            string[] Args = { null, null };
            // Detect Shutdown mode.
            Args[0] = Convert.ToString(mode.ToLower()[0]);
            Args[1] = Convert.ToString(time);
            // Execute.
            Process.Start("shutdown", "/" + Args[0] + " /t " + Args[1]);
        }
    }
}
