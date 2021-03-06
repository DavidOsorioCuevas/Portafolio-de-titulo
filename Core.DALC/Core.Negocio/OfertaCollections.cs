﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{

    public class OfertaCollections : List<Oferta>
    {
        public OfertaCollections() { }

        public OfertaCollections(string json)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(OfertaCollections));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            OfertaCollections list = (OfertaCollections)serializador.ReadObject(stream);

            this.AddRange(list);

        }


        private OfertaCollections GenerarListadoActivo(int idSucursal)
        {
            DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();

            var listaDALC = from o in ctx.OFERTA
                            where o.SUCURSALES_ID == idSucursal
                            select o;

            OfertaCollections lista = new OfertaCollections();
            foreach (var item in listaDALC)
            {
                if (item.ESTADO_OFERTA == "1")
                {

                    Oferta of = new Oferta();
                    of.IdOferta = (int)item.ID_OFERTA;
                    of.ImagenOferta = item.IMAGEN_OFERTA;
                    of.MinProductos = (int)item.MIN_PRODUCTO;
                    of.MaxProductos = (int)item.MAX_PRODUCTO;
                    of.EstadoOferta = Convert.ToChar(item.ESTADO_OFERTA);
                    of.PrecioOferta = (int)item.PRECIO_DESPUES;
                    of.PrecioAntes = (int)item.PRECIO_ANTES;
                    of.FechaOferta = item.FECHA_OFERTA;
                    of.IdSucursal = (int)item.SUCURSALES_ID;
                    of.CategoriaIdOferta = (int)item.CATEGORIA_OFERTA_ID;
                    of.Nombre = item.NOMBRE;
                    of.Descripcion = item.DESCRIPCION;
                    of.Selec = true;

                    lista.Add(of);
                }
            }
            return lista;

        }

        private OfertaCollections GenerarListadoActivoWeb()
        {
            DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();

            var listaDALC = from o in ctx.OFERTA
                            where o.ESTADO_OFERTA == "1"
                            select o;

            OfertaCollections lista = new OfertaCollections();
            foreach (var item in listaDALC)
            {
               
                    Oferta of = new Oferta();
                    of.IdOferta = (int)item.ID_OFERTA;
                    of.ImagenOferta = item.IMAGEN_OFERTA;
                    of.MinProductos = (int)item.MIN_PRODUCTO;
                    of.MaxProductos = (int)item.MAX_PRODUCTO;
                    of.EstadoOferta = Convert.ToChar(item.ESTADO_OFERTA);
                    of.PrecioOferta = (int)item.PRECIO_DESPUES;
                    of.PrecioAntes = (int)item.PRECIO_ANTES;
                    of.FechaOferta = item.FECHA_OFERTA;
                    of.IdSucursal = (int)item.SUCURSALES_ID;
                    of.CategoriaIdOferta = (int)item.CATEGORIA_OFERTA_ID;
                    of.Nombre = item.NOMBRE;
                    of.Descripcion = item.DESCRIPCION;
                    of.Selec = true;

                    lista.Add(of);
                
            }
            return lista;

        }
        private OfertaCollections GenerarListadoDesactivo(List<DALC.OFERTA> listaDALC)
        {

            OfertaCollections lista = new OfertaCollections();
            foreach (var item in listaDALC)
            {
                if (item.ESTADO_OFERTA == "0")
                {

                    Oferta of = new Oferta();
                    of.IdOferta = (int)item.ID_OFERTA;
                    of.ImagenOferta = item.IMAGEN_OFERTA;
                    of.MinProductos = (int)item.MIN_PRODUCTO;
                    of.MaxProductos = (int)item.MAX_PRODUCTO;
                    of.EstadoOferta = Convert.ToChar(item.ESTADO_OFERTA);
                    of.PrecioOferta = (int)item.PRECIO_DESPUES;
                    of.PrecioAntes = (int)item.PRECIO_ANTES;
                    of.FechaOferta = item.FECHA_OFERTA;
                    of.IdSucursal = (int)item.SUCURSALES_ID;
                    of.CategoriaIdOferta = (int)item.CATEGORIA_OFERTA_ID;
                    of.Nombre = item.NOMBRE;
                    of.Descripcion = item.DESCRIPCION;
                    of.Selec = false;

                    lista.Add(of);
                }
            }
            return lista;

        }

        private OfertaCollections GenerarListadoDia(List<DALC.OFERTA> listaDALC)
        {

            OfertaCollections lista = new OfertaCollections();
            foreach (var item in listaDALC)
            {
                if ((DateTime)item.FECHA_OFERTA.Value.Date == DateTime.Today.Date)
                {

                    Oferta of = new Oferta();
                    of.IdOferta = (int)item.ID_OFERTA;
                    of.ImagenOferta = item.IMAGEN_OFERTA;
                    of.MinProductos = (int)item.MIN_PRODUCTO;
                    of.MaxProductos = (int)item.MAX_PRODUCTO;
                    of.EstadoOferta = Convert.ToChar(item.ESTADO_OFERTA);
                    of.PrecioOferta = (int)item.PRECIO_DESPUES;
                    of.PrecioAntes = (int)item.PRECIO_ANTES;
                    of.FechaOferta = item.FECHA_OFERTA;
                    of.IdSucursal = (int)item.SUCURSALES_ID;
                    of.CategoriaIdOferta = (int)item.CATEGORIA_OFERTA_ID;
                    of.Nombre = item.NOMBRE;
                    of.Descripcion = item.DESCRIPCION;
                    of.Selec = false;

                    lista.Add(of);
                }
            }
            return lista;

        }

        private OfertaCollections GenerarListado(int idRetail)
        {
            DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();

            var listaDALC = from o in ctx.OFERTA
                            join s in ctx.SUCURSALES on o.SUCURSALES_ID equals s.ID_SUCURSAL
                            where s.RETAIL_ID == idRetail
                            select o;

            OfertaCollections lista = new OfertaCollections();
            foreach (var item in listaDALC)
            {

                Oferta of = new Oferta();
                of.IdOferta = (int)item.ID_OFERTA;
                of.ImagenOferta = item.IMAGEN_OFERTA;
                of.MinProductos = (int)item.MIN_PRODUCTO;
                of.MaxProductos = (int)item.MAX_PRODUCTO;
                of.EstadoOferta = Convert.ToChar(item.ESTADO_OFERTA);
                of.PrecioOferta = (int)item.PRECIO_DESPUES;
                of.PrecioAntes = (int)item.PRECIO_ANTES;
                of.FechaOferta = item.FECHA_OFERTA;
                of.IdSucursal = (int)item.SUCURSALES_ID;
                of.CategoriaIdOferta = (int)item.CATEGORIA_OFERTA_ID;
                of.Nombre = item.NOMBRE;
                of.Descripcion = item.DESCRIPCION;
                if (of.EstadoOferta == '1')
                {
                    of.Selec = true;
                }
                else
                {
                    of.Selec = false;
                }

                lista.Add(of);

            }
            return lista;

        }
        public string ReadAllOfertasDia()
        {

            var listaDA = new DALC.QueOfrecesEntities().OFERTA;
            return GenerarListadoDia(listaDA.ToList()).Serializar();
        }
        public string ReadAllOfertasActivo(int idSucursal)
        {            
            return GenerarListadoActivo(idSucursal).Serializar();
        }
        public string ReadAllOfertasActivoWeb()
        {
            return GenerarListadoActivoWeb().Serializar();
        }
        public string ReadAllOfertasDesactivo()
        {

            var listaDA = new DALC.QueOfrecesEntities().OFERTA;
            return GenerarListadoDesactivo(listaDA.ToList()).Serializar();
        }

        public string ReadAllOfertas(int idRetail)
        {                     
            return GenerarListado(idRetail).Serializar();
        }

        public string Serializar()
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(OfertaCollections));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }
}

