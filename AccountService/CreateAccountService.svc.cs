using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace AccountService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CreateAccountService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CreateAccountService.svc or CreateAccountService.svc.cs at the Solution Explorer and start debugging.
    public class CreateAccountService : ICreateAccountService
    {
        public bool AccontService(string username, string password)
        {
            bool createdAccount = false;// bool check if acount created
            bool exiteAccount = false; // bool check if account already created
            AccountUser newUser = new AccountUser(); // object for user create
            RootAccount_inJson RootJson = new RootAccount_inJson();
            List<AccountUser> ListAccount = new List<AccountUser>();
            string Json;
            EncryptDecrypService.ServiceClient proxyED = new EncryptDecrypService.ServiceClient(); // call the proxy service referrence

            String pathJson = HttpRuntime.AppDomainAppPath + "\\UserStoreDataJson.json"; // FInd the path for Json file that store User info
            //String pathJson = HttpContext.Current.Request.ApplicationPath;// ( @"\\UserStoreDataJson.json");
            try
            {
                string JsonData = File.ReadAllText(pathJson); // Read all data in Json file int to string
                RootJson = JsonConvert.DeserializeObject<RootAccount_inJson>(JsonData);// convert string data to Json root
                // check if there are exit account in the Root 
                if (RootJson.UsersArray != null)
                {
                    ListAccount = RootJson.UsersArray.ToList<AccountUser>();// teanser to a list of string for easy to convert and scan for check
                    foreach (AccountUser item in ListAccount)// scan the list account 
                    {
                        if (item.username == username) // find the username, mean account exit in the data.
                        {
                            exiteAccount = true;
                        }
                    }
                }
                // condition when account does not in the data then create new account.
                if (!exiteAccount) 
                {
                    string encrypted_password= proxyED.Encrypt(password); // encrypt the password by using encryp and derypt service on ASU server.
                    newUser.username = username;
                    //newUser.password = password;
                    newUser.password = encrypted_password;
                    ListAccount.Add(newUser); // add new user in the list 
                    RootJson.UsersArray = ListAccount.ToArray<AccountUser>(); // convert list to root object
                    Json = JsonConvert.SerializeObject(RootJson, Formatting.Indented); // write back to Json format 
                    File.WriteAllText(pathJson, Json); // write back to Json file store in system 
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
            public AccountUser[] UsersArray { get; set; } // array of account user for Json format, this Json root is a list.

        }

        // Service login that worh with acount create service. 
        public bool[] LoginService(string username,string password)
        {
            bool loginAccount = false;// bool check if login suceess 
            bool exiteAccount = false;// check if account is exit
            bool[] result=new bool[2];// return bool value as array size 2 
            AccountUser loginUser = new AccountUser(); // create object login user
            RootAccount_inJson RootJson = new RootAccount_inJson(); // create root array fot json
            List<AccountUser> ListAccount = new List<AccountUser>(); // create a list of account user for convert. 
            EncryptDecrypService.ServiceClient proxyED = new EncryptDecrypService.ServiceClient(); // call the proxy service from encrypt and decrpt
            String pathJson = HttpRuntime.AppDomainAppPath + "\\UserStoreDataJson.json"; // find the path for Json data file.
            string Json;
            try
            {
                string JsonData = File.ReadAllText(pathJson); // read the Json path  file to string
                RootJson = JsonConvert.DeserializeObject<RootAccount_inJson>(JsonData); //convert it to a array object of account user
                //check if the data is exits account. 
                if (RootJson.UsersArray != null)
                {
                    ListAccount = RootJson.UsersArray.ToList<AccountUser>(); // conver object root to list of acount user
                    foreach (AccountUser item in ListAccount)// scant throught the list 
                    {
                        if (item.username == username) // find the username 
                        {
                            exiteAccount = true; // turn on the acount exit
                            if(password == proxyED.Decrypt(item.password)) // check the the password it it correct by decrypt password.
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
            catch(Exception ec)
            {

            }
            result[0] = exiteAccount;
            result[1] = loginAccount;
            return result;
        }
       
    }
}
