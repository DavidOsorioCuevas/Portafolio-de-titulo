using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Oferta
    {
        public int IdOferta { get; set; }
        public string ImagenOferta { get; set; }
        public int MinProductos { get; set; }
        public int MaxProductos { get; set; }
        public char? EstadoOferta { get; set; }
        public DateTime? FechaOferta { get; set; }
        public int IdSucursal { get; set; }
        public int CategoriaIdOferta { get; set; }
        public int IdProducto { get; set; }
        public int IdRegion { get; set; }
        public int IdComuna { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Oferta()
        {
            this.Init();
        }

        public Oferta(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Oferta));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            Negocio.Oferta of = new Negocio.Oferta();

            this.IdOferta = of.IdOferta;
            this.ImagenOferta = of.ImagenOferta;
            this.MinProductos = of.MinProductos;
            this.MaxProductos = of.MaxProductos;
            this.EstadoOferta = of.EstadoOferta;
            this.FechaOferta = of.FechaOferta;
            this.IdSucursal = of.IdSucursal;
            this.CategoriaIdOferta = of.CategoriaIdOferta;
            this.IdProducto = of.IdProducto;
            this.IdRegion = of.IdRegion;
            this.IdComuna = of.IdComuna;
            this.Nombre = of.Nombre;
            this.Descripcion = of.Descripcion;
        }

        private void Init()
        {
            this.IdOferta = 0;
            this.ImagenOferta = null;
            this.MinProductos = 0;
            this.MaxProductos = 0;
            this.EstadoOferta = null;
            this.FechaOferta = null;
            this.IdSucursal = 0;
            this.CategoriaIdOferta = 0;
            this.IdProducto = 0;
            this.IdRegion = 0;
            this.IdComuna = 0;
            this.Nombre = null;
            this.Descripcion = null;
        }

        public bool CrearOferta()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.OFERTA of = new DALC.OFERTA();

                of.ID_OFERTA = this.IdOferta;
                of.IMAGEN_OFERTA = this.ImagenOferta;
                of.MIN_PRODUCTO = this.MinProductos;
                of.MAX_PRODUCTO = this.MaxProductos;
                of.ESTADO_OFERTA = this.EstadoOferta.ToString();
                of.FECHA_OFERTA = this.FechaOferta;
                of.SUCURSALES_ID = this.IdSucursal;
                of.CATEGORIA_OFERTA_ID = this.CategoriaIdOferta;
                of.PRODUCTO_ID = this.IdProducto;
                of.REGION_ID = this.IdRegion;
                of.COMUNA_ID = this.IdComuna;
                of.NOMBRE = this.Nombre;
                of.DESCRIPCION = this.Descripcion;

                ctx.OFERTA.Add(of);
                ctx.SaveChanges();
                ctx = null;

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool ActualizarOferta()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.OFERTA of = ctx.OFERTA.First(o => o.ID_OFERTA == IdOferta);

                of.IMAGEN_OFERTA = this.ImagenOferta;
                of.MIN_PRODUCTO = this.MinProductos;
                of.MAX_PRODUCTO = this.MaxProductos;
                of.ESTADO_OFERTA = this.EstadoOferta.ToString();
                of.FECHA_OFERTA = this.FechaOferta;
                of.SUCURSALES_ID = this.IdSucursal;
                of.CATEGORIA_OFERTA_ID = this.CategoriaIdOferta;
                of.PRODUCTO_ID = this.IdProducto;
                of.REGION_ID = this.IdRegion;
                of.COMUNA_ID = this.IdComuna;
                of.NOMBRE = this.Nombre;
                of.DESCRIPCION = this.Descripcion;

                ctx.SaveChanges();
                ctx = null;
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool EliminarOferta()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.OFERTA of = ctx.OFERTA.First(o => o.ID_OFERTA == IdOferta);

                ctx.Entry(of).State = System.Data.EntityState.Deleted;
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
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Oferta));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);
            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();
        }


    }
}
