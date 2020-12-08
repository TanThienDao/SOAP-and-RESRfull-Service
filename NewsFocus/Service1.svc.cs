using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using System.Net;

namespace NewsFocus
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string[] NewsForcusService (string[] text)
        {
            string apiKey2 = "FAB9BC417BFC4C1085C8101B6BAD9EF8";
            using (var webClient = new WebClient())
            {
                // get a string prevesentation of Json
                
                string[] result2 = null;
                List<JToken> resultList2 = new List<JToken>();
                List<string> listURL2 = new List<string>();
                for (int j = 0; j < text.Length; j++)
                {
                    string raw = webClient.DownloadString("https://api.scaleserp.com/search?api_key=" + apiKey2 + "&q=" + text[j] + "&hl=en&scholar_year_min=&scholar_year_max=&search_type=scholar&output=json");
                    JObject o2 = JObject.Parse(raw);
                    IEnumerable<JToken> linkurl2 = o2.SelectTokens("$.scholar_results[*].link");
                  
                    foreach (JToken item in linkurl2)
                    {
                        //Console.WriteLine(item);
                        resultList2.Add(item);
                        //listURL= (List<string>)resultList[0].s
                    }
                    for (int i = 0; i < resultList2.Count(); i++)
                    {
                        //Console.WriteLine(resultList[i]);
                        string value = resultList2[i].Value<string>().ToString();
                        listURL2.Add(value);
                        //listURL = (string[])resultList[i].Value<string>().ToList();
                        //result = resultList["scholar_results"][i].;

                    }
                    result2 = listURL2.ToArray();
                }
                return result2;
                
                string rawJson = webClient.DownloadString("https://api.scaleserp.com/search?api_key=" + apiKey2 + "&q=" + text[0] + "&hl=en&scholar_year_min=&scholar_year_max=&search_type=scholar&output=json");
                
                // do some computation 
                JObject o = JObject.Parse(rawJson);
                //JToken acme = o.SelectToken("$.scholar_results[*].link");
                IEnumerable<JToken> linkurl = o.SelectTokens("$.scholar_results[*].link");
                string[] result = null;
                List<JToken> resultList = new List<JToken>();
                List<string> listURL = new List<string>();
                foreach (JToken item in linkurl)
                {
                    //Console.WriteLine(item);
                    resultList.Add(item);
                    //listURL= (List<string>)resultList[0].s
                }
                for (int i = 0; i < resultList.Count(); i++)
                {
                    //Console.WriteLine(resultList[i]);
                    string value = resultList[i].Value<string>().ToString();
                    listURL.Add(value);
                    //listURL = (string[])resultList[i].Value<string>().ToList();
                    //result = resultList["scholar_results"][i].;

                }

                result = listURL.ToArray();
                //return result;
               


            }
        }
        
    }
}
