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
        string ReadAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAll", ReplyAction="http://tempuri.org/IService1/ReadAllResponse")]
        System.Threading.Tasks.Task<string> ReadAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAllProductos", ReplyAction="http://tempuri.org/IService1/ReadAllProductosResponse")]
        string ReadAllProductos(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAllProductos", ReplyAction="http://tempuri.org/IService1/ReadAllProductosResponse")]
        System.Threading.Tasks.Task<string> ReadAllProductosAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrearRubro", ReplyAction="http://tempuri.org/IService1/CrearRubroResponse")]
        bool CrearRubro(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrearRubro", ReplyAction="http://tempuri.org/IService1/CrearRubroResponse")]
        System.Threading.Tasks.Task<bool> CrearRubroAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarRubro", ReplyAction="http://tempuri.org/IService1/ActualizarRubroResponse")]
        bool ActualizarRubro(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarRubro", ReplyAction="http://tempuri.org/IService1/ActualizarRubroResponse")]
        System.Threading.Tasks.Task<bool> ActualizarRubroAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarRubro", ReplyAction="http://tempuri.org/IService1/EliminarRubroResponse")]
        bool EliminarRubro(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarRubro", ReplyAction="http://tempuri.org/IService1/EliminarRubroResponse")]
        System.Threading.Tasks.Task<bool> EliminarRubroAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarDesc", ReplyAction="http://tempuri.org/IService1/ActualizarDescResponse")]
        bool ActualizarDesc(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarDesc", ReplyAction="http://tempuri.org/IService1/ActualizarDescResponse")]
        System.Threading.Tasks.Task<bool> ActualizarDescAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarDesc", ReplyAction="http://tempuri.org/IService1/EliminarDescResponse")]
        bool EliminarDesc(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarDesc", ReplyAction="http://tempuri.org/IService1/EliminarDescResponse")]
        System.Threading.Tasks.Task<bool> EliminarDescAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarRetail", ReplyAction="http://tempuri.org/IService1/ActualizarRetailResponse")]
        bool ActualizarRetail(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarRetail", ReplyAction="http://tempuri.org/IService1/ActualizarRetailResponse")]
        System.Threading.Tasks.Task<bool> ActualizarRetailAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarRetail", ReplyAction="http://tempuri.org/IService1/EliminarRetailResponse")]
        bool EliminarRetail(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarRetail", ReplyAction="http://tempuri.org/IService1/EliminarRetailResponse")]
        System.Threading.Tasks.Task<bool> EliminarRetailAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarProducto", ReplyAction="http://tempuri.org/IService1/ActualizarProductoResponse")]
        bool ActualizarProducto(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarProducto", ReplyAction="http://tempuri.org/IService1/ActualizarProductoResponse")]
        System.Threading.Tasks.Task<bool> ActualizarProductoAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarProducto", ReplyAction="http://tempuri.org/IService1/EliminarProductoResponse")]
        bool EliminarProducto(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarProducto", ReplyAction="http://tempuri.org/IService1/EliminarProductoResponse")]
        System.Threading.Tasks.Task<bool> EliminarProductoAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarOferta", ReplyAction="http://tempuri.org/IService1/ActualizarOfertaResponse")]
        bool ActualizarOferta(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarOferta", ReplyAction="http://tempuri.org/IService1/ActualizarOfertaResponse")]
        System.Threading.Tasks.Task<bool> ActualizarOfertaAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarOferta", ReplyAction="http://tempuri.org/IService1/EliminarOfertaResponse")]
        bool EliminarOferta(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarOferta", ReplyAction="http://tempuri.org/IService1/EliminarOfertaResponse")]
        System.Threading.Tasks.Task<bool> EliminarOfertaAsync(string json);
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
        
        public string ReadAll() {
            return base.Channel.ReadAll();
        }
        
        public System.Threading.Tasks.Task<string> ReadAllAsync() {
            return base.Channel.ReadAllAsync();
        }
        
        public string ReadAllProductos(string json) {
            return base.Channel.ReadAllProductos(json);
        }
        
        public System.Threading.Tasks.Task<string> ReadAllProductosAsync(string json) {
            return base.Channel.ReadAllProductosAsync(json);
        }
        
        public bool CrearRubro(string json) {
            return base.Channel.CrearRubro(json);
        }
        
        public System.Threading.Tasks.Task<bool> CrearRubroAsync(string json) {
            return base.Channel.CrearRubroAsync(json);
        }
        
        public bool ActualizarRubro(string json) {
            return base.Channel.ActualizarRubro(json);
        }
        
        public System.Threading.Tasks.Task<bool> ActualizarRubroAsync(string json) {
            return base.Channel.ActualizarRubroAsync(json);
        }
        
        public bool EliminarRubro(string json) {
            return base.Channel.EliminarRubro(json);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarRubroAsync(string json) {
            return base.Channel.EliminarRubroAsync(json);
        }
        
        public bool ActualizarDesc(string json) {
            return base.Channel.ActualizarDesc(json);
        }
        
        public System.Threading.Tasks.Task<bool> ActualizarDescAsync(string json) {
            return base.Channel.ActualizarDescAsync(json);
        }
        
        public bool EliminarDesc(string json) {
            return base.Channel.EliminarDesc(json);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarDescAsync(string json) {
            return base.Channel.EliminarDescAsync(json);
        }
        
        public bool ActualizarRetail(string json) {
            return base.Channel.ActualizarRetail(json);
        }
        
        public System.Threading.Tasks.Task<bool> ActualizarRetailAsync(string json) {
            return base.Channel.ActualizarRetailAsync(json);
        }
        
        public bool EliminarRetail(string json) {
            return base.Channel.EliminarRetail(json);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarRetailAsync(string json) {
            return base.Channel.EliminarRetailAsync(json);
        }
        
        public bool ActualizarProducto(string json) {
            return base.Channel.ActualizarProducto(json);
        }
        
        public System.Threading.Tasks.Task<bool> ActualizarProductoAsync(string json) {
            return base.Channel.ActualizarProductoAsync(json);
        }
        
        public bool EliminarProducto(string json) {
            return base.Channel.EliminarProducto(json);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarProductoAsync(string json) {
            return base.Channel.EliminarProductoAsync(json);
        }
        
        public bool ActualizarOferta(string json) {
            return base.Channel.ActualizarOferta(json);
        }
        
        public System.Threading.Tasks.Task<bool> ActualizarOfertaAsync(string json) {
            return base.Channel.ActualizarOfertaAsync(json);
        }
        
        public bool EliminarOferta(string json) {
            return base.Channel.EliminarOferta(json);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarOfertaAsync(string json) {
            return base.Channel.EliminarOfertaAsync(json);
        }
    }
}
