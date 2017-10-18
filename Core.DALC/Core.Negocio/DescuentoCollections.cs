using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class DescuentoCollections: List<Descuento>
    {
        public DescuentoCollections() { }

        public DescuentoCollections(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(DescuentoCollections));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            DescuentoCollections descList = (DescuentoCollections)serializador.ReadObject(stream);

            this.AddRange(descList);
        }

        private DescuentoCollections GenerarLista(List<DALC.DESCUENTO> listaDALC)
        {

            DescuentoCollections list = new DescuentoCollections();
            foreach (var item in listaDALC)
            {
                Descuento desc = new Descuento();

                desc.IdDescuento = (int)item.ID_DESCUENTO;
                desc.MinPuntos = (int)item.MIN_PUNTOS;
                desc.MaxPuntos = (int)item.MAX_PUNTOS;
                desc.FechaCaducidad = (DateTime)item.FECHA_CADUCIDAD;
                desc.Porcentaje = (int)item.PORCENTAJE;
                desc.Tope = (int)item.TOPE;

                list.Add(desc);

            }

            return list;
        }

        public string ReadAllDescuentos()
        {

            var listaDA = new DALC.QueOfrecesEntities().DESCUENTO;
            return GenerarLista(listaDA.ToList()).Serializar();

        }

        public string Serializar()
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(DescuentoCollections));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }
}
