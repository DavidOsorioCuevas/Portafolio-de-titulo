﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QOfreces.WPF.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ValidarUsuarioWPF", ReplyAction="http://tempuri.org/IService1/ValidarUsuarioWPFResponse")]
        bool ValidarUsuarioWPF(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ValidarUsuarioWPF", ReplyAction="http://tempuri.org/IService1/ValidarUsuarioWPFResponse")]
        System.Threading.Tasks.Task<bool> ValidarUsuarioWPFAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/LeerUsuario", ReplyAction="http://tempuri.org/IService1/LeerUsuarioResponse")]
        string LeerUsuario(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/LeerUsuario", ReplyAction="http://tempuri.org/IService1/LeerUsuarioResponse")]
        System.Threading.Tasks.Task<string> LeerUsuarioAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrearUsuario", ReplyAction="http://tempuri.org/IService1/CrearUsuarioResponse")]
        bool CrearUsuario(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrearUsuario", ReplyAction="http://tempuri.org/IService1/CrearUsuarioResponse")]
        System.Threading.Tasks.Task<bool> CrearUsuarioAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarUsuario", ReplyAction="http://tempuri.org/IService1/EliminarUsuarioResponse")]
        bool EliminarUsuario(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarUsuario", ReplyAction="http://tempuri.org/IService1/EliminarUsuarioResponse")]
        System.Threading.Tasks.Task<bool> EliminarUsuarioAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarUsuario", ReplyAction="http://tempuri.org/IService1/ActualizarUsuarioResponse")]
        bool ActualizarUsuario(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarUsuario", ReplyAction="http://tempuri.org/IService1/ActualizarUsuarioResponse")]
        System.Threading.Tasks.Task<bool> ActualizarUsuarioAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/LeerId", ReplyAction="http://tempuri.org/IService1/LeerIdResponse")]
        string LeerId(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/LeerId", ReplyAction="http://tempuri.org/IService1/LeerIdResponse")]
        System.Threading.Tasks.Task<string> LeerIdAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAll", ReplyAction="http://tempuri.org/IService1/ReadAllResponse")]
        string ReadAll(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAll", ReplyAction="http://tempuri.org/IService1/ReadAllResponse")]
        System.Threading.Tasks.Task<string> ReadAllAsync(string json);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : QOfreces.WPF.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<QOfreces.WPF.ServiceReference1.IService1>, QOfreces.WPF.ServiceReference1.IService1 {
        
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
        
        public bool ValidarUsuarioWPF(string username, string password) {
            return base.Channel.ValidarUsuarioWPF(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> ValidarUsuarioWPFAsync(string username, string password) {
            return base.Channel.ValidarUsuarioWPFAsync(username, password);
        }
        
        public string LeerUsuario(string json) {
            return base.Channel.LeerUsuario(json);
        }
        
        public System.Threading.Tasks.Task<string> LeerUsuarioAsync(string json) {
            return base.Channel.LeerUsuarioAsync(json);
        }
        
        public bool CrearUsuario(string json) {
            return base.Channel.CrearUsuario(json);
        }
        
        public System.Threading.Tasks.Task<bool> CrearUsuarioAsync(string json) {
            return base.Channel.CrearUsuarioAsync(json);
        }
        
        public bool EliminarUsuario(string json) {
            return base.Channel.EliminarUsuario(json);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarUsuarioAsync(string json) {
            return base.Channel.EliminarUsuarioAsync(json);
        }
        
        public bool ActualizarUsuario(string json) {
            return base.Channel.ActualizarUsuario(json);
        }
        
        public System.Threading.Tasks.Task<bool> ActualizarUsuarioAsync(string json) {
            return base.Channel.ActualizarUsuarioAsync(json);
        }
        
        public string LeerId(string json) {
            return base.Channel.LeerId(json);
        }
        
        public System.Threading.Tasks.Task<string> LeerIdAsync(string json) {
            return base.Channel.LeerIdAsync(json);
        }
        
        public string ReadAll(string json) {
            return base.Channel.ReadAll(json);
        }
        
        public System.Threading.Tasks.Task<string> ReadAllAsync(string json) {
            return base.Channel.ReadAllAsync(json);
        }
    }
}
