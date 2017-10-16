using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class CategoriaCollections: List<CategoriaOferta>
    {
        public CategoriaCollections() { }

        public CategoriaCollections(string json)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(CategoriaCollections));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            CategoriaCollections list = (CategoriaCollections)serializador.ReadObject(stream);

            this.AddRange(list);

        }

        private CategoriaCollections GenerarListado(List<DALC.CATEGORIA_OFERTA> listaDALC)
        {

            CategoriaCollections lista = new CategoriaCollections();
            foreach (var item in listaDALC)
            {
                CategoriaOferta c = new CategoriaOferta();

                c.IdCategoria = (int)item.ID_CATEGORIA_OFERTA;
                c.Nombre = item.NOMBRE;
                lista.Add(c);
            }
            return lista;

        }

        public string ReadAllCategoria()
        {

            var listaCa = new DALC.QueOfrecesEntities().CATEGORIA_OFERTA;
            return GenerarListado(listaCa.ToList()).Serializar();
        }

        public string Serializar()
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(CategoriaCollections));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }
}
