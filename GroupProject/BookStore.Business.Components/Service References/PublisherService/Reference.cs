﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStore.Business.Components.PublisherService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PublisherService.IPublisherService")]
    public interface IPublisherService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPublisherService/Publish")]
        void Publish(Common.Model.Message pMessage);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPublisherService/Publish")]
        System.Threading.Tasks.Task PublishAsync(Common.Model.Message pMessage);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPublisherServiceChannel : BookStore.Business.Components.PublisherService.IPublisherService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PublisherServiceClient : System.ServiceModel.ClientBase<BookStore.Business.Components.PublisherService.IPublisherService>, BookStore.Business.Components.PublisherService.IPublisherService {
        
        public PublisherServiceClient() {
        }
        
        public PublisherServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PublisherServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PublisherServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PublisherServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Publish(Common.Model.Message pMessage) {
            base.Channel.Publish(pMessage);
        }
        
        public System.Threading.Tasks.Task PublishAsync(Common.Model.Message pMessage) {
            return base.Channel.PublishAsync(pMessage);
        }
    }
}
