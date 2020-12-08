using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace AcountService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        List<AccoundID> storeAccountbig = new List<AccoundID>();


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public class UsersRootObject
        {
            public User[] users { get; set; } // Array of users
        }

        // User class object
        public class User
        {
            public string username { get; set; }
            public string password { get; set; }
        }
        public bool AccountCreate(string username,string password)
        {
            User newUser = new User(); // User object for new user
            UsersRootObject usersObj = new UsersRootObject(); // Object of user
            List<User> usersList = new List<User>(); // List of users to read in existing data and add new users
            string json; // for the final JSON formatted list of users
            Boolean exists = false; // boolean value to check if the username exists
            Boolean created = false; // boolean value to return
            byte[] pwd; // byte array to store the encrypted password into
            string encryptedPass = ""; // string to store the encrypted password into


            string path = HttpRuntime.AppDomainAppPath + "\\user_credentials.json"; // File path to user credentials 
            //result = path;
            try
            {
                string jsonData = File.ReadAllText(path); // reads in the JSON file into a string

                usersObj = JsonConvert.DeserializeObject<UsersRootObject>(jsonData); // transfers jsonData to the usersObj

                if (usersObj.users != null) // makes sure that there is at least one existing user to iterate through accounts
                {
                    usersList = usersObj.users.ToList<User>(); // transfers users to a List<User>

                    foreach (User user in usersList) // iterates through the users
                    {
                        if (user.username == username) // checks if the username already exists
                        {
                            exists = true;
                        }
                    }
                }

                if (!exists) // If username doesn't already exist
                {
                    pwd = Encoding.ASCII.GetBytes(password); // Encrypts the password

                    // Loop converts byte array to a string
                    foreach (byte digit in pwd)
                    {
                        encryptedPass += digit;
                    }

                    newUser.username = username;
                    newUser.password = encryptedPass;
                    usersList.Add(newUser); // adds the new user to the user list

                    usersObj.users = usersList.ToArray<User>(); // Converts the list to a User object array
                    json = JsonConvert.SerializeObject(usersObj, Formatting.Indented); // Converts object to JSON string
                    File.WriteAllText(path, json); // Writes JSON data to the file

                    created = true;
                }
            }
            finally
            {

            }
            Console.WriteLine("check: " + path);
            return created; // Returns creation confirmation
        }

    }
        

    

  


}
