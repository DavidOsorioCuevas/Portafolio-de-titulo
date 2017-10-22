using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Valoracion
    {
        public int IdUsuario { get; set; }
        public int IdOferta { get; set; }

        public int IdValoracion { get; set; }

        public int Calificacion { get; set; }
        public string codeImagen { get; set; }

        public string fechaValoracion { get; set; }

        public string response { get; set; }
        public Valoracion() { }

        
        public Valoracion(string json) {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Usuario));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            Valoracion val = (Valoracion)serializador.ReadObject(stream);
            this.Calificacion = val.Calificacion;
            this.IdUsuario = val.IdUsuario;
            this.IdOferta = val.IdOferta;
            this.IdValoracion = val.IdValoracion;
            this.codeImagen = val.codeImagen;
            this.fechaValoracion = val.fechaValoracion;
        }

        public string ValorarOferta()
        {
            Core.DALC.QueOfrecesEntities db = new Core.DALC.QueOfrecesEntities();
            Core.DALC.VALORACION valoracion = new Core.DALC.VALORACION();
            try
            {
                valoracion.CALIFICACION = this.Calificacion.ToString();
                valoracion.USUARIO_ID = this.IdUsuario;
                valoracion.OFERTA_ID = this.IdOferta;
                valoracion.CODE_IMAGEN = this.codeImagen;
                valoracion.FECHA_VALORACION = DateTime.Now;
                db.VALORACION.Add(valoracion);
                db.SaveChanges();
                this.response = "OK";
            }
            catch (Exception)
            {

                this.response = "ERR";
            }
            return Serializar();

        }

        public string Serializar()
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Valoracion));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }

    }
}
