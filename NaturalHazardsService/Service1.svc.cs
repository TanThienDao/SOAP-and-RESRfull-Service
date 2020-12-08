using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Web;
using System.IO;

namespace NaturalHazardsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        // Service will take latitude and longtitude then return number of earthquake incident happen from 1917 to present day.
        public decimal NaturalHazards(decimal latitude, decimal longitude)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd"); // put today to a string 
            Decimal Incident = 0m;
            string URL = "https://earthquake.usgs.gov/fdsnws/event/1/count?starttime=1917-09-23&endtime=" + today + 
                "&latitude=" + latitude + "&longitude=" + longitude 
                + "&maxradiuskm=100&minmagnitude=2.5&eventtype=earthquake&orderby=time";

            var result = "";
            // scan the web content 
            using(WebClient client = new WebClient())
            {
                // get string preventasion from json 
                result = client.DownloadString(URL); // convert to var
            }
            Incident = Convert.ToDecimal(result);// convert to ecimal
            return Incident;
        }

        // Service will take a list of topic need to search then return all the article in google scholar.
        public string[] NewsForcusService(string[] text)
        {
            string apiKey2 = "FAB9BC417BFC4C1085C8101B6BAD9EF8";
            // scan data from the web
            using (var webClient = new WebClient())
            {
                // get a string prevesentation of Json

                string[] result2 = null;
                List<JToken> resultList2 = new List<JToken>(); // create list of Jtoken 
                List<string> listURL2 = new List<string>();// create list of string
                //scant the topic need to search
                for (int j = 0; j < text.Length; j++)
                {
                    // get Json from the API
                    string raw = webClient.DownloadString("https://api.scaleserp.com/search?api_key=" + apiKey2 + "&q=" + text[j] + "&hl=en&scholar_year_min=&scholar_year_max=&search_type=scholar&output=json");
                    JObject o2 = JObject.Parse(raw);// parse Json
                    IEnumerable<JToken> linkurl2 = o2.SelectTokens("$.scholar_results[*].link"); // get data from the root Json to list of article URL

                    //scan the Json and convert it to list of Json token
                    foreach (JToken item in linkurl2)
                    {
                        //Console.WriteLine(item);
                        resultList2.Add(item);
                        //listURL= (List<string>)resultList[0].s
                    }
                    // scan list of Json token and convert to list of string 
                    for (int i = 0; i < resultList2.Count(); i++)
                    {
                        //Console.WriteLine(resultList[i]);
                        string value = resultList2[i].Value<string>().ToString();
                        listURL2.Add(value);
                        //listURL = (string[])resultList[i].Value<string>().ToList();
                        //result = resultList["scholar_results"][i].;

                    }

                    result2 = listURL2.ToArray(); // convert list t array result
                }
                return result2;
            }
        }

        public string RainFall(string mesa)
        {
           // create a list of lat and ling Jtoken
            List<JToken> resultLat = new List<JToken>();
            List<JToken> resultLon = new List<JToken>();
            // create string to convert
            string valueLat, valueLon;
            // user the API get lat and long throught input the name of location
            using (var webClient = new WebClient())
            {
                // pass the Json to string
                string rawJson = webClient.DownloadString("https://us1.locationiq.com/v1/search.php?key=pk.47949e1ce291671dd62dfe28bcb79af6&q="+mesa+"&format=json");
                JArray a = JArray.Parse(rawJson);//parse the Json
                // get the lat and long from Json path
                IEnumerable<JToken> linkurlLat = a.SelectTokens("$.[0].lat");
                IEnumerable<JToken> linkurlLon = a.SelectTokens("$.[0].lat");
                // convert link lat and long to list of Jtoken
                foreach(JToken item in linkurlLat)
                {
                    resultLat.Add(item);
                }
                foreach (JToken item in linkurlLon)
                {
                    resultLon.Add(item);
                }
                //take the fist lat and long and convert to a string
                 valueLat = resultLat[0].Value<string>().ToString();
                 valueLon = resultLon[0].Value<string>().ToString();

            }

            string result="";
            List<JToken> resultList = new List<JToken>();
            // scan through the web service take lat and long for location
            using (var webClient = new WebClient())
            {
               
                string rawJson = webClient.DownloadString("https://api.openweathermap.org/data/2.5/onecall?lat="
                    + valueLat + "&lon="+ valueLon + "&exclude=hourly,daily,alerts&appid=4e1823bac65fa3a2fd1c9468a2931b36");

                // Steps to convert a raw Json then parse then take the excalt path you want by useing Json path code.
                JObject o = JObject.Parse(rawJson);
                IEnumerable<JToken> linkurl = o.SelectTokens("$.current.weather[*].description");
                //JToken token = o.SelectToken("$.current.weather[*].description");

                // scan and convert t to list of JToken then convert to lsit if string for use
                foreach (JToken item in linkurl)
                {
                    resultList.Add(item);
                }
                for (int i = 0; i < resultList.Count(); i++)
                {
                    string value = resultList[i].Value<string>().ToString(); // conert the value to string.
                    result = value; // get the string from for lop to local string

                }

            }

                return result;
        }

        // account service input username and passwor and return bool value.
        public bool AccontService(string username, string password)
        {
            bool createdAccount = false; //bool check if acount created
            bool exiteAccount = false;// bool check if account already created
            AccountUser newUser = new AccountUser();// object for user create
            RootAccount_inJson RootJson = new RootAccount_inJson();
            List<AccountUser> ListAccount = new List<AccountUser>();
            string Json;
            EncryptDecrypService.ServiceClient proxyED = new EncryptDecrypService.ServiceClient();// call the proxy service referrence

            String pathJson = HttpRuntime.AppDomainAppPath + "\\UserStoreDataJson.json"; // FInd the path for Json file that store User infos
            //String pathJson = HttpContext.Current.Request.ApplicationPath;// ( @"\\UserStoreDataJson.json");
            try
            {
                string JsonData = File.ReadAllText(pathJson);// Read all data in Json file int to string
                RootJson = JsonConvert.DeserializeObject<RootAccount_inJson>(JsonData);// convert string data to Json root
                // check if there are exit account in the Root 
                if (RootJson.UsersArray != null)
                {
                    ListAccount = RootJson.UsersArray.ToList<AccountUser>();// teanser to a list of string for easy to convert and scan for check
                    foreach (AccountUser item in ListAccount)// scan the list account
                    {
                        if (item.username == username)// find the username, mean account exit in the data.
                        {
                            exiteAccount = true;
                        }
                    }
                }
                // condition when account does not in the data then create new account.
                if (!exiteAccount)
                {
                    string encrypted_password = proxyED.Encrypt(password);// encrypt the password by using encryp and derypt service on ASU server.
                    newUser.username = username;
                    //newUser.password = password;
                    newUser.password = encrypted_password;
                    ListAccount.Add(newUser);// add new user in the list
                    RootJson.UsersArray = ListAccount.ToArray<AccountUser>();// convert list to root object
                    Json = JsonConvert.SerializeObject(RootJson, Formatting.Indented);// write back to Json format 
                    File.WriteAllText(pathJson, Json);// write back to Json file store in system 
                    createdAccount = true;
                }


            }
            catch (Exception ec) { }
            return createdAccount;
        }
        // a class of account usert have user name and password
        public class AccountUser
        {
            public string username { get; set; }
            public string password { get; set; }
        }
        // a class for Json file roon this is an array of Joson.
        public class RootAccount_inJson
        {
            public AccountUser[] UsersArray { get; set; }// array of account user for Json format, this Json root is a list.

        }
        // Service login that worh with acount create service. 
        public bool[] LoginService(string username, string password)
        {
            bool loginAccount = false;// bool check if login suceess 
            bool exiteAccount = false;// check if account is exit
            bool[] result = new bool[2];// return bool value as array size 2 
            AccountUser loginUser = new AccountUser();// create object login user
            RootAccount_inJson RootJson = new RootAccount_inJson();// create root array fot json
            List<AccountUser> ListAccount = new List<AccountUser>();// create a list of account user for convert.
            EncryptDecrypService.ServiceClient proxyED = new EncryptDecrypService.ServiceClient();// call the proxy service from encrypt and decrpt
            String pathJson = HttpRuntime.AppDomainAppPath + "\\UserStoreDataJson.json";// find the path for Json data file.
            string Json;
            try
            {
                string JsonData = File.ReadAllText(pathJson);// read the Json path  file to string
                RootJson = JsonConvert.DeserializeObject<RootAccount_inJson>(JsonData); //convert it to a array object of account user
                //check if the data is exits account. 
                if (RootJson.UsersArray != null)
                {
                    ListAccount = RootJson.UsersArray.ToList<AccountUser>();// conver object root to list of acount user
                    foreach (AccountUser item in ListAccount)// scant throught the list 
                    {
                        if (item.username == username)// find the username 
                        {
                            exiteAccount = true;// turn on the acount exit
                            if (password == proxyED.Decrypt(item.password))// check the the password it it correct by decrypt password.
                            {
                                loginAccount = true;
                            }
                            else
                            {
                                loginAccount = false;
                            }
                        }
                    }
                }



            }
            catch (Exception ec)
            {

            }
            result[0] = exiteAccount;
            result[1] = loginAccount;
            return result;
        }








    }
}
