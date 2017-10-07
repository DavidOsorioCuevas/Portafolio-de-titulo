using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public int IdRubro { get; set; }
        public int Precio { get; set; }
        public string CodigoInterno { get; set; }
        public string Nombre { get; set; }
        private string sku;
        public string Sku
        {
            get
            {
                Rubro ru = new Rubro();
                sku = Nombre.Substring(0, 3);
                return sku;
            }
            set
            {
                sku = value;
            }
        } // logica
        public string Descripcion { get; set; }

        public Producto()
        {

            this.Init();
        }

        public Producto(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Producto));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            Producto prod = new Producto();

            this.IdProducto = prod.IdProducto;
            this.IdRubro = prod.IdRubro;
            this.Precio = prod.Precio;
            this.CodigoInterno = prod.CodigoInterno;
            this.Nombre = prod.Nombre;
            this.Sku = prod.Sku;
            this.Descripcion = prod.Descripcion;

        }

        private void Init()
        {
            this.IdProducto = 0;
            this.IdRubro = 0;
            this.Precio = 0;
            this.Sku = null;
            this.CodigoInterno = null;
            this.Nombre = null;
            this.Descripcion = null;
        }

        public bool CrearProducto()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.PRODUCTO prod = new DALC.PRODUCTO();

                prod.ID_PRODUCTO = this.IdProducto;
                prod.RUBRO_ID = this.IdRubro;
                prod.PRECIO = this.Precio;
                prod.SKU = this.Sku;
                prod.CODIGO_INTERNO = this.CodigoInterno;
                prod.NOMBRE = this.Nombre;
                prod.DESCRIPCION = this.Descripcion;

                ctx.PRODUCTO.Add(prod);

                ctx.SaveChanges();
                ctx = null;

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizarProducto()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.PRODUCTO prod = ctx.PRODUCTO.First(p => p.ID_PRODUCTO == IdProducto);

                prod.RUBRO_ID = this.IdRubro;
                prod.PRECIO = this.Precio;
                prod.SKU = this.Sku;
                prod.CODIGO_INTERNO = this.CodigoInterno;
                prod.NOMBRE = this.Nombre;
                prod.DESCRIPCION = this.Descripcion;
                ctx.PRODUCTO.Add(prod);

                ctx.SaveChanges();
                ctx = null;

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool EliminarProducto()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.PRODUCTO prod = ctx.PRODUCTO.First(p => p.ID_PRODUCTO == IdProducto);

                ctx.Entry(prod).State = System.Data.EntityState.Deleted;
                ctx.SaveChanges();
                ctx = null;

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public string Serializar()
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Producto));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);
            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();
        }
    }
}
