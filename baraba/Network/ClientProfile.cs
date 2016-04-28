using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Management;
using System.Diagnostics;

namespace baraba.Network
{
    class ClientProfile
    {
        /// <summary>
        /// Get The Remote-ID Of This Client.
        /// </summary>
        public static string GetClientId()
        {
            string[] ClientInfo = {
                                      Environment.MachineName,
                                      Environment.UserName,
                                      GetOperatingSystemName()
                                  };
            MD5 Md5Hash = MD5.Create();
            // Create a new StringBuilder.
            StringBuilder StringBuilder = new StringBuilder();
            // Convert ClientInfo to md5.
            foreach (string Info in ClientInfo)
            {
                // Convert the Info to ByteArray and Compute the Hash.
                byte[] Data = Md5Hash.ComputeHash(Encoding.UTF8.GetBytes(Info));
                for (int i = 0; i < Data.Length; i++)
                {
                    StringBuilder.Append(Data[i].ToString("x2"));
                }
            }
            return StringBuilder.ToString();
        }

        /// <summary>
        /// Get Name Of Processor.
        /// </summary>
        public static string GetProcessorName()
        {
            return GetPropertyValue("Win32_Processor", "Name");
        }

        /// <summary>
        /// Get Name Of VideoController.
        /// </summary>
        public static string GetVideoControllerName()
        {
            return GetPropertyValue("Win32_VideoController", "Name");
        }

        /// <summary>
        /// Get Name Of OperatingSystem.
        /// </summary>
        public static string GetOperatingSystemName()
        {
            return GetPropertyValue("Win32_OperatingSystem", "Caption");
        }

        /// <summary>
        /// Get The Value Of A Property in System.Management.
        /// </summary>
        private static string GetPropertyValue(string Class, string Property)
        {
            string Output = String.Empty;
            // Create a new Instance
            ManagementClass MClass = new ManagementClass(Class);
            // Get PropertyCollection
            ManagementObjectCollection MCollection = MClass.GetInstances();
            // Search Property
            foreach (ManagementObject MObj in MCollection)
            {
                try
                {
                    // Return PropertyValue
                    Output = MObj[Property].ToString();
                }
                catch (Exception e)
                {
                    Debug.Print(e.StackTrace);
                }
            }
            return Output;
        }
    }
}
