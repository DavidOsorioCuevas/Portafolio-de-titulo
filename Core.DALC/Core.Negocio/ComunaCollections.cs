using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class ComunaCollections : List<Comuna>
    {
        public ComunaCollections() { }

        public ComunaCollections(string json)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(ComunaCollections));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            ComunaCollections list = (ComunaCollections)serializador.ReadObject(stream);

            this.AddRange(list);

        }

        private ComunaCollections GenerarListado(List<DALC.COMUNA> listaDALC)
        {

            ComunaCollections lista = new ComunaCollections();
            foreach (var item in listaDALC)
            {


                Comuna com = new Comuna();
                com.IdComuna = (int)item.ID_COMUNA;
                com.Nombre = item.NOMBRE;
                com.IdRegion = (int)item.REGION_ID;

                lista.Add(com);

            }
            return lista;

        }

        public string ReadAllComuna()
        {

            var listaDA = new DALC.QueOfrecesEntities().COMUNA;
            return GenerarListado(listaDA.ToList()).Serializar();
        }

        public string Serializar()
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(ComunaCollections));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }

    }
}
