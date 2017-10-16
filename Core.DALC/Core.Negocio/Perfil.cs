using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Perfil
    {
        public int IdPerfil { get; set; }
        public string Tipo { get; set; }

        public Perfil()
        {
            this.Init();
        }

        private void Init()
        {
            this.IdPerfil = 0;
            this.Tipo = string.Empty;
        }

        public Perfil(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Perfil));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            Perfil per = (Perfil)serializador.ReadObject(stream);

            this.Tipo = per.Tipo;
            this.IdPerfil = per.IdPerfil;
        }

        //

        public bool CrearPerfil()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.PERFIL per = new DALC.PERFIL();

                
                per.ID_PERFIL = this.IdPerfil;
                per.TIPO = this.Tipo;

                ctx.PERFIL.Add(per);
                ctx.SaveChanges();
                ctx = null;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ActualizarPerfil()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.PERFIL per = ctx.PERFIL.First(d => d.ID_PERFIL == IdPerfil);

                per.TIPO = this.Tipo;
                ctx.SaveChanges();
                ctx = null;

                return true;
            }
            catch (Exception ex)
            {

                return false;

            }

        }

        public bool EliminarPerfil()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.PERFIL per = ctx.PERFIL.First(d => d.ID_PERFIL == IdPerfil);

                ctx.Entry(per).State = System.Data.EntityState.Deleted;
                ctx.SaveChanges();
                ctx = null;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string Serializar()
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Perfil));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);
            string ser = Encoding.UTF8.GetString(stream.ToArray());
            return ser.ToString();
        }
    }
}
