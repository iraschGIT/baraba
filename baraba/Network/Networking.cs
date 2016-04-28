using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace baraba.Network
{
    class Networking
    {
        /// <summary>
        /// Return ResponseStream Of A Request.
        /// </summary>
        public static string GetResponse(string Url)
        {
            string Output = String.Empty;
            try
            {
                // Create Request.
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Url);
                // Set the UserAgent for this Request.
                Request.UserAgent = "baraba";
                // Set the ContentType for this Request.
                Request.ContentType = "application/x-www-form-urlencoded";
                // Get Response.
                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                // Read ResponseStream.
                StreamReader ResponseStreamReader = new StreamReader(Response.GetResponseStream());
                // Return ResponseStream.
                Output = ResponseStreamReader.ReadToEnd();
                Debug.Print("Received Data: " + Output);              
            }
            catch (Exception e) 
            {
                Debug.Print(e.StackTrace);
            }
            return Output;
        }
        /// <summary>
        /// Send A HttpWebRequest And Return ResponseStream.
        /// </summary>
        public static string SendRequest(string Method, string Url, string Values)
        {
            string Output = String.Empty;
            // Convert Values to ByteArray
            byte[] Data = Encoding.UTF8.GetBytes(Values);
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Url);
                // Set the UserAgent for this Request.
                Request.UserAgent = "baraba";
                // Set the RequestMethod for this Request.
                Request.Method = Method;
                // Set the ContentType for this Request.
                Request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength for this Request.
                Request.ContentLength = Data.Length;
                // Get RequestStream.
                Stream RequestStream = Request.GetRequestStream();
                // Write into RequestStream.
                RequestStream.Write(Data, 0, Data.Length);
                // Close RequestStream.
                RequestStream.Close();
                // Get Response of Request.
                HttpWebResponse Respose = (HttpWebResponse)Request.GetResponse();
                // Read ResponseStream.
                StreamReader ResponseStreamReader = new StreamReader(Respose.GetResponseStream());
                // Return ResponseStream.
                Output = ResponseStreamReader.ReadToEnd();
            }
            catch (Exception e)
            {
                Debug.Print(e.StackTrace);
            }
            return Output;
        }
    }
}
