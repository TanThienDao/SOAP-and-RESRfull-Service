using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net;
using System.Resources;

namespace RESTfullService_StatePopulation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PopulationByState" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PopulationByState.svc or PopulationByState.svc.cs at the Solution Explorer and start debugging.
    public class PopulationByState : IPopulationByState
    {
        public int StatePopulation(string state)
        {
           
            string apiKey = "130354eeb79d8f3db96cd91a92eb00304368a6c2";
            string web = "https://api.census.gov/data/2019/pep/population?get=NAME,POP&for=state:*&key=";
            string result;
            // case check stuff got GUI later in try itpage.
            if (state == null)
            {
                // if result rethrn 666 mean you did not type and leave the string state is null
                return 666;
            }
            else if(state.Length==0)
            {
                // if result is 555 then that mean you delete the null and not type anything.
                return 555;
            }
            else 
            {
                string check = char.ToUpper(state[0]) + state.Substring(1).ToLower();
                state = check;
            }
            try
            {
                using (var webClient = new WebClient())
                {
                    string rawJson = webClient.DownloadString(web + apiKey);
                    JArray ob = JArray.Parse(rawJson);
                    IEnumerable<JToken> states = ob.SelectTokens("$.[*].[0]");
                    List<JToken> ListState = new List<JToken>();
                    List<JToken> population = new List<JToken>();
                    foreach (var item in states)
                    {
                        ListState.Add(item);
                    }
                    int count = 0;
                    for (int i = 0; i < ListState.Count(); i++)
                    {
                        string value = ListState[i].Value<string>().ToString();
                        if (value == state)
                        {
                            count = i;
                        }

                    }

                    IEnumerable<JToken> statefind = ob.SelectTokens("$.[" + count.ToString() + "].[1]");
                    foreach (var item in statefind)
                    {
                        population.Add(item);
                    }
                    result = population[0].Value<int>().ToString();

                }
                int final = Int32.Parse(result);

                return final;
            }
            catch(Exception ec)
            {
                return 444;// return error input wrong !
            }
        }
    }
}
