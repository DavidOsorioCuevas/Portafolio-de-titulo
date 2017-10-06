using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Core.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        /*USUARIO*/
        [OperationContract]
        bool ValidarUsuarioWPF(string username, string password);
        [OperationContract]
        string LeerUsuario(string json);
        [OperationContract]
        bool CrearUsuario(string json);
        [OperationContract]
        bool EliminarUsuario(string json);
        [OperationContract]
        bool ActualizarUsuario(string json);
        [OperationContract]
        string LeerId(string json);

        /*USUARIO COLLECTIONS*/
        [OperationContract]
        string ReadAll();

        /*PRODUCTO COLLECTIONS*/
        [OperationContract]
        string ReadAllProductos(string json);

        /*RUBRO*/
        [OperationContract]
        bool CrearRubro(string json);
        [OperationContract]
        bool ActualizarRubro(string json);
        [OperationContract]
        bool EliminarRubro(string json);

        /*Descuento*/
        bool CrearDesc(string json);
        [OperationContract]
        bool ActualizarDesc(string json);
        [OperationContract]
        bool EliminarDesc(string json);

        /*RETAIL*/
        bool CrearRetail(string json);
        [OperationContract]
        bool ActualizarRetail(string json);
        [OperationContract]
        bool EliminarRetail(string json);

        /*PRODUCTO*/
        bool CrearProducto(string json);
        [OperationContract]
        bool ActualizarProducto(string json);
        [OperationContract]
        bool EliminarProducto(string json);

        /*Oferta*/
        bool CrearOferta(string json);
        [OperationContract]
        bool ActualizarOferta(string json);
        [OperationContract]
        bool EliminarOferta(string json);








        // TODO: agregue aquí sus operaciones de servicio
    }




}
