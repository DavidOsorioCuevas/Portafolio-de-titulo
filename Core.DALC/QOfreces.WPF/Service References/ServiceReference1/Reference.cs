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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ListarRegiones", ReplyAction="http://tempuri.org/IService1/ListarRegionesResponse")]
        string ListarRegiones();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ListarRegiones", ReplyAction="http://tempuri.org/IService1/ListarRegionesResponse")]
        System.Threading.Tasks.Task<string> ListarRegionesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ValidarWeb", ReplyAction="http://tempuri.org/IService1/ValidarWebResponse")]
        string ValidarWeb(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ValidarWeb", ReplyAction="http://tempuri.org/IService1/ValidarWebResponse")]
        System.Threading.Tasks.Task<string> ValidarWebAsync(string json);
        
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
        string ReadAllProductos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAllProductos", ReplyAction="http://tempuri.org/IService1/ReadAllProductosResponse")]
        System.Threading.Tasks.Task<string> ReadAllProductosAsync();
        
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAllRubros", ReplyAction="http://tempuri.org/IService1/ReadAllRubrosResponse")]
        string ReadAllRubros();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAllRubros", ReplyAction="http://tempuri.org/IService1/ReadAllRubrosResponse")]
        System.Threading.Tasks.Task<string> ReadAllRubrosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAllOfertasActivo", ReplyAction="http://tempuri.org/IService1/ReadAllOfertasActivoResponse")]
        string ReadAllOfertasActivo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAllOfertasActivo", ReplyAction="http://tempuri.org/IService1/ReadAllOfertasActivoResponse")]
        System.Threading.Tasks.Task<string> ReadAllOfertasActivoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAllOfertasDesactivo", ReplyAction="http://tempuri.org/IService1/ReadAllOfertasDesactivoResponse")]
        string ReadAllOfertasDesactivo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAllOfertasDesactivo", ReplyAction="http://tempuri.org/IService1/ReadAllOfertasDesactivoResponse")]
        System.Threading.Tasks.Task<string> ReadAllOfertasDesactivoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrearDesc", ReplyAction="http://tempuri.org/IService1/CrearDescResponse")]
        bool CrearDesc(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrearDesc", ReplyAction="http://tempuri.org/IService1/CrearDescResponse")]
        System.Threading.Tasks.Task<bool> CrearDescAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarDesc", ReplyAction="http://tempuri.org/IService1/ActualizarDescResponse")]
        bool ActualizarDesc(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarDesc", ReplyAction="http://tempuri.org/IService1/ActualizarDescResponse")]
        System.Threading.Tasks.Task<bool> ActualizarDescAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarDesc", ReplyAction="http://tempuri.org/IService1/EliminarDescResponse")]
        bool EliminarDesc(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarDesc", ReplyAction="http://tempuri.org/IService1/EliminarDescResponse")]
        System.Threading.Tasks.Task<bool> EliminarDescAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrearRetail", ReplyAction="http://tempuri.org/IService1/CrearRetailResponse")]
        bool CrearRetail(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrearRetail", ReplyAction="http://tempuri.org/IService1/CrearRetailResponse")]
        System.Threading.Tasks.Task<bool> CrearRetailAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarRetail", ReplyAction="http://tempuri.org/IService1/ActualizarRetailResponse")]
        bool ActualizarRetail(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarRetail", ReplyAction="http://tempuri.org/IService1/ActualizarRetailResponse")]
        System.Threading.Tasks.Task<bool> ActualizarRetailAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarRetail", ReplyAction="http://tempuri.org/IService1/EliminarRetailResponse")]
        bool EliminarRetail(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarRetail", ReplyAction="http://tempuri.org/IService1/EliminarRetailResponse")]
        System.Threading.Tasks.Task<bool> EliminarRetailAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrearProducto", ReplyAction="http://tempuri.org/IService1/CrearProductoResponse")]
        bool CrearProducto(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrearProducto", ReplyAction="http://tempuri.org/IService1/CrearProductoResponse")]
        System.Threading.Tasks.Task<bool> CrearProductoAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarProducto", ReplyAction="http://tempuri.org/IService1/ActualizarProductoResponse")]
        bool ActualizarProducto(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ActualizarProducto", ReplyAction="http://tempuri.org/IService1/ActualizarProductoResponse")]
        System.Threading.Tasks.Task<bool> ActualizarProductoAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarProducto", ReplyAction="http://tempuri.org/IService1/EliminarProductoResponse")]
        bool EliminarProducto(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarProducto", ReplyAction="http://tempuri.org/IService1/EliminarProductoResponse")]
        System.Threading.Tasks.Task<bool> EliminarProductoAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrearOferta", ReplyAction="http://tempuri.org/IService1/CrearOfertaResponse")]
        bool CrearOferta(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrearOferta", ReplyAction="http://tempuri.org/IService1/CrearOfertaResponse")]
        System.Threading.Tasks.Task<bool> CrearOfertaAsync(string json);
        
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
        
        public string ListarRegiones() {
            return base.Channel.ListarRegiones();
        }
        
        public System.Threading.Tasks.Task<string> ListarRegionesAsync() {
            return base.Channel.ListarRegionesAsync();
        }
        
        public string ValidarWeb(string json) {
            return base.Channel.ValidarWeb(json);
        }
        
        public System.Threading.Tasks.Task<string> ValidarWebAsync(string json) {
            return base.Channel.ValidarWebAsync(json);
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
        
        public string ReadAllProductos() {
            return base.Channel.ReadAllProductos();
        }
        
        public System.Threading.Tasks.Task<string> ReadAllProductosAsync() {
            return base.Channel.ReadAllProductosAsync();
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
        
        public string ReadAllRubros() {
            return base.Channel.ReadAllRubros();
        }
        
        public System.Threading.Tasks.Task<string> ReadAllRubrosAsync() {
            return base.Channel.ReadAllRubrosAsync();
        }
        
        public string ReadAllOfertasActivo() {
            return base.Channel.ReadAllOfertasActivo();
        }
        
        public System.Threading.Tasks.Task<string> ReadAllOfertasActivoAsync() {
            return base.Channel.ReadAllOfertasActivoAsync();
        }
        
        public string ReadAllOfertasDesactivo() {
            return base.Channel.ReadAllOfertasDesactivo();
        }
        
        public System.Threading.Tasks.Task<string> ReadAllOfertasDesactivoAsync() {
            return base.Channel.ReadAllOfertasDesactivoAsync();
        }
        
        public bool CrearDesc(string json) {
            return base.Channel.CrearDesc(json);
        }
        
        public System.Threading.Tasks.Task<bool> CrearDescAsync(string json) {
            return base.Channel.CrearDescAsync(json);
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
        
        public bool CrearRetail(string json) {
            return base.Channel.CrearRetail(json);
        }
        
        public System.Threading.Tasks.Task<bool> CrearRetailAsync(string json) {
            return base.Channel.CrearRetailAsync(json);
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
        
        public bool CrearProducto(string json) {
            return base.Channel.CrearProducto(json);
        }
        
        public System.Threading.Tasks.Task<bool> CrearProductoAsync(string json) {
            return base.Channel.CrearProductoAsync(json);
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
        
        public bool CrearOferta(string json) {
            return base.Channel.CrearOferta(json);
        }
        
        public System.Threading.Tasks.Task<bool> CrearOfertaAsync(string json) {
            return base.Channel.CrearOfertaAsync(json);
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
