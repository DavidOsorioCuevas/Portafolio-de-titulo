using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{

    public class RegionCollections : List<Region>
    {
        public RegionCollections() { }

        public RegionCollections(string json)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(RegionCollections));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            RegionCollections list = (RegionCollections)serializador.ReadObject(stream);

            this.AddRange(list);

        }

        private RegionCollections GenerarListado(List<DALC.REGION> listaDALC)
        {

            RegionCollections lista = new RegionCollections();
            foreach (var item in listaDALC)
            {
                Region r = new Region();

                r.IdRegion = (int)item.ID_REGION;
                r.Nombre = item.NOMBRE;
                lista.Add(r);
            }
            return lista;

        }

        public string ReadAllRegiones()
        {

            var listaCa = new DALC.QueOfrecesEntities().REGION;
            return GenerarListado(listaCa.ToList()).Serializar();
        }

        public string Serializar()
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(RegionCollections));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }


}
