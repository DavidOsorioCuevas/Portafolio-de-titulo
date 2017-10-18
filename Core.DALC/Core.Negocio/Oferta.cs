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
        public int PrecioOferta { get; set; }
        public int PrecioAntes { get; set; }
        public int MaxProductos { get; set; }
        public char? EstadoOferta { get; set; }
        public DateTime? FechaOferta { get; set; }
        public int IdSucursal { get; set; }
        public int CategoriaIdOferta { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public char? OfertaDia { get; set; }
        public bool Selec { get; set; }

        public Oferta()
        {
            this.Init();
        }

        public Oferta(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Oferta));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            Negocio.Oferta of = (Oferta)serializador.ReadObject(stream);

            this.IdOferta = of.IdOferta;
            this.ImagenOferta = of.ImagenOferta;
            this.MinProductos = of.MinProductos;
            this.MaxProductos = of.MaxProductos;
            this.EstadoOferta = of.EstadoOferta;
            this.PrecioOferta = of.PrecioOferta;
            this.PrecioAntes = of.PrecioAntes;
            this.FechaOferta = of.FechaOferta;
            this.IdSucursal = of.IdSucursal;
            this.CategoriaIdOferta = of.CategoriaIdOferta;
            this.Nombre = of.Nombre;
            this.Descripcion = of.Descripcion;
            this.OfertaDia = of.OfertaDia;
            this.Selec = of.Selec;
        }

        private void Init()
        {
            this.IdOferta = 0;
            this.ImagenOferta = string.Empty;
            this.MinProductos = 0;
            this.MaxProductos = 0;
            this.EstadoOferta = null;
            this.FechaOferta = null;
            this.PrecioOferta = 0;
            this.PrecioAntes = 0;
            this.IdSucursal = 0;
            this.CategoriaIdOferta = 0;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
            this.OfertaDia = null;
            this.Selec = false;
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
                of.PRECIO_DESPUES = this.PrecioOferta;
                of.PRECIO_ANTES = this.PrecioAntes;
                of.SUCURSALES_ID = this.IdSucursal;
                of.CATEGORIA_OFERTA_ID = this.CategoriaIdOferta;
                of.NOMBRE = this.Nombre;
                of.DESCRIPCION = this.Descripcion;
                of.OFERTA_DIA = this.EstadoOferta.ToString();

                ctx.OFERTA.Add(of);
                ctx.SaveChanges();
                ctx = null;

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


        public string LeerOfertaId()
        {

                Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
                Core.DALC.OFERTA of = ctx.OFERTA.First(o => o.ID_OFERTA == IdOferta);

                this.ImagenOferta = of.IMAGEN_OFERTA;
                this.MinProductos = (int)of.MIN_PRODUCTO;
                this.MaxProductos = (int)of.MAX_PRODUCTO;
                this.EstadoOferta = Convert.ToChar(of.ESTADO_OFERTA);
                this.PrecioOferta = (int)of.PRECIO_DESPUES;
                this.PrecioAntes = (int)of.PRECIO_ANTES;
                this.FechaOferta = of.FECHA_OFERTA;
                this.IdSucursal = (int)of.SUCURSALES_ID;
                this.CategoriaIdOferta = (int)of.CATEGORIA_OFERTA_ID;
                this.Nombre = of.NOMBRE;
                this.Descripcion = of.DESCRIPCION;
                this.OfertaDia = Convert.ToChar(of.OFERTA_DIA);


                ctx = null;

                return Serializar();


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
                of.NOMBRE = this.Nombre;
                of.DESCRIPCION = this.Descripcion;
                of.OFERTA_DIA = this.OfertaDia.ToString();

                ctx.SaveChanges();
                ctx = null;
                return true;

            }
            catch (Exception)
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
            catch (Exception)
            {

                return false;
            }

        }


        public bool PublicarOferta()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.OFERTA of = ctx.OFERTA.First(o => o.ID_OFERTA == IdOferta && o.ESTADO_OFERTA == "0");

                of.IMAGEN_OFERTA = this.ImagenOferta;
                of.MIN_PRODUCTO = this.MinProductos;
                of.MAX_PRODUCTO = this.MaxProductos;
                of.ESTADO_OFERTA = "1";
                of.FECHA_OFERTA = this.FechaOferta;
                of.SUCURSALES_ID = this.IdSucursal;
                of.CATEGORIA_OFERTA_ID = this.CategoriaIdOferta;
                of.NOMBRE = this.Nombre;
                of.DESCRIPCION = this.Descripcion;
                of.OFERTA_DIA = this.OfertaDia.ToString();
                ctx.SaveChanges();
                ctx = null;
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool DesPubicarOferta()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.OFERTA of = ctx.OFERTA.First(o => o.ID_OFERTA == IdOferta && o.ESTADO_OFERTA == "1");

                of.IMAGEN_OFERTA = this.ImagenOferta;
                of.MIN_PRODUCTO = this.MinProductos;
                of.MAX_PRODUCTO = this.MaxProductos;
                of.ESTADO_OFERTA = "0";
                of.FECHA_OFERTA = this.FechaOferta;
                of.SUCURSALES_ID = this.IdSucursal;
                of.CATEGORIA_OFERTA_ID = this.CategoriaIdOferta;
                of.NOMBRE = this.Nombre;
                of.DESCRIPCION = this.Descripcion;
                of.OFERTA_DIA = this.OfertaDia.ToString();

                ctx.SaveChanges();
                ctx = null;

                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public string TraerOferta()
        {
            Core.DALC.QueOfrecesEntities db = new Core.DALC.QueOfrecesEntities();
            var result = from a in db.OFERTA
                         where a.ID_OFERTA == this.IdOferta
                         select new
                         {
                             a.NOMBRE,
                             a.SUCURSALES_ID,
                             a.PRECIO_ANTES,
                             a.DESCRIPCION,
                             a.PRECIO_DESPUES,
                             a.MAX_PRODUCTO,
                             a.MIN_PRODUCTO,
                             a.IMAGEN_OFERTA,
                             a.FECHA_OFERTA,
                             a.OFERTA_DIA
                         };

            this.Nombre = result.First().NOMBRE;
            this.PrecioAntes = (int)result.First().PRECIO_ANTES;
            this.PrecioOferta = (int)result.First().PRECIO_DESPUES;
            this.MaxProductos = (int)result.First().MAX_PRODUCTO;
            this.MinProductos = (int)result.First().MIN_PRODUCTO;
            this.ImagenOferta = result.First().IMAGEN_OFERTA;
            this.FechaOferta = result.First().FECHA_OFERTA;
            this.Descripcion = result.First().DESCRIPCION;
            this.OfertaDia = Convert.ToChar(result.First().OFERTA_DIA);
            this.IdSucursal = (int)result.First().SUCURSALES_ID;

            return Serializar();

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
