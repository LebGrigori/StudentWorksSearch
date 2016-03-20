using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StudentWorksSearch.Engines.DTO;

namespace StudentWorksSearch.Engines
{
    class APIEngine
    {
        const string Key = "af8335d256e4db6b20d7425e3821e1c6";

        public static void POST(string txt)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.text.ru");
            var content = new FormUrlEncodedContent(new[] {
            new KeyValuePair<string, string>("text", txt),
            new KeyValuePair<string, string>("userkey", Key),
            });

            var result = client.PostAsync("/post", content).Result;
            string resultContent = result.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<UID>(resultContent);
            Repository.UID = res.uid;
            GET(res.uid);
        }

        public static void GET(string uid)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.text.ru");
            var content = new FormUrlEncodedContent(new[] {
            new KeyValuePair<string, string>("uid", uid),
            new KeyValuePair<string, string>("userkey", Key),
            });

            var result = client.PostAsync("/post", content).Result;
            string resultContent = result.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<Plagiarism>(resultContent);
            double unique = res.uniq;
        }

    }
}
