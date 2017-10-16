using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace Core.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {

        public string TraerOferta(string json)
        {
            Negocio.Oferta oferta = new Negocio.Oferta(json);
            return oferta.TraerOferta();
        }
        public string ListarRegiones()
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.region();
        }
        public string ValidarWeb(string json) {
            Negocio.Usuario user = new Negocio.Usuario(json);
            return user.ValidarWeb();
        }

        public bool ActualizarDesc(string json)
        {
            Negocio.Descuento desc = new Negocio.Descuento(json);
            return desc.ActualizarDescuento();
        }

        public bool ActualizarOferta(string json)
        {
            Negocio.Oferta of = new Negocio.Oferta(json);
            return of.ActualizarOferta();
        }

        public bool ActualizarProducto(string json)
        {
            Negocio.Producto prod = new Negocio.Producto(json);
            return prod.ActualizarProducto();

        }

        public bool ActualizarRetail(string json)
        {
            Negocio.Retail ret = new Negocio.Retail(json);
            return ret.ActualizarRetail();
        }

        public bool ActualizarRubro(string json)
        {
            Negocio.Rubro ru = new Negocio.Rubro(json);
            return ru.ActualizarRubro();
        }

        public bool ActualizarSucursal(string json)
        {
            Negocio.Sucursal su = new Negocio.Sucursal(json);
            return su.ActualizarSucursal();
        }

        public bool ActualizarUsuario(string json)
        {
            Negocio.Usuario u = new Negocio.Usuario(json);
            return u.ActualizarUsuario();
        }

        public bool CrearDesc(string json)
        {
            Negocio.Descuento desc = new Negocio.Descuento(json);
            return desc.CrearDescuento();
        }

        public bool CrearOferta(string json)
        {
            Negocio.Oferta of = new Negocio.Oferta(json);
            return of.CrearOferta();
        }

        public bool CrearProducto(string json)
        {
            Negocio.Producto prod = new Negocio.Producto(json);
            return prod.CrearProducto();
        }

        public bool CrearRetail(string json)
        {
            Negocio.Retail ret = new Negocio.Retail(json);
            return ret.CrearRetail();
        }

        public bool CrearRubro(string json)
        {
            Negocio.Rubro ru = new Negocio.Rubro(json);
            return ru.CrearRubro();
        }

        public bool CrearSucursal(string json)
        {
            Negocio.Sucursal su = new Negocio.Sucursal(json);
            return su.CrearSucursal();
        }

        public bool CrearUsuario(string json)
        {
            Negocio.Usuario user = new Negocio.Usuario(json);
            return user.Create();
        }

        public bool EliminarDesc(string json)
        {
            Negocio.Descuento desc = new Negocio.Descuento(json);
            return desc.EliminarDescuento();
        }

        public bool EliminarOferta(string json)
        {
            Negocio.Oferta of = new Negocio.Oferta(json);
            return of.EliminarOferta();
        }

        public bool EliminarProducto(string json)
        {
            Negocio.Producto prod = new Negocio.Producto(json);
            return prod.EliminarProducto();
        }

        public bool EliminarRetail(string json)
        {
            Negocio.Retail ret = new Negocio.Retail(json);
            return ret.EliminarRetail();
        }

        public bool EliminarRubro(string json)
        {
            Negocio.Rubro ru = new Negocio.Rubro(json);
            return ru.EliminarRubro();
        }

        public bool EliminarSucursal(string json)
        {
            Negocio.Sucursal su = new Negocio.Sucursal(json);
            return su.CrearSucursal();
        }

        public bool EliminarUsuario(string json)
        {
            Negocio.Usuario user = new Negocio.Usuario(json);
            return user.EliminarUsuario();
        }

        public string LeerId(string json)
        {
            try
            {
                Negocio.Usuario user = new Negocio.Usuario(json);
                if (user.LeerId())
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


        public string ReadAll()
        {
            Negocio.UsuarioColection collUser = new Negocio.UsuarioColection();
            return collUser.ReadAllUsuarios();
        }

        public string ReadAllOfertasActivo()
        {
            Negocio.OfertaCollections collOfer = new Negocio.OfertaCollections();
            return collOfer.ReadAllOfertasActivo();
        }



        public string ReadAllProductos()
        {
            Negocio.ProductoCollections collProd = new Negocio.ProductoCollections();
            return collProd.ReadAllProductos();
        }

        public string ReadAllRubros()
        {
            Negocio.RubroCollections collUser = new Negocio.RubroCollections();
            return collUser.ReadAllRubros();
        }

        public string ReadAllSucursal()
        {
            Negocio.SucursalCollections collSuc = new Negocio.SucursalCollections();
            return collSuc.ReadAllSucursal();
        }

        public bool ValidarUsuarioWPF(string username, string password)
        {
            Negocio.Usuario user = new Negocio.Usuario();

            return user.ValidarUsuarioWPF(username, password);
        }

        public string ReadAllOfertasDesactivo()
        {
            Negocio.OfertaCollections collOfer = new Negocio.OfertaCollections();
            return collOfer.ReadAllOfertasDesactivo();
        }

        public string ReadAllOfertas()
        {
            Negocio.OfertaCollections collOfer = new Negocio.OfertaCollections();
            return collOfer.ReadAllOfertas();
        }
    }
}
