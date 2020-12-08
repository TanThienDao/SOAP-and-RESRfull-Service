using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace AcountService
{
    public class AccoundID
    {
        
        private string _password;
        private string _email;
        private string _username;

       

        public string UserName { get=>_username; set=> _username=value; }
        public string Password { get => _password; set => _password = value; }
        public string Email { get => _email; set => _email = value; }



    }
}