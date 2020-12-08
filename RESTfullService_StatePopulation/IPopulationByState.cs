using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace RESTfullService_StatePopulation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPopulationByState" in both code and config file together.
    [ServiceContract]
    public interface IPopulationByState
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Population?state={state}", ResponseFormat = WebMessageFormat.Json)]
        int StatePopulation(string state);
    }
}
