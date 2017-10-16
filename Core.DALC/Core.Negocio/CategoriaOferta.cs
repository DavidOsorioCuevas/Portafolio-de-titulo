using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class CategoriaOferta
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        

        public CategoriaOferta()
        {
            this.Init();
        }

        private void Init()
        {
            this.IdCategoria = 0;
            this.Nombre = string.Empty;
        }

        public CategoriaOferta(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(CategoriaOferta));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            CategoriaOferta cat = (CategoriaOferta)serializador.ReadObject(stream);

            this.IdCategoria = cat.IdCategoria;
            this.Nombre = cat.Nombre;
        }

        public bool CrearCategoria()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.CATEGORIA_OFERTA cat = new DALC.CATEGORIA_OFERTA();

                cat.ID_CATEGORIA_OFERTA = this.IdCategoria;
                cat.NOMBRE = this.Nombre;

                ctx.CATEGORIA_OFERTA.Add(cat);
                ctx.SaveChanges();
                ctx = null;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ActualizarCategoria()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.CATEGORIA_OFERTA cat = ctx.CATEGORIA_OFERTA.First(d => d.ID_CATEGORIA_OFERTA == IdCategoria);

                cat.NOMBRE = this.Nombre;
                ctx.SaveChanges();
                ctx = null;

                return true;
            }
            catch (Exception ex)
            {

                return false;

            }

        }

        public bool EliminarCategoria()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.CATEGORIA_OFERTA cat = ctx.CATEGORIA_OFERTA.First(d => d.ID_CATEGORIA_OFERTA == IdCategoria);

                ctx.Entry(cat).State = System.Data.EntityState.Deleted;
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
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(CategoriaOferta));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);
            string ser = Encoding.UTF8.GetString(stream.ToArray());
            return ser.ToString();
        }

    }
}
