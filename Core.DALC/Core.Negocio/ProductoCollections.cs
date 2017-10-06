using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class ProductoCollections : List<Producto>
    {
        public ProductoCollections() { }

        public ProductoCollections(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(ProductoCollections));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            ProductoCollections prodList = (ProductoCollections)serializador.ReadObject(stream);

            this.AddRange(prodList);
        }

        private ProductoCollections GenerarLista(List<DALC.PRODUCTO> listaDALC)
        {

            ProductoCollections list = new ProductoCollections();
            foreach (var item in listaDALC)
            {
                Producto pro = new Producto();

                pro.IdProducto = (int)item.ID_PRODUCTO;
                pro.IdRubro = (int)item.RUBRO_ID;
                pro.Precio = (int)item.PRECIO;
                pro.Sku = item.SKU;
                pro.CodigoInterno = item.CODIGO_INTERNO;
                pro.Nombre = item.NOMBRE;
                pro.Descripcion = item.DESCRIPCION;
                pro.IdOferta = (int)item.OFERTA_ID;

                list.Add(pro);

            }

            return list;
        }

        public string ReadAllProductos()
        {

            var listaDA = new DALC.QueOfrecesEntities().PRODUCTO;
            return GenerarLista(listaDA.ToList()).Serializar();

        }

        public string Serializar()
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(ProductoCollections));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }
}
