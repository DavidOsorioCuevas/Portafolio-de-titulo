using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Comuna
    {
        public int IdComuna { get; set; }
        public string Nombre { get; set; }
        public int IdRegion { get; set; }
        public Comuna() { }
        public Comuna(int IdComuna, string Nombre,int IdRegion)
        {
            this.IdComuna = IdComuna;
            this.Nombre = Nombre;
            this.IdRegion = IdRegion;
        }

        public string Serializar()
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Comuna));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);
            string ser = Encoding.UTF8.GetString(stream.ToArray());
            return ser.ToString();
        }
    }
}
