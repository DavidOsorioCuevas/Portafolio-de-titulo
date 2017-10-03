using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Core.DALC;

namespace Core.Negocio
{
    public class Retail
    {
        public int IdRetail { get; set; }
        public string RutRetail { get; set; }
        public string NombreRetail { get; set; }
        public string RazonSocial { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int IdRegion { get; set; }
        public int IdComuna { get; set; }

        public Retail()
        {
            this.Init();

        }

        public Retail(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Retail));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            Retail ret = (Retail)serializador.ReadObject(stream);
            this.IdRetail = ret.IdRetail;
            this.RutRetail = ret.RutRetail;
            this.NombreRetail = ret.NombreRetail;
            this.RazonSocial = ret.RazonSocial;
            this.Telefono = ret.Telefono;
            this.Email = ret.Email;
            this.Direccion = ret.Direccion;
            this.IdRegion = ret.IdRegion;
            this.IdComuna = ret.IdComuna;
        }


        private void Init()
        {
            IdRetail = 0;
            RutRetail = string.Empty;
            NombreRetail = string.Empty;
            RazonSocial = string.Empty;
            Telefono = 0;
            Email = string.Empty;
            Direccion = string.Empty;
            IdRegion = 0;
            IdComuna = 0;
        }

        public bool CrearRetail()
        {
            try
            {
                Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
                Core.DALC.RETAIL ret = new Core.DALC.RETAIL();

                ret.ID_RETAIL = this.IdRetail;
                ret.RUT = this.RutRetail;
                ret.NOMBRE = this.NombreRetail;
                ret.RAZON_SOCIAL = this.RazonSocial;
                ret.TELEFONO = this.Telefono;
                ret.EMAIL = this.Email;
                ret.DIRECCION = this.Direccion;
                //ret.IDREGION = this.IdRegion;
                //re.IDComunda = this.IdComuna;

                ctx.RETAIL.Add(ret);
                ctx.SaveChanges();
                ctx = null;

                return true;

            }
            catch (Exception ex)
            {

                return false;
            }

        }
        //probar metodo 
        public bool ActualizarRetail()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.RETAIL ret = ctx.RETAIL.First(r => r.ID_RETAIL == IdRetail);

                ret.RUT = this.RutRetail;
                ret.NOMBRE = this.NombreRetail;
                ret.RAZON_SOCIAL = this.RazonSocial;
                ret.TELEFONO = this.Telefono;
                ret.EMAIL = this.Email;
                ret.DIRECCION = this.Direccion;
                //ret.IDREGION = this.IdRegion;
                //re.IDComunda = this.IdComuna;
                ctx.SaveChanges();
                ctx = null;

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        //probar metodo 
        public bool EliminarRetail()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.RETAIL ret = ctx.RETAIL.First(r => r.ID_RETAIL == IdRetail);
                ctx.Entry(ret).State = System.Data.EntityState.Deleted;
                ctx.SaveChanges();
                ctx = null;

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }


        }
        //probar metodo 
        public string Serializar()
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Retail));
            MemoryStream stream = new MemoryStream();
            serializador.WriteObject(stream, this);
            string ser = Encoding.UTF8.GetString(stream.ToArray());
            return ser.ToString();
        }
    }
}
