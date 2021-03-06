﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TryitPageA6.CombineSoapService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CombineSoapService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/NaturalHazards", ReplyAction="http://tempuri.org/IService1/NaturalHazardsResponse")]
        decimal NaturalHazards(decimal latitude, decimal longitude);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/NaturalHazards", ReplyAction="http://tempuri.org/IService1/NaturalHazardsResponse")]
        System.Threading.Tasks.Task<decimal> NaturalHazardsAsync(decimal latitude, decimal longitude);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/NewsForcusService", ReplyAction="http://tempuri.org/IService1/NewsForcusServiceResponse")]
        string[] NewsForcusService(string[] text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/NewsForcusService", ReplyAction="http://tempuri.org/IService1/NewsForcusServiceResponse")]
        System.Threading.Tasks.Task<string[]> NewsForcusServiceAsync(string[] text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RainFall", ReplyAction="http://tempuri.org/IService1/RainFallResponse")]
        string RainFall(string location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RainFall", ReplyAction="http://tempuri.org/IService1/RainFallResponse")]
        System.Threading.Tasks.Task<string> RainFallAsync(string location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AccontService", ReplyAction="http://tempuri.org/IService1/AccontServiceResponse")]
        bool AccontService(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AccontService", ReplyAction="http://tempuri.org/IService1/AccontServiceResponse")]
        System.Threading.Tasks.Task<bool> AccontServiceAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/LoginService", ReplyAction="http://tempuri.org/IService1/LoginServiceResponse")]
        bool[] LoginService(string username, string passowrd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/LoginService", ReplyAction="http://tempuri.org/IService1/LoginServiceResponse")]
        System.Threading.Tasks.Task<bool[]> LoginServiceAsync(string username, string passowrd);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TryitPageA6.CombineSoapService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TryitPageA6.CombineSoapService.IService1>, TryitPageA6.CombineSoapService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public decimal NaturalHazards(decimal latitude, decimal longitude) {
            return base.Channel.NaturalHazards(latitude, longitude);
        }
        
        public System.Threading.Tasks.Task<decimal> NaturalHazardsAsync(decimal latitude, decimal longitude) {
            return base.Channel.NaturalHazardsAsync(latitude, longitude);
        }
        
        public string[] NewsForcusService(string[] text) {
            return base.Channel.NewsForcusService(text);
        }
        
        public System.Threading.Tasks.Task<string[]> NewsForcusServiceAsync(string[] text) {
            return base.Channel.NewsForcusServiceAsync(text);
        }
        
        public string RainFall(string location) {
            return base.Channel.RainFall(location);
        }
        
        public System.Threading.Tasks.Task<string> RainFallAsync(string location) {
            return base.Channel.RainFallAsync(location);
        }
        
        public bool AccontService(string username, string password) {
            return base.Channel.AccontService(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> AccontServiceAsync(string username, string password) {
            return base.Channel.AccontServiceAsync(username, password);
        }
        
        public bool[] LoginService(string username, string passowrd) {
            return base.Channel.LoginService(username, passowrd);
        }
        
        public System.Threading.Tasks.Task<bool[]> LoginServiceAsync(string username, string passowrd) {
            return base.Channel.LoginServiceAsync(username, passowrd);
        }
    }
}
