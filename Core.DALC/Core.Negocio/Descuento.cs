using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Descuento
    {
        public int IdDescuento { get; set; }
        public int MinPuntos { get; set; }
        public int MaxPuntos { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public int Porcentaje;
        public int Tope;

        public List<CategoriaOferta> Categorias { get; set; }
        public Descuento()
        {

            this.Init();
        }

        public Descuento(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Descuento));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            Descuento des = (Descuento)serializador.ReadObject(stream);

            this.IdDescuento = des.IdDescuento;
            this.MinPuntos = des.MinPuntos;
            this.MaxPuntos = des.MaxPuntos;
            this.FechaCaducidad = des.FechaCaducidad;
            this.Porcentaje = des.Porcentaje;
            this.Tope = des.Tope;

        }

        private void Init()
        {
            IdDescuento = 0;
            MinPuntos = 0;
            MaxPuntos = 0;
            FechaCaducidad = default(DateTime);
            Porcentaje = 0;
            Tope = 0;
        }
        //probar metodo
        public bool CrearDescuento()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.DESCUENTO des = new DALC.DESCUENTO();

                des.ID_DESCUENTO = this.IdDescuento;
                des.MIN_PUNTOS = this.MinPuntos;
                des.MAX_PUNTOS = this.MaxPuntos;
                des.PORCENTAJE = this.Porcentaje;
                des.TOPE = this.Tope;

                ctx.DESCUENTO.Add(des);
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
        public bool ActualizarDescuento()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.DESCUENTO des = ctx.DESCUENTO.First(d => d.ID_DESCUENTO == IdDescuento);

                des.MIN_PUNTOS = this.MinPuntos;
                des.MAX_PUNTOS = this.MaxPuntos;
                des.PORCENTAJE = this.Porcentaje;
                des.TOPE = this.Tope;

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
        public bool EliminarDescuento()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.DESCUENTO des = ctx.DESCUENTO.First(d => d.ID_DESCUENTO == IdDescuento);

                ctx.Entry(des).State = System.Data.EntityState.Deleted;
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
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Descuento));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);
            string ser = Encoding.UTF8.GetString(stream.ToArray());
            return ser.ToString();
        }
    }
}
