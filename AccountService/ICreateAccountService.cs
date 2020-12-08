using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AccountService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICreateAccountService" in both code and config file together.
    [ServiceContract]
    public interface ICreateAccountService
    {
        [OperationContract]
        bool AccontService(string username, string password);
        [OperationContract]
        bool[] LoginService(string username, string passowrd);
    }
}
