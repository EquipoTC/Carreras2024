using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    internal class APIRequests
    {
        
        public static string api_url = "https://carreras2024.onrender.com/";
        //Verbs
        public static async Task<string> GetHttp(string url, string api)
        {
            try
            {
                WebRequest request = WebRequest.Create(api + url);
                WebResponse response = request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                return await sr.ReadToEndAsync();
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }
}
