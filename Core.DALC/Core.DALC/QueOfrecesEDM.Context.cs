﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.DALC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class QueOfrecesEntities : DbContext
    {
        public QueOfrecesEntities()
            : base("name=QueOfrecesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CATEGORIA_OFERTA> CATEGORIA_OFERTA { get; set; }
        public DbSet<COMPORTAMIENTO> COMPORTAMIENTO { get; set; }
        public DbSet<COMUNA> COMUNA { get; set; }
        public DbSet<CUPON> CUPON { get; set; }
        public DbSet<DESCUENTO> DESCUENTO { get; set; }
        public DbSet<DESCUENTO_HAS_RUBRO> DESCUENTO_HAS_RUBRO { get; set; }
        public DbSet<OFERTA> OFERTA { get; set; }
        public DbSet<PAIS> PAIS { get; set; }
        public DbSet<PERFIL> PERFIL { get; set; }
        public DbSet<PREFERENCIA> PREFERENCIA { get; set; }
        public DbSet<PRODUCTO> PRODUCTO { get; set; }
        public DbSet<PRODUCTO_HAS_OFERTA> PRODUCTO_HAS_OFERTA { get; set; }
        public DbSet<REGION> REGION { get; set; }
        public DbSet<RETAIL> RETAIL { get; set; }
        public DbSet<RUBRO> RUBRO { get; set; }
        public DbSet<SUCURSALES> SUCURSALES { get; set; }
        public DbSet<USUARIO> USUARIO { get; set; }
        public DbSet<VALORACION> VALORACION { get; set; }
    
        public virtual int CATEGORIA_OFERTA_CREAR(string iN_NOMBRE)
        {
            var iN_NOMBREParameter = iN_NOMBRE != null ?
                new ObjectParameter("IN_NOMBRE", iN_NOMBRE) :
                new ObjectParameter("IN_NOMBRE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CATEGORIA_OFERTA_CREAR", iN_NOMBREParameter);
        }
    
        public virtual int COMUNA_CREAR(string iN_NOMBRE, Nullable<decimal> iN_REGION_ID)
        {
            var iN_NOMBREParameter = iN_NOMBRE != null ?
                new ObjectParameter("IN_NOMBRE", iN_NOMBRE) :
                new ObjectParameter("IN_NOMBRE", typeof(string));
    
            var iN_REGION_IDParameter = iN_REGION_ID.HasValue ?
                new ObjectParameter("IN_REGION_ID", iN_REGION_ID) :
                new ObjectParameter("IN_REGION_ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("COMUNA_CREAR", iN_NOMBREParameter, iN_REGION_IDParameter);
        }
    
        public virtual int PAIS_CREAR(string iN_NOMBRE, string iN_SIGLA_PAIS)
        {
            var iN_NOMBREParameter = iN_NOMBRE != null ?
                new ObjectParameter("IN_NOMBRE", iN_NOMBRE) :
                new ObjectParameter("IN_NOMBRE", typeof(string));
    
            var iN_SIGLA_PAISParameter = iN_SIGLA_PAIS != null ?
                new ObjectParameter("IN_SIGLA_PAIS", iN_SIGLA_PAIS) :
                new ObjectParameter("IN_SIGLA_PAIS", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PAIS_CREAR", iN_NOMBREParameter, iN_SIGLA_PAISParameter);
        }
    
        public virtual int PRODUCTO_CREAR(Nullable<decimal> iN_RUBRO_ID, Nullable<decimal> iN_PRECIO, string iN_SKU, string iN_CODIGOIN, string iN_NOMBRE, string iN_DESCR)
        {
            var iN_RUBRO_IDParameter = iN_RUBRO_ID.HasValue ?
                new ObjectParameter("IN_RUBRO_ID", iN_RUBRO_ID) :
                new ObjectParameter("IN_RUBRO_ID", typeof(decimal));
    
            var iN_PRECIOParameter = iN_PRECIO.HasValue ?
                new ObjectParameter("IN_PRECIO", iN_PRECIO) :
                new ObjectParameter("IN_PRECIO", typeof(decimal));
    
            var iN_SKUParameter = iN_SKU != null ?
                new ObjectParameter("IN_SKU", iN_SKU) :
                new ObjectParameter("IN_SKU", typeof(string));
    
            var iN_CODIGOINParameter = iN_CODIGOIN != null ?
                new ObjectParameter("IN_CODIGOIN", iN_CODIGOIN) :
                new ObjectParameter("IN_CODIGOIN", typeof(string));
    
            var iN_NOMBREParameter = iN_NOMBRE != null ?
                new ObjectParameter("IN_NOMBRE", iN_NOMBRE) :
                new ObjectParameter("IN_NOMBRE", typeof(string));
    
            var iN_DESCRParameter = iN_DESCR != null ?
                new ObjectParameter("IN_DESCR", iN_DESCR) :
                new ObjectParameter("IN_DESCR", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PRODUCTO_CREAR", iN_RUBRO_IDParameter, iN_PRECIOParameter, iN_SKUParameter, iN_CODIGOINParameter, iN_NOMBREParameter, iN_DESCRParameter);
        }
    
        public virtual int REGION_CREAR(string iN_NOMBRE)
        {
            var iN_NOMBREParameter = iN_NOMBRE != null ?
                new ObjectParameter("IN_NOMBRE", iN_NOMBRE) :
                new ObjectParameter("IN_NOMBRE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("REGION_CREAR", iN_NOMBREParameter);
        }
    
        public virtual int RETAIL_CREAR(string iN_RUT, string iN_NOMBRE, string iN_RAZON_SOCIAL, Nullable<decimal> iN_TELEFONO, string iN_EMAIL, string iN_DIRECCION, Nullable<decimal> iN_REGION_ID, Nullable<decimal> iN_COMUNA_ID)
        {
            var iN_RUTParameter = iN_RUT != null ?
                new ObjectParameter("IN_RUT", iN_RUT) :
                new ObjectParameter("IN_RUT", typeof(string));
    
            var iN_NOMBREParameter = iN_NOMBRE != null ?
                new ObjectParameter("IN_NOMBRE", iN_NOMBRE) :
                new ObjectParameter("IN_NOMBRE", typeof(string));
    
            var iN_RAZON_SOCIALParameter = iN_RAZON_SOCIAL != null ?
                new ObjectParameter("IN_RAZON_SOCIAL", iN_RAZON_SOCIAL) :
                new ObjectParameter("IN_RAZON_SOCIAL", typeof(string));
    
            var iN_TELEFONOParameter = iN_TELEFONO.HasValue ?
                new ObjectParameter("IN_TELEFONO", iN_TELEFONO) :
                new ObjectParameter("IN_TELEFONO", typeof(decimal));
    
            var iN_EMAILParameter = iN_EMAIL != null ?
                new ObjectParameter("IN_EMAIL", iN_EMAIL) :
                new ObjectParameter("IN_EMAIL", typeof(string));
    
            var iN_DIRECCIONParameter = iN_DIRECCION != null ?
                new ObjectParameter("IN_DIRECCION", iN_DIRECCION) :
                new ObjectParameter("IN_DIRECCION", typeof(string));
    
            var iN_REGION_IDParameter = iN_REGION_ID.HasValue ?
                new ObjectParameter("IN_REGION_ID", iN_REGION_ID) :
                new ObjectParameter("IN_REGION_ID", typeof(decimal));
    
            var iN_COMUNA_IDParameter = iN_COMUNA_ID.HasValue ?
                new ObjectParameter("IN_COMUNA_ID", iN_COMUNA_ID) :
                new ObjectParameter("IN_COMUNA_ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RETAIL_CREAR", iN_RUTParameter, iN_NOMBREParameter, iN_RAZON_SOCIALParameter, iN_TELEFONOParameter, iN_EMAILParameter, iN_DIRECCIONParameter, iN_REGION_IDParameter, iN_COMUNA_IDParameter);
        }
    
        public virtual int RETAIL_EDITAR(string iN_RUT, string iN_NOMBRE, string iN_RAZON_SOCIAL, Nullable<decimal> iN_TELEFONO, string iN_EMAIL, string iN_DIRECCION, Nullable<decimal> iN_REGION_ID, Nullable<decimal> iN_COMUNA_ID)
        {
            var iN_RUTParameter = iN_RUT != null ?
                new ObjectParameter("IN_RUT", iN_RUT) :
                new ObjectParameter("IN_RUT", typeof(string));
    
            var iN_NOMBREParameter = iN_NOMBRE != null ?
                new ObjectParameter("IN_NOMBRE", iN_NOMBRE) :
                new ObjectParameter("IN_NOMBRE", typeof(string));
    
            var iN_RAZON_SOCIALParameter = iN_RAZON_SOCIAL != null ?
                new ObjectParameter("IN_RAZON_SOCIAL", iN_RAZON_SOCIAL) :
                new ObjectParameter("IN_RAZON_SOCIAL", typeof(string));
    
            var iN_TELEFONOParameter = iN_TELEFONO.HasValue ?
                new ObjectParameter("IN_TELEFONO", iN_TELEFONO) :
                new ObjectParameter("IN_TELEFONO", typeof(decimal));
    
            var iN_EMAILParameter = iN_EMAIL != null ?
                new ObjectParameter("IN_EMAIL", iN_EMAIL) :
                new ObjectParameter("IN_EMAIL", typeof(string));
    
            var iN_DIRECCIONParameter = iN_DIRECCION != null ?
                new ObjectParameter("IN_DIRECCION", iN_DIRECCION) :
                new ObjectParameter("IN_DIRECCION", typeof(string));
    
            var iN_REGION_IDParameter = iN_REGION_ID.HasValue ?
                new ObjectParameter("IN_REGION_ID", iN_REGION_ID) :
                new ObjectParameter("IN_REGION_ID", typeof(decimal));
    
            var iN_COMUNA_IDParameter = iN_COMUNA_ID.HasValue ?
                new ObjectParameter("IN_COMUNA_ID", iN_COMUNA_ID) :
                new ObjectParameter("IN_COMUNA_ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RETAIL_EDITAR", iN_RUTParameter, iN_NOMBREParameter, iN_RAZON_SOCIALParameter, iN_TELEFONOParameter, iN_EMAILParameter, iN_DIRECCIONParameter, iN_REGION_IDParameter, iN_COMUNA_IDParameter);
        }
    
        public virtual int RETAIL_ELIMINAR(Nullable<decimal> iN_ID_RETAIL)
        {
            var iN_ID_RETAILParameter = iN_ID_RETAIL.HasValue ?
                new ObjectParameter("IN_ID_RETAIL", iN_ID_RETAIL) :
                new ObjectParameter("IN_ID_RETAIL", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RETAIL_ELIMINAR", iN_ID_RETAILParameter);
        }
    
        public virtual int RUBRO_CREAR(string iN_TIPO, string iN_DESCRIPCION)
        {
            var iN_TIPOParameter = iN_TIPO != null ?
                new ObjectParameter("IN_TIPO", iN_TIPO) :
                new ObjectParameter("IN_TIPO", typeof(string));
    
            var iN_DESCRIPCIONParameter = iN_DESCRIPCION != null ?
                new ObjectParameter("IN_DESCRIPCION", iN_DESCRIPCION) :
                new ObjectParameter("IN_DESCRIPCION", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RUBRO_CREAR", iN_TIPOParameter, iN_DESCRIPCIONParameter);
        }
    
        public virtual int RUBRO_EDITAR(Nullable<decimal> iN_ID_RUBRO, string iN_TIPO, string iN_DESCRIPCION)
        {
            var iN_ID_RUBROParameter = iN_ID_RUBRO.HasValue ?
                new ObjectParameter("IN_ID_RUBRO", iN_ID_RUBRO) :
                new ObjectParameter("IN_ID_RUBRO", typeof(decimal));
    
            var iN_TIPOParameter = iN_TIPO != null ?
                new ObjectParameter("IN_TIPO", iN_TIPO) :
                new ObjectParameter("IN_TIPO", typeof(string));
    
            var iN_DESCRIPCIONParameter = iN_DESCRIPCION != null ?
                new ObjectParameter("IN_DESCRIPCION", iN_DESCRIPCION) :
                new ObjectParameter("IN_DESCRIPCION", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RUBRO_EDITAR", iN_ID_RUBROParameter, iN_TIPOParameter, iN_DESCRIPCIONParameter);
        }
    
        public virtual int RUBRO_ELIMINAR(Nullable<decimal> iN_ID_RUBRO)
        {
            var iN_ID_RUBROParameter = iN_ID_RUBRO.HasValue ?
                new ObjectParameter("IN_ID_RUBRO", iN_ID_RUBRO) :
                new ObjectParameter("IN_ID_RUBRO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RUBRO_ELIMINAR", iN_ID_RUBROParameter);
        }
    
        public virtual int SUCURSAL_CREAR(string iN_RUT, string iN_RAZON_SOCIAL, string iN_NOMBRE, string iN_DIRECCION, Nullable<decimal> iN_TELEFONO, string iN_EMAIL, Nullable<decimal> iN_COMUNA_ID, Nullable<decimal> iN_REGION_ID, Nullable<decimal> iN_RETAIL_ID)
        {
            var iN_RUTParameter = iN_RUT != null ?
                new ObjectParameter("IN_RUT", iN_RUT) :
                new ObjectParameter("IN_RUT", typeof(string));
    
            var iN_RAZON_SOCIALParameter = iN_RAZON_SOCIAL != null ?
                new ObjectParameter("IN_RAZON_SOCIAL", iN_RAZON_SOCIAL) :
                new ObjectParameter("IN_RAZON_SOCIAL", typeof(string));
    
            var iN_NOMBREParameter = iN_NOMBRE != null ?
                new ObjectParameter("IN_NOMBRE", iN_NOMBRE) :
                new ObjectParameter("IN_NOMBRE", typeof(string));
    
            var iN_DIRECCIONParameter = iN_DIRECCION != null ?
                new ObjectParameter("IN_DIRECCION", iN_DIRECCION) :
                new ObjectParameter("IN_DIRECCION", typeof(string));
    
            var iN_TELEFONOParameter = iN_TELEFONO.HasValue ?
                new ObjectParameter("IN_TELEFONO", iN_TELEFONO) :
                new ObjectParameter("IN_TELEFONO", typeof(decimal));
    
            var iN_EMAILParameter = iN_EMAIL != null ?
                new ObjectParameter("IN_EMAIL", iN_EMAIL) :
                new ObjectParameter("IN_EMAIL", typeof(string));
    
            var iN_COMUNA_IDParameter = iN_COMUNA_ID.HasValue ?
                new ObjectParameter("IN_COMUNA_ID", iN_COMUNA_ID) :
                new ObjectParameter("IN_COMUNA_ID", typeof(decimal));
    
            var iN_REGION_IDParameter = iN_REGION_ID.HasValue ?
                new ObjectParameter("IN_REGION_ID", iN_REGION_ID) :
                new ObjectParameter("IN_REGION_ID", typeof(decimal));
    
            var iN_RETAIL_IDParameter = iN_RETAIL_ID.HasValue ?
                new ObjectParameter("IN_RETAIL_ID", iN_RETAIL_ID) :
                new ObjectParameter("IN_RETAIL_ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SUCURSAL_CREAR", iN_RUTParameter, iN_RAZON_SOCIALParameter, iN_NOMBREParameter, iN_DIRECCIONParameter, iN_TELEFONOParameter, iN_EMAILParameter, iN_COMUNA_IDParameter, iN_REGION_IDParameter, iN_RETAIL_IDParameter);
        }
    
        public virtual int SUCURSAL_EDITAR(string iN_RUT, string iN_RAZON_SOCIAL, string iN_NOMBRE, string iN_DIRECCION, Nullable<decimal> iN_TELEFONO, string iN_EMAIL, Nullable<decimal> iN_COMUNA_ID, Nullable<decimal> iN_REGION_ID, Nullable<decimal> iN_RETAIL_ID)
        {
            var iN_RUTParameter = iN_RUT != null ?
                new ObjectParameter("IN_RUT", iN_RUT) :
                new ObjectParameter("IN_RUT", typeof(string));
    
            var iN_RAZON_SOCIALParameter = iN_RAZON_SOCIAL != null ?
                new ObjectParameter("IN_RAZON_SOCIAL", iN_RAZON_SOCIAL) :
                new ObjectParameter("IN_RAZON_SOCIAL", typeof(string));
    
            var iN_NOMBREParameter = iN_NOMBRE != null ?
                new ObjectParameter("IN_NOMBRE", iN_NOMBRE) :
                new ObjectParameter("IN_NOMBRE", typeof(string));
    
            var iN_DIRECCIONParameter = iN_DIRECCION != null ?
                new ObjectParameter("IN_DIRECCION", iN_DIRECCION) :
                new ObjectParameter("IN_DIRECCION", typeof(string));
    
            var iN_TELEFONOParameter = iN_TELEFONO.HasValue ?
                new ObjectParameter("IN_TELEFONO", iN_TELEFONO) :
                new ObjectParameter("IN_TELEFONO", typeof(decimal));
    
            var iN_EMAILParameter = iN_EMAIL != null ?
                new ObjectParameter("IN_EMAIL", iN_EMAIL) :
                new ObjectParameter("IN_EMAIL", typeof(string));
    
            var iN_COMUNA_IDParameter = iN_COMUNA_ID.HasValue ?
                new ObjectParameter("IN_COMUNA_ID", iN_COMUNA_ID) :
                new ObjectParameter("IN_COMUNA_ID", typeof(decimal));
    
            var iN_REGION_IDParameter = iN_REGION_ID.HasValue ?
                new ObjectParameter("IN_REGION_ID", iN_REGION_ID) :
                new ObjectParameter("IN_REGION_ID", typeof(decimal));
    
            var iN_RETAIL_IDParameter = iN_RETAIL_ID.HasValue ?
                new ObjectParameter("IN_RETAIL_ID", iN_RETAIL_ID) :
                new ObjectParameter("IN_RETAIL_ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SUCURSAL_EDITAR", iN_RUTParameter, iN_RAZON_SOCIALParameter, iN_NOMBREParameter, iN_DIRECCIONParameter, iN_TELEFONOParameter, iN_EMAILParameter, iN_COMUNA_IDParameter, iN_REGION_IDParameter, iN_RETAIL_IDParameter);
        }
    
        public virtual int SUCURSAL_ELIMINAR(Nullable<decimal> iN_RUT)
        {
            var iN_RUTParameter = iN_RUT.HasValue ?
                new ObjectParameter("IN_RUT", iN_RUT) :
                new ObjectParameter("IN_RUT", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SUCURSAL_ELIMINAR", iN_RUTParameter);
        }
    
        public virtual int USUARIO_CREAR(Nullable<decimal> iN_PERFIL_ID, string iN_LOGIN_USUARIO, string iN_PASS_USUARIO, string iN_NOMBRE_USUARIO, string iN_APELLIDO_USUARIO, string iN_RUT, string iN_ACTIVO, Nullable<decimal> iN_SUCURSAL, Nullable<System.DateTime> iN_FECHA_NACIMIENTO, string iN_SEXO, string iN_NACIONALIDAD, string iN_PASSAPORTE, Nullable<decimal> iN_COMUNA_ID, Nullable<decimal> iN_REGION_ID, string iN_EMAIL, Nullable<decimal> iN_CELULAR, Nullable<decimal> iN_PUNTOS, string iN_CODIGO_VERIFICACION, Nullable<System.DateTime> iN_FECHA_CREACION)
        {
            var iN_PERFIL_IDParameter = iN_PERFIL_ID.HasValue ?
                new ObjectParameter("IN_PERFIL_ID", iN_PERFIL_ID) :
                new ObjectParameter("IN_PERFIL_ID", typeof(decimal));
    
            var iN_LOGIN_USUARIOParameter = iN_LOGIN_USUARIO != null ?
                new ObjectParameter("IN_LOGIN_USUARIO", iN_LOGIN_USUARIO) :
                new ObjectParameter("IN_LOGIN_USUARIO", typeof(string));
    
            var iN_PASS_USUARIOParameter = iN_PASS_USUARIO != null ?
                new ObjectParameter("IN_PASS_USUARIO", iN_PASS_USUARIO) :
                new ObjectParameter("IN_PASS_USUARIO", typeof(string));
    
            var iN_NOMBRE_USUARIOParameter = iN_NOMBRE_USUARIO != null ?
                new ObjectParameter("IN_NOMBRE_USUARIO", iN_NOMBRE_USUARIO) :
                new ObjectParameter("IN_NOMBRE_USUARIO", typeof(string));
    
            var iN_APELLIDO_USUARIOParameter = iN_APELLIDO_USUARIO != null ?
                new ObjectParameter("IN_APELLIDO_USUARIO", iN_APELLIDO_USUARIO) :
                new ObjectParameter("IN_APELLIDO_USUARIO", typeof(string));
    
            var iN_RUTParameter = iN_RUT != null ?
                new ObjectParameter("IN_RUT", iN_RUT) :
                new ObjectParameter("IN_RUT", typeof(string));
    
            var iN_ACTIVOParameter = iN_ACTIVO != null ?
                new ObjectParameter("IN_ACTIVO", iN_ACTIVO) :
                new ObjectParameter("IN_ACTIVO", typeof(string));
    
            var iN_SUCURSALParameter = iN_SUCURSAL.HasValue ?
                new ObjectParameter("IN_SUCURSAL", iN_SUCURSAL) :
                new ObjectParameter("IN_SUCURSAL", typeof(decimal));
    
            var iN_FECHA_NACIMIENTOParameter = iN_FECHA_NACIMIENTO.HasValue ?
                new ObjectParameter("IN_FECHA_NACIMIENTO", iN_FECHA_NACIMIENTO) :
                new ObjectParameter("IN_FECHA_NACIMIENTO", typeof(System.DateTime));
    
            var iN_SEXOParameter = iN_SEXO != null ?
                new ObjectParameter("IN_SEXO", iN_SEXO) :
                new ObjectParameter("IN_SEXO", typeof(string));
    
            var iN_NACIONALIDADParameter = iN_NACIONALIDAD != null ?
                new ObjectParameter("IN_NACIONALIDAD", iN_NACIONALIDAD) :
                new ObjectParameter("IN_NACIONALIDAD", typeof(string));
    
            var iN_PASSAPORTEParameter = iN_PASSAPORTE != null ?
                new ObjectParameter("IN_PASSAPORTE", iN_PASSAPORTE) :
                new ObjectParameter("IN_PASSAPORTE", typeof(string));
    
            var iN_COMUNA_IDParameter = iN_COMUNA_ID.HasValue ?
                new ObjectParameter("IN_COMUNA_ID", iN_COMUNA_ID) :
                new ObjectParameter("IN_COMUNA_ID", typeof(decimal));
    
            var iN_REGION_IDParameter = iN_REGION_ID.HasValue ?
                new ObjectParameter("IN_REGION_ID", iN_REGION_ID) :
                new ObjectParameter("IN_REGION_ID", typeof(decimal));
    
            var iN_EMAILParameter = iN_EMAIL != null ?
                new ObjectParameter("IN_EMAIL", iN_EMAIL) :
                new ObjectParameter("IN_EMAIL", typeof(string));
    
            var iN_CELULARParameter = iN_CELULAR.HasValue ?
                new ObjectParameter("IN_CELULAR", iN_CELULAR) :
                new ObjectParameter("IN_CELULAR", typeof(decimal));
    
            var iN_PUNTOSParameter = iN_PUNTOS.HasValue ?
                new ObjectParameter("IN_PUNTOS", iN_PUNTOS) :
                new ObjectParameter("IN_PUNTOS", typeof(decimal));
    
            var iN_CODIGO_VERIFICACIONParameter = iN_CODIGO_VERIFICACION != null ?
                new ObjectParameter("IN_CODIGO_VERIFICACION", iN_CODIGO_VERIFICACION) :
                new ObjectParameter("IN_CODIGO_VERIFICACION", typeof(string));
    
            var iN_FECHA_CREACIONParameter = iN_FECHA_CREACION.HasValue ?
                new ObjectParameter("IN_FECHA_CREACION", iN_FECHA_CREACION) :
                new ObjectParameter("IN_FECHA_CREACION", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USUARIO_CREAR", iN_PERFIL_IDParameter, iN_LOGIN_USUARIOParameter, iN_PASS_USUARIOParameter, iN_NOMBRE_USUARIOParameter, iN_APELLIDO_USUARIOParameter, iN_RUTParameter, iN_ACTIVOParameter, iN_SUCURSALParameter, iN_FECHA_NACIMIENTOParameter, iN_SEXOParameter, iN_NACIONALIDADParameter, iN_PASSAPORTEParameter, iN_COMUNA_IDParameter, iN_REGION_IDParameter, iN_EMAILParameter, iN_CELULARParameter, iN_PUNTOSParameter, iN_CODIGO_VERIFICACIONParameter, iN_FECHA_CREACIONParameter);
        }
    
        public virtual int USUARIO_DESACTIVAR(string iN_LOGIN)
        {
            var iN_LOGINParameter = iN_LOGIN != null ?
                new ObjectParameter("IN_LOGIN", iN_LOGIN) :
                new ObjectParameter("IN_LOGIN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USUARIO_DESACTIVAR", iN_LOGINParameter);
        }
    
        public virtual int USUARIO_EDITAR(string iN_LOGIN, string iN_NOMBRE, string iN_APELLIDO, Nullable<System.DateTime> iN_FECHA_NACIMIENTO, Nullable<decimal> iN_COMUNA_ID, Nullable<decimal> iN_REGION_ID, string iN_CORREO, string iN_TELEFONO, Nullable<decimal> iN_PUNTOS)
        {
            var iN_LOGINParameter = iN_LOGIN != null ?
                new ObjectParameter("IN_LOGIN", iN_LOGIN) :
                new ObjectParameter("IN_LOGIN", typeof(string));
    
            var iN_NOMBREParameter = iN_NOMBRE != null ?
                new ObjectParameter("IN_NOMBRE", iN_NOMBRE) :
                new ObjectParameter("IN_NOMBRE", typeof(string));
    
            var iN_APELLIDOParameter = iN_APELLIDO != null ?
                new ObjectParameter("IN_APELLIDO", iN_APELLIDO) :
                new ObjectParameter("IN_APELLIDO", typeof(string));
    
            var iN_FECHA_NACIMIENTOParameter = iN_FECHA_NACIMIENTO.HasValue ?
                new ObjectParameter("IN_FECHA_NACIMIENTO", iN_FECHA_NACIMIENTO) :
                new ObjectParameter("IN_FECHA_NACIMIENTO", typeof(System.DateTime));
    
            var iN_COMUNA_IDParameter = iN_COMUNA_ID.HasValue ?
                new ObjectParameter("IN_COMUNA_ID", iN_COMUNA_ID) :
                new ObjectParameter("IN_COMUNA_ID", typeof(decimal));
    
            var iN_REGION_IDParameter = iN_REGION_ID.HasValue ?
                new ObjectParameter("IN_REGION_ID", iN_REGION_ID) :
                new ObjectParameter("IN_REGION_ID", typeof(decimal));
    
            var iN_CORREOParameter = iN_CORREO != null ?
                new ObjectParameter("IN_CORREO", iN_CORREO) :
                new ObjectParameter("IN_CORREO", typeof(string));
    
            var iN_TELEFONOParameter = iN_TELEFONO != null ?
                new ObjectParameter("IN_TELEFONO", iN_TELEFONO) :
                new ObjectParameter("IN_TELEFONO", typeof(string));
    
            var iN_PUNTOSParameter = iN_PUNTOS.HasValue ?
                new ObjectParameter("IN_PUNTOS", iN_PUNTOS) :
                new ObjectParameter("IN_PUNTOS", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USUARIO_EDITAR", iN_LOGINParameter, iN_NOMBREParameter, iN_APELLIDOParameter, iN_FECHA_NACIMIENTOParameter, iN_COMUNA_IDParameter, iN_REGION_IDParameter, iN_CORREOParameter, iN_TELEFONOParameter, iN_PUNTOSParameter);
        }
    
        public virtual int USUARIO_ELIMINAR(string iN_LOGIN)
        {
            var iN_LOGINParameter = iN_LOGIN != null ?
                new ObjectParameter("IN_LOGIN", iN_LOGIN) :
                new ObjectParameter("IN_LOGIN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USUARIO_ELIMINAR", iN_LOGINParameter);
        }
    }
}
