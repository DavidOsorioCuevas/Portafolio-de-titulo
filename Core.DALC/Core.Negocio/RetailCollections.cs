using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class RetailCollections: List<Retail>
    {
        public RetailCollections() { }

        public RetailCollections(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(RetailCollections));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            RetailCollections retaList = (RetailCollections)serializador.ReadObject(stream);

            this.AddRange(retaList);
        }

        private RetailCollections GenerarLista(List<DALC.RETAIL> listaDALC)
        {

            RetailCollections list = new RetailCollections();
            foreach (var item in listaDALC)
            {
                Retail ret = new Retail();

                ret.IdRetail = (int)item.ID_RETAIL;
                ret.RutRetail = item.RUT;
                ret.NombreRetail = item.NOMBRE;
                ret.RazonSocial = item.RAZON_SOCIAL;
                ret.Telefono = (int)item.TELEFONO;
                ret.Email = item.EMAIL;
                ret.Direccion = item.DIRECCION;
                ret.IdRegion = (int)item.REGION_ID;
                ret.IdComuna = (int)item.COMUNA_ID;
                
                list.Add(ret);

            }

            return list;
        }

        public string ReadAllRetail()
        {

            var listaRe = new DALC.QueOfrecesEntities().RETAIL;
            return GenerarLista(listaRe.ToList()).Serializar();

        }

        public string Serializar()
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(RetailCollections));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }
}
