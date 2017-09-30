using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;

namespace Core.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public bool CrearUsuario(string json)
        {
            Negocio.Usuario user = new Negocio.Usuario(json);
            return user.Create();
        }

        public string LeerUsuario(string json)
        {
            try
            {
                Negocio.Usuario user = new Negocio.Usuario(json);
                if (user.Read())
                {
                    return user.Serializar();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool ValidarUsuarioWPF(string username, string password)
        {
            Negocio.Usuario user = new Negocio.Usuario();
            
            return user.ValidarUsuarioWPF(username, password);
        }

    }
}
