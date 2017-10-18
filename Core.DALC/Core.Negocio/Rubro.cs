using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Rubro
    {
        public int IdRubro { get; set; }
        public string TipoRubro { get; set; }
        public string Descripcion { get; set; }

        public Rubro()
        {
            this.Init();
        }

        public Rubro(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Rubro));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            Rubro rub = (Rubro)serializador.ReadObject(stream);

            this.IdRubro = rub.IdRubro;
            this.TipoRubro = rub.TipoRubro;
            this.Descripcion = rub.Descripcion;
        }

        private void Init()
        {
            this.IdRubro = 0;
            this.TipoRubro = string.Empty;
            this.Descripcion = string.Empty;
        }
        //OK
        public bool CrearRubro()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                Core.DALC.RUBRO ru = new Core.DALC.RUBRO();

                ru.ID_RUBRO = this.IdRubro;
                ru.TIPO = this.TipoRubro;
                ru.DESCRIPCION = this.Descripcion;
                ctx.RUBRO.Add(ru);
                ctx.SaveChanges();

                ctx = null;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //probar metodo
        public bool ActualizarRubro()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.RUBRO ru = ctx.RUBRO.First(r => r.TIPO == TipoRubro);

                ru.TIPO = this.TipoRubro;
                ru.DESCRIPCION = this.Descripcion;
                ctx.SaveChanges();
                ctx = null;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //OK
        public bool EliminarRubro()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.RUBRO ru = ctx.RUBRO.First(r => r.TIPO == TipoRubro);

                ctx.Entry(ru).State = System.Data.EntityState.Deleted;
                ctx.SaveChanges();
                ctx = null;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public string Serializar()
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Rubro));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);
            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }



    }
}
