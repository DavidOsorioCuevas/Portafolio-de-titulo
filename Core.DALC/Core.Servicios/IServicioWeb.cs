using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Core.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioWeb" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioWeb
    {
        [OperationContract]
        string ValidarWeb(string json);
    }
}
