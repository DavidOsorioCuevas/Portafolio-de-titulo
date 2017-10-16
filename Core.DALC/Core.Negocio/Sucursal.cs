﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }
        public string Rut { get; set; }
        public string RazonSocial { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int IdComuna { get; set; }
        public int IdRegion { get; set; }
        public string Email { get; set; }
        public int IdRetail { get; set; }

        public Sucursal()
        {
            this.Init();
        }

        public Sucursal(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Sucursal));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            Negocio.Sucursal suc = (Sucursal)serializador.ReadObject(stream);

            this.Direccion = suc.Direccion;
            this.Email = suc.Email;
            this.IdComuna = suc.IdComuna;
            this.IdRegion = suc.IdRegion;
            this.IdRetail = suc.IdRetail;
            this.IdSucursal = suc.IdSucursal;
            this.Nombre = suc.Nombre;
            this.RazonSocial = suc.RazonSocial;
            this.Rut = suc.Rut;
            this.Telefono = suc.Telefono;

        }

        private void Init()
        {
            this.Direccion = string.Empty;
            this.Email = string.Empty;
            this.IdComuna = 0;
            this.IdRegion = 0;
            this.IdRetail = 0;
            this.IdSucursal = 0;
            this.Nombre = string.Empty;
            this.RazonSocial = string.Empty;
            this.Rut = string.Empty;
            this.Telefono = 0;
        }

        public bool CrearSucursal()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.SUCURSALES suc = new DALC.SUCURSALES();

                suc.DIRECCION = this.Direccion;
                suc.EMAIL = this.Email;
                suc.COMUNA_ID = this.IdComuna;
                suc.REGION_ID = this.IdRegion;
                suc.RETAIL_ID = this.IdRetail;
                suc.ID_SUCURSAL = this.IdSucursal;
                suc.NOMBRE = this.Nombre;
                suc.RAZON_SOCIAL = this.RazonSocial;
                suc.RUT = this.Rut;
                suc.TELEFONO = this.Telefono;

                ctx.SUCURSALES.Add(suc);
                ctx.SaveChanges();
                ctx = null;

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool ActualizarSucursal()
        {

            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.SUCURSALES suc = ctx.SUCURSALES.First(o => o.ID_SUCURSAL == IdSucursal);

                suc.DIRECCION = this.Direccion;
                suc.EMAIL = this.Email;
                suc.COMUNA_ID = this.IdComuna;
                suc.REGION_ID = this.IdRegion;
                suc.RETAIL_ID = this.IdRetail;
                suc.ID_SUCURSAL = this.IdSucursal;
                suc.NOMBRE = this.Nombre;
                suc.RAZON_SOCIAL = this.RazonSocial;
                suc.RUT = this.Rut;
                suc.TELEFONO = this.Telefono;

                ctx.SaveChanges();
                ctx = null;
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EliminarSucursal()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.SUCURSALES suc = ctx.SUCURSALES.First(o => o.ID_SUCURSAL == IdSucursal);

                ctx.Entry(suc).State = System.Data.EntityState.Deleted;
                ctx.SaveChanges();
                ctx = null;
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public string Serializar()
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Sucursal));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);
            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }
}
