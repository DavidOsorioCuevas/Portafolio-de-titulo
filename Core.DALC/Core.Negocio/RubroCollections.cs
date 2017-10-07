using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class RubroCollections : List<Rubro>
    {
        public RubroCollections() { }

        public RubroCollections(string json)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(RubroCollections));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            RubroCollections list = (RubroCollections)serializador.ReadObject(stream);

            this.AddRange(list);

        }

        private RubroCollections GenerarListado(List<DALC.RUBRO> listaDALC)
        {

            RubroCollections lista = new RubroCollections();
            foreach (var item in listaDALC)
            {
                Rubro r = new Rubro();

                r.IdRubro = (int)item.ID_RUBRO;
                r.TipoRubro = item.TIPO;
                r.Descripcion = item.DESCRIPCION;
                                              
                lista.Add(r);
            }
            return lista;

        }

        public string ReadAllRubros()
        {

            var listaDA = new DALC.QueOfrecesEntities().RUBRO;
            return GenerarListado(listaDA.ToList()).Serializar();
        }

        public string Serializar()
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(RubroCollections));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }
}
