using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Listas
    {
        public string valoracion(string parametro)
        {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            var result = from a in ctx.VALORACION where a.ID_VALORACION.Equals(parametro) select new { a };
            List<Valoracion> val = new List<Valoracion>();
            foreach (var item in result)
            {
                Valoracion v = new Valoracion();
                v.IdValoracion = (int)item.a.ID_VALORACION;
                v.IdOferta = (int)item.a.OFERTA_ID;
                v.IdUsuario = (int)item.a.USUARIO_ID;
                v.fechaValoracion = (item.a.FECHA_VALORACION.Value.ToShortDateString()).ToString();
                v.codeImagen = item.a.CODE_IMAGEN;
                val.Add(v);
            }
            return SerializarValoraciones(val);
        }
        public string oferta(string parametro)
        {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            var result = from a in ctx.OFERTA
                         where a.NOMBRE.ToLower().Contains(parametro.ToLower()) || a.DESCRIPCION.ToLower().Contains(parametro.ToLower()) && a.ESTADO_OFERTA=="1"
                         select new
                         {
                             a
                         };
            List<Oferta> ofertaLista = new List<Oferta>();
            foreach (var item in result)
            {
               
                Oferta of = new Oferta();
                of.IdOferta = (int)item.a.ID_OFERTA;
                of.ImagenOferta = item.a.IMAGEN_OFERTA;
                of.MinProductos = (int)item.a.MIN_PRODUCTO;
                of.MaxProductos = (int)item.a.MAX_PRODUCTO;
                of.EstadoOferta = Convert.ToChar(item.a.ESTADO_OFERTA);
                of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                of.FechaOferta = item.a.FECHA_OFERTA;
                of.IdSucursal = (int)item.a.SUCURSALES_ID;
                of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                of.Nombre = item.a.NOMBRE;
                of.Descripcion = item.a.DESCRIPCION;
                of.Selec = false;

                ofertaLista.Add(of);
            }
            return SerializarOferta(ofertaLista);
        }

        public string region()
        {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            var regiones = from a in ctx.REGION select new { a.ID_REGION,a.NOMBRE };
            List<Region> regionLista = new List<Region>();
            foreach (var item in regiones)
            {
                Region r = new Region();
                r.IdRegion = (int)item.ID_REGION;
                r.Nombre = item.NOMBRE;
                regionLista.Add(r);
            }
            
           
            return SerializarRegion(regionLista);
        }

        public string comuna()
        {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            var comunas = from a in ctx.COMUNA select new { a.ID_COMUNA, a.NOMBRE,a.REGION_ID };
            List<Comuna> comunaLista = new List<Comuna>();
            foreach (var item in comunas)
            {
                Comuna c = new Comuna();
                c.IdComuna = (int)item.ID_COMUNA;
                c.Nombre = item.NOMBRE;
                c.IdRegion = (int)item.REGION_ID;
                comunaLista.Add(c);
            }


            return SerializarComuna(comunaLista);
        }


        public string Filtrar(string json) {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(FilterParameter));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            FilterParameter f = (FilterParameter)serializador.ReadObject(stream);
           
            List<Oferta> ofertaLista = new List<Oferta>();
            switch (f.parameter)
            {
                case "PRECIOMENORMAYOR":
                    var result = from a in ctx.OFERTA where a.ESTADO_OFERTA == "1" orderby a.PRECIO_DESPUES ascending select new { a };
                    foreach (var item in result)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MAX_PRODUCTO;
                        of.EstadoOferta = Convert.ToChar(item.a.ESTADO_OFERTA);
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        of.IdSucursal = (int)item.a.SUCURSALES_ID;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.Selec = false;

                        ofertaLista.Add(of);
                    }
                break;
                case "PRECIOMAYORMENOR":
                    var result2 = from a in ctx.OFERTA where a.ESTADO_OFERTA == "1" orderby a.PRECIO_DESPUES descending select new { a };
                    foreach (var item in result2)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MAX_PRODUCTO;
                        of.EstadoOferta = Convert.ToChar(item.a.ESTADO_OFERTA);
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        of.IdSucursal = (int)item.a.SUCURSALES_ID;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.Selec = false;

                        ofertaLista.Add(of);
                    }
                    break;
                case "RECIENTES":
                    var result3 = from a in ctx.OFERTA where a.ESTADO_OFERTA == "1" orderby a.FECHA_OFERTA descending select new { a };
                    foreach (var item in result3)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MAX_PRODUCTO;
                        of.EstadoOferta = Convert.ToChar(item.a.ESTADO_OFERTA);
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        of.IdSucursal = (int)item.a.SUCURSALES_ID;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.Selec = false;

                        ofertaLista.Add(of);
                    }
                    break;
            }


            
            return SerializarOferta(ofertaLista);
        }
        public string SerializarFilterParameter(List<FilterParameter> filter)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(List<FilterParameter>));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, filter);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
        public string SerializarRegion(List<Region> region)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(List<Region>));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, region);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
        public string SerializarComuna(List<Comuna> comuna)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(List<Comuna>));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, comuna);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
        public string SerializarOferta(List<Oferta> oferta)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(List<Oferta>));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, oferta);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }

        public string SerializarValoraciones(List<Valoracion> valoracion)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(List<Valoracion>));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, valoracion);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }
}
