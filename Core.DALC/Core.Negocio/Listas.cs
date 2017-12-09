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

        public string promedioValoracion(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(FilterParameter));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            FilterParameter f = (FilterParameter)serializador.ReadObject(stream);
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();

            int IdOferta = int.Parse(f.parameter);
            var consulta = from a in ctx.VALORACION where a.OFERTA_ID == IdOferta select new { a };

            
            List<int> cal = new List<int>();
            foreach (var item in consulta)
            {
                if (item.a.CALIFICACION.Equals("buena"))
                {
                    cal.Add(2);
                }
                if (item.a.CALIFICACION.Equals("mala"))
                {
                    cal.Add(1);
                }
                if (item.a.CALIFICACION.Equals("excelente"))
                {
                    cal.Add(3);
                }
            }
            int cont = 0;
            float sum = 0;
            foreach (var item in cal)
            {
                sum = sum + item;
                cont++;
            }
            float prom = sum / cont;

            if (cont==0)
            {
                f.parameter = "Sin valoraciones";
            }

            if (prom>1 && prom<=(1.8))
            {
                f.parameter = "Mala";
            }

            if (prom > 1.8 && prom <= (2.8))
            {
                f.parameter = "Buena";
            }

            if (prom > 2.8)
            {
                f.parameter = "Excelente";
            }

            return SerializarFilterParameterUnico(f);
        }
        public string traerCupones(string json) {
          
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(FilterParameter));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            FilterParameter f = (FilterParameter)serializador.ReadObject(stream);
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();

            int IdUsuario = int.Parse(f.parameter);
            var result = from a in ctx.CUPON where a.USUARIO_ID.Equals(IdUsuario) select new { a };
            List<Cupon> cupones = new List<Cupon>();
            foreach (var item in result)
            {
                Cupon c = new Cupon();
                c.Codigo = item.a.CODIGO;
                
                c.fc = item.a.FECHA_HASTA.Value.ToShortDateString();
                var descuento = from a in ctx.DESCUENTO where a.ID_DESCUENTO.Equals(item.a.DESCUENTO_ID) select new { a };
                Descuento d = new Descuento();
                
               

                var r = from a in ctx.CATEGORIA_OFERTA join tempo in ctx.DESCUENTO_HAS_RUBRO on a.ID_CATEGORIA_OFERTA equals tempo.RUBRO_ID where tempo.DESCUENTO_ID == item.a.DESCUENTO_ID select new { a };
                List<CategoriaOferta> cat = new List<CategoriaOferta>();
                foreach (var itemc in r)
                {
                    CategoriaOferta ce = new CategoriaOferta();
                    ce.IdCategoria = (int)itemc.a.ID_CATEGORIA_OFERTA;
                    ce.Nombre = itemc.a.NOMBRE;
                    cat.Add(ce);
                }
                d.Categorias = cat;
                d.Porcentaje = (int)ctx.DESCUENTO.Find(item.a.DESCUENTO_ID).PORCENTAJE;
                d.MinPuntos = (int)ctx.DESCUENTO.Find(item.a.DESCUENTO_ID).MIN_PUNTOS;
                d.Tope = (int)ctx.DESCUENTO.Find(item.a.DESCUENTO_ID).TOPE;
                c.Descuento = d;
                cupones.Add(c);
            }
            string s = SerializarCupones(cupones);
            return SerializarCupones(cupones);
        }
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
            cup.CODIGO = result.First().RUT+"V";
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

        public string SerializarCupones(List<Cupon> cupon)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(List<Cupon>));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, cupon);

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

        public string SerializarFilterParameterUnico(FilterParameter filter)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(FilterParameter));
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

        public string SerializarRetail(List<Retail> retail)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(List<Retail>));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, retail);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
        public string SerializarSucursales(List<Sucursal> sucursal)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(List<Sucursal>));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, sucursal);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }

        public string SerializarCategoria(List<CategoriaOferta> categoria)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(List<CategoriaOferta>));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, categoria);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }

        public string filtrar(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(FilterParameter));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            FilterParameter f = (FilterParameter)serializador.ReadObject(stream);
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            int minimo = f.min;
            int maximo = f.max;
            string parametro = f.parameter;
            int IdCategoria = f.IdCategoria;
            int IdRetail = f.IdRetail;
            List<Oferta> ofertas = new List<Oferta>();


            switch (parametro)
            {
                case "SMM":
                    var query1 = from a in ctx.OFERTA where a.PRECIO_DESPUES >= minimo && a.PRECIO_DESPUES <= maximo select new { a };
                    

                    foreach (var item in query1)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MIN_PRODUCTO;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        ofertas.Add(of);
                    }
                    return SerializarOferta(ofertas);
                    

                case "SMi":
                    var query2 = from a in ctx.OFERTA where a.PRECIO_DESPUES >= minimo select new { a };
                    foreach (var item in query2)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MIN_PRODUCTO;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        ofertas.Add(of);
                    }
                    return SerializarOferta(ofertas);

                case "TODO":
                    var query3 = from a in ctx.OFERTA
                             join c in ctx.OFERTA_HAS_SUCURSAL on a.ID_OFERTA equals c.OFERTA_ID
                             join b in ctx.SUCURSALES on c.SUCURSAL_ID equals b.ID_SUCURSAL
                             where b.RETAIL_ID==IdRetail && a.PRECIO_DESPUES >= minimo && a.PRECIO_DESPUES<=maximo && a.CATEGORIA_OFERTA_ID==IdCategoria
                             select new { a };
                    foreach (var item in query3)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MIN_PRODUCTO;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        ofertas.Add(of);
                    }
                    return SerializarOferta(ofertas);

                case "SCAT":
                    var query4 = from a in ctx.OFERTA           
                            where a.CATEGORIA_OFERTA_ID == IdCategoria
                            select new { a };
                    foreach (var item in query4)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MIN_PRODUCTO;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        ofertas.Add(of);
                    }
                    return SerializarOferta(ofertas);

                case "SRET":
                    var query5 = from a in ctx.OFERTA
                            join c in ctx.OFERTA_HAS_SUCURSAL on a.ID_OFERTA equals c.OFERTA_ID
                            join b in ctx.SUCURSALES on c.SUCURSAL_ID equals b.ID_SUCURSAL
                            where b.RETAIL_ID == IdRetail
                            select new { a };
                    foreach (var item in query5)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MIN_PRODUCTO;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        ofertas.Add(of);
                    }
                    return SerializarOferta(ofertas);

                case "SCATRET":
                    var query6 = from a in ctx.OFERTA
                            join c in ctx.OFERTA_HAS_SUCURSAL on a.ID_OFERTA equals c.OFERTA_ID
                            join b in ctx.SUCURSALES on c.SUCURSAL_ID equals b.ID_SUCURSAL
                            where b.RETAIL_ID == IdRetail && a.CATEGORIA_OFERTA_ID == IdCategoria
                            select new { a };
                    foreach (var item in query6)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MIN_PRODUCTO;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        ofertas.Add(of);
                    }
                    return SerializarOferta(ofertas);

                case "SCARETMAX":
                    var query7 = from a in ctx.OFERTA
                            join c in ctx.OFERTA_HAS_SUCURSAL on a.ID_OFERTA equals c.OFERTA_ID
                            join b in ctx.SUCURSALES on c.SUCURSAL_ID equals b.ID_SUCURSAL
                            where b.RETAIL_ID == IdRetail && a.PRECIO_DESPUES <= maximo && a.CATEGORIA_OFERTA_ID == IdCategoria
                            select new { a };
                    foreach (var item in query7)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MIN_PRODUCTO;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        ofertas.Add(of);
                    }
                    return SerializarOferta(ofertas);

                case "SCARETMIN":
                    var query8 = from a in ctx.OFERTA
                            join c in ctx.OFERTA_HAS_SUCURSAL on a.ID_OFERTA equals c.OFERTA_ID
                            join b in ctx.SUCURSALES on c.SUCURSAL_ID equals b.ID_SUCURSAL
                            where b.RETAIL_ID == IdRetail && a.PRECIO_DESPUES >= minimo && a.CATEGORIA_OFERTA_ID == IdCategoria
                            select new { a };
                    foreach (var item in query8)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MIN_PRODUCTO;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        ofertas.Add(of);
                    }
                    return SerializarOferta(ofertas);

                case "SCAMAX":
                    var query9 = from a in ctx.OFERTA
                            join c in ctx.OFERTA_HAS_SUCURSAL on a.ID_OFERTA equals c.OFERTA_ID
                            join b in ctx.SUCURSALES on c.SUCURSAL_ID equals b.ID_SUCURSAL
                            where  a.PRECIO_DESPUES <= maximo && a.CATEGORIA_OFERTA_ID == IdCategoria
                            select new { a };
                    foreach (var item in query9)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MIN_PRODUCTO;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        ofertas.Add(of);
                    }
                    return SerializarOferta(ofertas);

                case "SCAMIN":
                    var query10 = from a in ctx.OFERTA
                            join c in ctx.OFERTA_HAS_SUCURSAL on a.ID_OFERTA equals c.OFERTA_ID
                            join b in ctx.SUCURSALES on c.SUCURSAL_ID equals b.ID_SUCURSAL
                            where a.PRECIO_DESPUES >= minimo && a.CATEGORIA_OFERTA_ID == IdCategoria
                            select new { a };
                    foreach (var item in query10)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MIN_PRODUCTO;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        ofertas.Add(of);
                    }
                    return SerializarOferta(ofertas);

                case "SRETMAX":
                    var query11 = from a in ctx.OFERTA
                            join c in ctx.OFERTA_HAS_SUCURSAL on a.ID_OFERTA equals c.OFERTA_ID
                            join b in ctx.SUCURSALES on c.SUCURSAL_ID equals b.ID_SUCURSAL
                            where a.PRECIO_DESPUES <= maximo && b.RETAIL_ID == IdRetail
                            select new { a };
                    foreach (var item in query11)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MIN_PRODUCTO;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        ofertas.Add(of);
                    }
                    return SerializarOferta(ofertas);

                case "SRETMIN":
                    var query12 = from a in ctx.OFERTA
                            join c in ctx.OFERTA_HAS_SUCURSAL on a.ID_OFERTA equals c.OFERTA_ID
                            join b in ctx.SUCURSALES on c.SUCURSAL_ID equals b.ID_SUCURSAL
                            where a.PRECIO_DESPUES >= minimo && b.RETAIL_ID == IdRetail
                            select new { a };
                    foreach (var item in query12)
                    {
                        Oferta of = new Oferta();
                        of.IdOferta = (int)item.a.ID_OFERTA;
                        of.CategoriaIdOferta = (int)item.a.CATEGORIA_OFERTA_ID;
                        of.PrecioAntes = (int)item.a.PRECIO_ANTES;
                        of.PrecioOferta = (int)item.a.PRECIO_DESPUES;
                        of.Nombre = item.a.NOMBRE;
                        of.Descripcion = item.a.DESCRIPCION;
                        of.ImagenOferta = item.a.IMAGEN_OFERTA;
                        of.MinProductos = (int)item.a.MIN_PRODUCTO;
                        of.MaxProductos = (int)item.a.MIN_PRODUCTO;
                        of.FechaOferta = item.a.FECHA_OFERTA;
                        ofertas.Add(of);
                    }
                    return SerializarOferta(ofertas);


                default:
                    return "[]";
                    
            }
           


            
        }

        public string deshacerValoracion(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(FilterParameter));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            FilterParameter f = (FilterParameter)serializador.ReadObject(stream);
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            int IdValoracion = int.Parse(f.parameter);

            try
            {
                Core.DALC.VALORACION val = (Core.DALC.VALORACION)ctx.VALORACION.Where(b => b.ID_VALORACION == IdValoracion).First();
                ctx.VALORACION.Remove(val);
                ctx.SaveChanges();
                f.parameter = "OK";
            }
            catch (Exception)
            {

                f.parameter = "NO";
            }
            
            return SerializarFilterParameterUnico(f);
        }

        public string traerValoraciones(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(FilterParameter));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            FilterParameter f = (FilterParameter)serializador.ReadObject(stream);
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();

            int IdUsuario = int.Parse(f.parameter);

            var t = from a in ctx.VALORACION join tm in ctx.OFERTA on a.OFERTA_ID equals tm.ID_OFERTA where a.USUARIO_ID==IdUsuario orderby a.FECHA_VALORACION descending select new { a,tm };

            List<Valoracion> valoraciones = new List<Valoracion>();
            foreach (var itemc in t)
            {
                Valoracion val = new Valoracion();
                val.IdOferta = (int)itemc.a.OFERTA_ID;
                val.IdValoracion = (int)itemc.a.ID_VALORACION;
                val.Calificacion = itemc.a.CALIFICACION;
                val.codeImagen = itemc.a.CODE_IMAGEN;
                val.fechaValoracion = itemc.a.FECHA_VALORACION.Value.ToShortDateString();
                val.Comentario = itemc.a.COMENTARIO;
                val.nombreOferta = itemc.tm.NOMBRE;
                valoraciones.Add(val);
            }

            return SerializarValoraciones(valoraciones);
        }

        public string traerValoracionesOferta(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(FilterParameter));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            FilterParameter f = (FilterParameter)serializador.ReadObject(stream);
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();

            int IdOferta = int.Parse(f.parameter);

            var t = from a in ctx.VALORACION join tm in ctx.OFERTA on a.OFERTA_ID equals tm.ID_OFERTA
                    join us in ctx.USUARIO on a.USUARIO_ID equals us.ID_USUARIO
                    where a.OFERTA_ID == IdOferta orderby a.FECHA_VALORACION descending select new { a, tm , us};

            List<Valoracion> valoraciones = new List<Valoracion>();
            foreach (var itemc in t)
            {
                Valoracion val = new Valoracion();
                val.nombreUsuario = itemc.us.NOMBRE + " " + itemc.us.APELLIDO;
                val.IdOferta = (int)itemc.a.OFERTA_ID;
                val.IdValoracion = (int)itemc.a.ID_VALORACION;
                val.Calificacion = itemc.a.CALIFICACION;
                val.codeImagen = itemc.a.CODE_IMAGEN;
                val.fechaValoracion = itemc.a.FECHA_VALORACION.Value.ToShortDateString();
                val.Comentario = itemc.a.COMENTARIO;
                val.nombreOferta = itemc.tm.NOMBRE;
                valoraciones.Add(val);
            }

            return SerializarValoraciones(valoraciones);
        }


        public string traerRetail() {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            var r = from a in ctx.RETAIL select new { a };
            List<Retail> retail = new List<Retail>();
            foreach (var item in r)
            {
                Retail temp = new Retail();
                temp.NombreRetail = item.a.NOMBRE;
                temp.IdRetail = (int)item.a.ID_RETAIL;
                retail.Add(temp);
            }
            return SerializarRetail(retail);
        }

        public string traerCategorías()
        {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            var c = from a in ctx.CATEGORIA_OFERTA select new { a };
            List<CategoriaOferta> categorias = new List<CategoriaOferta>();
            foreach (var item in c)
            {
                CategoriaOferta temp = new CategoriaOferta();
                temp.Nombre = item.a.NOMBRE;
                temp.IdCategoria = (int)item.a.ID_CATEGORIA_OFERTA;
                categorias.Add(temp);
            }

            return SerializarCategoria(categorias);
        }
        public string traerSucursales(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(FilterParameter));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            FilterParameter f = (FilterParameter)serializador.ReadObject(stream);
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();

            int IdOferta = int.Parse(f.parameter);

            var t = from a in ctx.SUCURSALES join temp in ctx.OFERTA_HAS_SUCURSAL on a.ID_SUCURSAL equals temp.SUCURSAL_ID where temp.OFERTA_ID==IdOferta select new { a };

            List<Sucursal> sucursales = new List<Sucursal>();
            foreach (var itemc in t)
            {
                Sucursal suc = new Sucursal();
                suc.IdSucursal = (int)itemc.a.ID_SUCURSAL;
                suc.Nombre = itemc.a.NOMBRE;
                suc.Direccion = itemc.a.DIRECCION;
                suc.Telefono = (int)itemc.a.TELEFONO;
                suc.Email = itemc.a.EMAIL;
                suc.Latitud = itemc.a.LATITUD;
                suc.Longitud = itemc.a.LONGITUD;
                sucursales.Add(suc);
            }

            return SerializarSucursales(sucursales);
        }
    }
}
