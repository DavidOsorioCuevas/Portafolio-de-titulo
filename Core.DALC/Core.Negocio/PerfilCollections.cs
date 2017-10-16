using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class PerfilCollections: List<Perfil>
    {
        public PerfilCollections() { }

        public PerfilCollections(string json)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(PerfilCollections));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            PerfilCollections list = (PerfilCollections)serializador.ReadObject(stream);

            this.AddRange(list);

        }

        private PerfilCollections GenerarListado(List<DALC.PERFIL> listaDALC)
        {

            PerfilCollections lista = new PerfilCollections();
            foreach (var item in listaDALC)
            {
                Perfil p = new Perfil();

                p.IdPerfil = (int)item.ID_PERFIL;
                p.Tipo = item.TIPO;
                lista.Add(p);
            }
            return lista;

        }

        public string ReadAllPerfil()
        {

            var listaPe = new DALC.QueOfrecesEntities().PERFIL;
            return GenerarListado(listaPe.ToList()).Serializar();
        }

        public string Serializar()
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(PerfilCollections));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }
}
