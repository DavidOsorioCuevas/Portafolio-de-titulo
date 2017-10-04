﻿using System;
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
        [OperationContract]
        string ReadAll(string json);
        [OperationContract]
        bool CrearRubro(string json);
        [OperationContract]
        bool ActualizarRubro(string json);
        [OperationContract]
        bool EliminarRubro(string json);







        // TODO: agregue aquí sus operaciones de servicio
    }




}
