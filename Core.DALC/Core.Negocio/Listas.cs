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

        public string traerDescuentos()
        {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            var result = from a in ctx.DESCUENTO select new { a };

            List<Descuento> descLista = new List<Descuento>();
            foreach (var item in result)
            {
                //var r = from a in ctx.DESCUENTO_HAS_RUBRO where a.DESCUENTO_ID.Equals(item.a.ID_DESCUENTO) join c in ctx.CATEGORIA_OFERTA on a.RUBRO_ID equals c.ID_CATEGORIA_OFERTA select new { a , c };
                var r = from a in ctx.CATEGORIA_OFERTA join c in ctx.DESCUENTO_HAS_RUBRO on a.ID_CATEGORIA_OFERTA equals c.RUBRO_ID where c.DESCUENTO_ID == item.a.ID_DESCUENTO select new { a };
                Descuento d = new Negocio.Descuento();

                List<CategoriaOferta> cat = new List<CategoriaOferta>();
                foreach (var itemc in r)
                {
                    CategoriaOferta ce = new CategoriaOferta();
                    ce.IdCategoria = (int)itemc.a.ID_CATEGORIA_OFERTA;
                    ce.Nombre = itemc.a.NOMBRE;
                    cat.Add(ce);
                }
                d.Categorias = cat;
                d.IdDescuento = (int)item.a.ID_DESCUENTO;
                d.MinPuntos = (int)item.a.MIN_PUNTOS;
                d.MaxPuntos = (int)item.a.MAX_PUNTOS;
                d.Porcentaje = (int)item.a.PORCENTAJE;
                d.Tope = (int)item.a.TOPE;
                descLista.Add(d);
            }

            return SerializarDescuento(descLista);
        }

        public string GenerarEcupon(string json)
        {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            Core.DALC.CUPON cup = new Core.DALC.CUPON();
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Cupon));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            Cupon c = (Cupon)serializador.ReadObject(stream);


            c.Fecha_Creacion = DateTime.Now;

            c.Fecha_Hasta = DateTime.Now.AddMonths(1);
            c.fc = c.Fecha_Hasta.ToShortDateString();
            var result = from a in ctx.USUARIO where a.ID_USUARIO.Equals(c.IdUsuario) select new { a.RUT, a.PUNTOS };
            var result2 = from a in ctx.DESCUENTO where a.ID_DESCUENTO.Equals(c.IdDescuento) select new { a.MIN_PUNTOS };

            Core.DALC.QueOfrecesEntities db = new Core.DALC.QueOfrecesEntities();
            cup.ACTIVO = 1;

            cup.DESCUENTO_ID = c.IdDescuento;
            cup.FECHA_CREACION = c.Fecha_Creacion;
            cup.FECHA_HASTA = c.Fecha_Hasta;
            cup.USUARIO_ID = c.IdUsuario;
            //cup.CODIGO = c.Fecha_Creacion.ToString()+"s"+ result.First().RUT;
            cup.CODIGO = result.First().RUT;
            db.CUPON.Add(cup);

            ctx.USUARIO.Find(c.IdUsuario).PUNTOS = result.First().PUNTOS - result2.First().MIN_PUNTOS;
            ctx.SaveChanges();
            db.SaveChanges();
            c.Codigo = cup.CODIGO;
            c.IdCupon = 10;
            Cupon response = new Cupon();
            response = c;

            return SerializarCupon(response);
        }

        public string oferta(string parametro)
        {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            var result = from a in ctx.OFERTA
                         where a.NOMBRE.ToLower().Contains(parametro.ToLower()) || a.DESCRIPCION.ToLower().Contains(parametro.ToLower()) && a.ESTADO_OFERTA == "1"
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
            var regiones = from a in ctx.REGION select new { a.ID_REGION, a.NOMBRE };
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
            var comunas = from a in ctx.COMUNA select new { a.ID_COMUNA, a.NOMBRE, a.REGION_ID };
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


        public string Filtrar(string json)
        {
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
        public string SerializarCupon(Cupon c)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Cupon));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, c);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();
        }

        public string SerializarDescuento(List<Descuento> descuento)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(List<Descuento>));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, descuento);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

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
