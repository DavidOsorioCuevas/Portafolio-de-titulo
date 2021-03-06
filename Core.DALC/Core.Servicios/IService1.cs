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
        string ValoracionPromedio(string json);
        [OperationContract]
        string FiltrarOferta(string json);
        [OperationContract]
        string DeshacerValoracion(string json);
        [OperationContract]
        string TraerCategorias();
        [OperationContract]
        string TraerRetail();
        [OperationContract]
        string TraerValoracionesOferta(string json);
        [OperationContract]
        string TraerValoraciones(string json);
        [OperationContract]
        string TraerSucursales(string json);
        [OperationContract]
        string TraerCupones(string json);
        [OperationContract]
        string GenerarEcupon(string json);
        [OperationContract]
        string TraerDescuentos();
        /*USUARIO*/
        [OperationContract]
        string Puntos(string json);
        [OperationContract]
        string ComprobarValoracion(string json);
        [OperationContract]
        string ValorarOferta(string json);
        [OperationContract]
        string CrearUsuarioWeb(string json);
        [OperationContract]
        string ActivarUsuario(string json);
        [OperationContract]
        string ListarComunas();
        [OperationContract]
        string ListarRegiones();
        [OperationContract]
        string ValidarWeb(string json);
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
        string ReadAllProductos();

        /*REGION COLLECTIONS*/
        [OperationContract]
        string ReadAllRegiones();

        /*RUBRO*/
        [OperationContract]
        bool CrearRubro(string json);
        [OperationContract]
        bool ActualizarRubro(string json);
        [OperationContract]
        bool EliminarRubro(string json);

        /*RUBROCOLLECTIONS*/
        [OperationContract]
        string ReadAllRubros();

        /*PERFIL*/
        [OperationContract]
        bool CrearPerfil(string json);
        [OperationContract]
        bool ActualizarPerfil(string json);
        [OperationContract]
        bool EliminarPerfil(string json);

        /*PERFILCOLLECTIONS*/
        [OperationContract]
        string ReadAllPerfil();

        /*CATEGORIA*/
        [OperationContract]
        bool CrearCategoria(string json);
        [OperationContract]
        bool ActualizarCategoria(string json);
        [OperationContract]
        bool EliminarCategoria(string json);

        /*CATEGORIACOLLECTIONS*/
        [OperationContract]
        string ReadAllCategoria();

        /*SUCURSAL*/
        [OperationContract]
        bool CrearSucursal(string json);
        [OperationContract]
        bool ActualizarSucursal(string json);
        [OperationContract]
        bool EliminarSucursal(string json);
        [OperationContract]
        string LeerSucursalId(int idSuc);

        /*SUCURSALCOLLECTIONS*/
        [OperationContract]
        string ReadAllSucursal(int idRetail);

        /*COMUNACOLLECTIONS*/
        [OperationContract]
        string ReadAllComuna();

        /*OFERTACOLLECTIONS*/
        [OperationContract]
        string ReadAllOfertasActivoWeb();
        [OperationContract]
        string ReadAllOfertasActivo(int idSucursal);
        [OperationContract]
        string ReadAllOfertasDesactivo();
        [OperationContract]
        string ReadAllOfertas(int idRetail);
        [OperationContract]
        string ReadAllOfertasDia();

        /*Descuento*/
        [OperationContract]
        bool CrearDesc(string json);
        [OperationContract]
        bool ActualizarDesc(string json);
        [OperationContract]
        bool EliminarDesc(string json);

        /*RETAIL*/
        [OperationContract]
        bool CrearRetail(string json);
        [OperationContract]
        bool ActualizarRetail(string json);
        [OperationContract]
        bool EliminarRetail(string json);
        [OperationContract]
        string LeerRetailId(int idRet);

        /*RetailCollections*/
        [OperationContract]
        string ReadAllRetail();

        /*PRODUCTO*/
        [OperationContract]
        bool CrearProducto(string json);
        [OperationContract]
        bool ActualizarProducto(string json);
        [OperationContract]
        bool EliminarProducto(string json);

        /*Oferta*/
        [OperationContract]
        string Filtrar(string json);
        [OperationContract]
        string TraerOferta(string json);
        [OperationContract]
        bool CrearOferta(string json);
        [OperationContract]
        bool ActualizarOferta(string json);
        [OperationContract]
        bool EliminarOferta(string json);
        [OperationContract]
        string LeerOfertaId(string json);
        [OperationContract]
        string OfertaParametro(string parametro);
        [OperationContract]
        bool PublicarOferta(string json);
        [OperationContract]
        bool DesPublicarOferta(string json);
        [OperationContract]
        string Data();

        /*PRODUCTO HAS OFERTA*/
        [OperationContract]
        bool CrearProductoHasOferta(string json);

        /*OFERTA HAS SUCURSAL*/
        [OperationContract]
        bool CrearOfertaHasSucursal(string json);







        // TODO: agregue aquí sus operaciones de servicio
    }




}
