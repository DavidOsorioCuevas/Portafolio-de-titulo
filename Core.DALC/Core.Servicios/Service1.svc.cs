﻿using System;
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
        public string ValoracionPromedio(string json)
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.promedioValoracion(json);
        }
        public string FiltrarOferta(string json)
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.filtrar(json);
        }
        public string DeshacerValoracion(string json)
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.deshacerValoracion(json);
        }
        public string TraerCategorias()
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.traerCategorías();
        }
        public string TraerRetail()
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.traerRetail();
        }
        public string TraerValoracionesOferta(string json)
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.traerValoracionesOferta(json);
        }
        public string TraerValoraciones(string json)
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.traerValoraciones(json);
        }
        public string TraerSucursales(string json)
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.traerSucursales(json);
        }
        public string TraerCupones(string json) {
            Negocio.Listas lista = new Negocio.Listas();
         return lista.traerCupones(json);        
        }
        public string TraerDescuentos()
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.traerDescuentos();
        }
        public string GenerarEcupon(string json)
        {
            Negocio.Listas lista = new Negocio.Listas();

            return lista.GenerarEcupon(json);
        }
        public string Filtrar(string json)
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.Filtrar(json);
        }
        public string Puntos(string json)
        {
            Negocio.Usuario user = new Negocio.Usuario(json);
            return user.PuntosTraer();
        }
        public string ComprobarValoracion(string json)
        {
            Negocio.Valoracion val = new Negocio.Valoracion(json);
            return val.ComprobarValoracion();
        }
        public string ValorarOferta(string json)
        {
            Negocio.Valoracion val= new Negocio.Valoracion(json);
            return val.ValorarOferta();
        }
        public string CrearUsuarioWeb(string json)
        {
            Negocio.Usuario user = new Negocio.Usuario(json);
            return user.NuevoWeb();
        }
        public string ActivarUsuario(string json)
        {
            Negocio.Usuario user = new Negocio.Usuario(json);
            return user.ActivarUsuario();
        }
        public string OfertaParametro(string parametro)
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.oferta(parametro);
        }
        public string TraerOferta(string json)
        {
            Negocio.Oferta oferta = new Negocio.Oferta(json);
            return oferta.TraerOferta();
        }
        public string ListarComunas()
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.comuna();
        }
        public string ListarRegiones()
        {
            Negocio.Listas lista = new Negocio.Listas();
            return lista.region();
        }
        public string ValidarWeb(string json)
        {
            Negocio.Usuario user = new Negocio.Usuario(json);
            return user.ValidarWeb();
        }

        public bool ActualizarCategoria(string json)
        {
            Negocio.CategoriaOferta cat = new Negocio.CategoriaOferta(json);
            return cat.ActualizarCategoria();
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

        public bool ActualizarPerfil(string json)
        {
            Negocio.Perfil p = new Negocio.Perfil(json);
            return p.ActualizarPerfil();
        }

        public bool CrearPerfil(string json)
        {
            Negocio.Perfil per = new Negocio.Perfil(json);
            return per.CrearPerfil();
        }

        public bool CrearCategoria(string json)
        {
            Negocio.CategoriaOferta cat = new Negocio.CategoriaOferta(json);
            return cat.CrearCategoria();
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


        public bool EliminarPerfil(string json)
        {
            Negocio.Perfil per = new Negocio.Perfil(json);
            return per.EliminarPerfil();
        }


        public bool EliminarCategoria(string json)
        {
            Negocio.CategoriaOferta cat = new Negocio.CategoriaOferta(json);
            return cat.EliminarCategoria();
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
            catch (Exception)
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
            catch (Exception)
            {

                return null;
            }
        }


        public string ReadAll()
        {
            Negocio.UsuarioColection collUser = new Negocio.UsuarioColection();
            return collUser.ReadAllUsuarios();
        }

        public string ReadAllCategoria()
        {
            Negocio.CategoriaCollections collCat = new Negocio.CategoriaCollections();
            return collCat.ReadAllCategoria();
        }

        public string ReadAllOfertasActivo(int idSucursal)
        {
            Negocio.OfertaCollections collOfer = new Negocio.OfertaCollections();
            return collOfer.ReadAllOfertasActivo(idSucursal);
        }

        public string ReadAllOfertasActivoWeb()
        {
            Negocio.OfertaCollections collOfer = new Negocio.OfertaCollections();
            return collOfer.ReadAllOfertasActivoWeb();
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

        public string ReadAllRegiones()
        {
            Negocio.RegionCollections collReg = new Negocio.RegionCollections();
            return collReg.ReadAllRegiones();
        }

        public string ReadAllRetail()
        {
            Negocio.RetailCollections collRetail = new Negocio.RetailCollections();
            return collRetail.ReadAllRetail();
        }

        public string ReadAllSucursal(int idRetail)
        {
            Negocio.SucursalCollections collSuc = new Negocio.SucursalCollections();
            return collSuc.ReadAllSucursal(idRetail);
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

        public string ReadAllOfertas(int idRetail)
        {
            Negocio.OfertaCollections collOfer = new Negocio.OfertaCollections();
            return collOfer.ReadAllOfertas(idRetail);
        }
        public string ReadAllOfertasDia()
        {
            Negocio.OfertaCollections collOfer = new Negocio.OfertaCollections();
            return collOfer.ReadAllOfertasDia();
        }
        public string ReadAllPerfil()
        {
            Negocio.PerfilCollections collPer = new Negocio.PerfilCollections();
            return collPer.ReadAllPerfil();
        }

        public string ReadAllComuna()
        {
            Negocio.ComunaCollections collPer = new Negocio.ComunaCollections();
            return collPer.ReadAllComuna();
        }

        public string LeerOfertaId(string json)
        {
            Negocio.Oferta of = new Negocio.Oferta(json);
            return of.LeerOfertaId();
        }

        public bool PublicarOferta(string json)
        {
            Negocio.Oferta of = new Negocio.Oferta(json);
            return of.PublicarOferta();
        }

        public bool DesPublicarOferta(string json)
        {
            Negocio.Oferta of = new Negocio.Oferta(json);
            return of.DesPubicarOferta();
        }

        public string Data()
        {
            Negocio.Oferta of = new Negocio.Oferta();
            return of.DATAGRID();
        }

        public bool CrearProductoHasOferta(string json)
        {
            Negocio.ProductoHasOferta pho = new Negocio.ProductoHasOferta(json);
            return pho.CrearProductoHasOferta();
        }

        public string LeerSucursalId(int idSuc)
        {
            Negocio.Sucursal suc = new Negocio.Sucursal();
            return suc.LeerSucursalId(idSuc);
        }

        public string LeerRetailId(int idRet)
        {
            Negocio.Retail ret = new Negocio.Retail();
            return ret.LeerRetailId(idRet);
        }

        public bool CrearOfertaHasSucursal(string json)
        {
            Negocio.OfertaHasSucursal ohs = new Negocio.OfertaHasSucursal(json);
            return ohs.CrearOfertaHasSucusal();
        }
    }
}
