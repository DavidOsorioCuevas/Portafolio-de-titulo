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

        public string comuna()
        {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            var comunas = from a in ctx.COMUNA select new { a.ID_COMUNA, a.NOMBRE,a.REGION_ID };
            List<Comuna> comunaLista = new List<Comuna>();
            foreach (var item in comunas)
            {
                Comuna c = new Comuna();
                c.IdComuna = (int)item.ID_COMUNA;
                c.Nombre = item.NOMBRE;
                c.IdRegion = (int)item.REGION_ID;
                comunaLista.Add(c);
            }


            return SerializarComuna(comunaLista);
        }
        public string SerializarRegion(List<Region> region)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(List<Region>));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, region);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
        public string SerializarComuna(List<Comuna> comuna)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(List<Comuna>));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, comuna);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }
}
