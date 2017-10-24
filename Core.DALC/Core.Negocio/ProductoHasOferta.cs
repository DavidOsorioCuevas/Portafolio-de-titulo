using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class ProductoHasOferta
    {
        public int IdProductoHasOferta { get; set; }
        public int ProductoId { get; set; }
        public int OfertaId { get; set; }

        public ProductoHasOferta()
        {
            this.Init();
        }

        public ProductoHasOferta(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(ProductoHasOferta));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            ProductoHasOferta des = (ProductoHasOferta)serializador.ReadObject(stream);

            this.IdProductoHasOferta = des.IdProductoHasOferta;
            this.ProductoId = des.ProductoId;
            this.OfertaId = des.OfertaId;
        }

        private void Init()
        {
            IdProductoHasOferta = 0;
            ProductoId = 0;
            OfertaId = 0;
        }

        public bool CrearProductoHasOferta()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                ProductoHasOferta pho = new ProductoHasOferta();

                pho.IdProductoHasOferta = this.IdProductoHasOferta;
                pho.ProductoId = this.ProductoId;
                pho.OfertaId = this.OfertaId;

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
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ProductoHasOferta));
            MemoryStream stream = new MemoryStream();

            ser.WriteObject(stream, this);
            string serializador = Encoding.UTF8.GetString(stream.ToArray());

            return serializador.ToString();
        }
    }
}
