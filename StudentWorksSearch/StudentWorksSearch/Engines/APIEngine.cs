using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StudentWorksSearch.Engines
{
    class APIEngine
    {
        const string PostURL = "http://api.text.ru/post";
        const string Key = "af8335d256e4db6b20d7425e3821e1c6"; 

        //public void POST(string txt)
        //{
        //    using (var webClient = new WebClient())
        //    {
        //        var pars = new NameValueCollection();
        //        pars.Add(txt, Key);

        //        var response = webClient.UploadValues(PostURL, pars);

        //        List<byte> UNIList = new List<byte>();
        //        UNIList = response.Select(a => a).ToList();
        //    }
        //}

        //private string GET(string Url, string Data)
        //{
        //    WebRequest req = WebRequest.Create(Url + "?" + Data);
        //    WebResponse resp = req.GetResponse();
        //    Stream stream = resp.GetResponseStream();
        //    StreamReader sr = new StreamReader(stream);
        //    string Out = sr.ReadToEnd();
        //    sr.Close();
        //    return Out;
        //}
    }
}
