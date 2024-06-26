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
        const string api_url = "http://localhost:3000";
        //Verbs
        public static async Task<string> GetHttp(string url)
        {
            WebRequest request = WebRequest.Create(api_url + url);
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
    }
}
