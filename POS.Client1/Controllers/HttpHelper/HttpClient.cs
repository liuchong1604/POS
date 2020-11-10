using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace POS.Client1.Controllers.HttpHelper
{
    public class HttpClient
    {
        public static JObject GetHttpResponse(string url, int timeout)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.Timeout = timeout;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream respStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(respStream, Encoding.GetEncoding("utf-8"));
            string retStr = reader.ReadToEnd();
            JObject json = JsonConvert.DeserializeObject(retStr) as JObject;
            return json;
        }
    }
}