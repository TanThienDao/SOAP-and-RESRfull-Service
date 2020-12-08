using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NaturalHazardsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        decimal NaturalHazards(decimal latitude, decimal longitude);

        [OperationContract]
        string[] NewsForcusService(string[] text);

        [OperationContract]
        string RainFall(string location);

        [OperationContract]
        bool AccontService(string username, string password);
        [OperationContract]
        bool[] LoginService(string username, string passowrd);



        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
}
