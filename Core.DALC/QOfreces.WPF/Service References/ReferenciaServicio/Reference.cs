﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QOfreces.WPF.ReferenciaServicio {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReferenciaServicio.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ValidarUsuarioWeb", ReplyAction="http://tempuri.org/IService1/ValidarUsuarioWebResponse")]
        bool ValidarUsuarioWeb(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ValidarUsuarioWeb", ReplyAction="http://tempuri.org/IService1/ValidarUsuarioWebResponse")]
        System.Threading.Tasks.Task<bool> ValidarUsuarioWebAsync(string username, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : QOfreces.WPF.ReferenciaServicio.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<QOfreces.WPF.ReferenciaServicio.IService1>, QOfreces.WPF.ReferenciaServicio.IService1 {
        
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
        
        public bool ValidarUsuarioWeb(string username, string password) {
            return base.Channel.ValidarUsuarioWeb(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> ValidarUsuarioWebAsync(string username, string password) {
            return base.Channel.ValidarUsuarioWebAsync(username, password);
        }
    }
}
