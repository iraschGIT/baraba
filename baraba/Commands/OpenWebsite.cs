using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace baraba.Commands
{
    class OpenWebsite
    {
        /// <summary>
        /// Open A Webiste, Hidden Or Visible.
        /// </summary>
        public static void Perform(bool DoNotShow, string Url)
        {
            try
            {
                // Open Website Normal.
                if ((DoNotShow == false))
                    Process.Start(Url);
                // Open Webiste Hidden.
                else
                {
                    // Create a new Webbrowser.
                    WebBrowser WebBrowser = new WebBrowser();
                    // Navigate to Url.
                    WebBrowser.Navigate(Url);
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.StackTrace);
            }
        }
    }
}
