using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Listas
    {
        public string region()
        {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            var regiones = from a in ctx.REGION select new { a.ID_REGION,a.NOMBRE };
            List<Region> regionLista = new List<Region>();
            foreach (var item in regiones)
            {
                Region r = new Region();
                r.IdRegion = (int)item.ID_REGION;
                r.Nombre = item.NOMBRE;
                regionLista.Add(r);
            }
            
           
            return SerializarRegion(regionLista);
        }

        public string SerializarRegion(List<Region> region)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(List<Region));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, region);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }
}
