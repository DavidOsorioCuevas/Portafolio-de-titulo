using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class OfertaHasSucursal
    {
        public int IdOfertaHasSucursal { get; set; }
        public int OfertaId { get; set; }
        public int SucursalId{ get; set; }

        public OfertaHasSucursal() {

            this.Init();
        }

        public OfertaHasSucursal(string json) {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(OfertaHasSucursal));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            OfertaHasSucursal des = (OfertaHasSucursal)serializador.ReadObject(stream);

            this.IdOfertaHasSucursal = des.IdOfertaHasSucursal;
            this.OfertaId = des.OfertaId;
            this.SucursalId = des.SucursalId;                
        }

        private void Init()
        {
            this.IdOfertaHasSucursal = 0;
            this.OfertaId = 0;
            this.SucursalId = 0;
        }

        public bool CrearOfertaHasSucusal()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.OFERTA_HAS_SUCURSAL ohs = new DALC.OFERTA_HAS_SUCURSAL();               
                int idOferta = (int)ctx.OFERTA.Max(u => u.ID_OFERTA);



                ohs.ID = this.IdOfertaHasSucursal;                
                ohs.SUCURSAL_ID = this.SucursalId;
                ohs.OFERTA_ID = idOferta;

                ctx.OFERTA_HAS_SUCURSAL.Add(ohs);
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
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(OfertaHasSucursal));
            MemoryStream stream = new MemoryStream();

            ser.WriteObject(stream, this);
            string serializador = Encoding.UTF8.GetString(stream.ToArray());

            return serializador.ToString();
        }

    }
}
