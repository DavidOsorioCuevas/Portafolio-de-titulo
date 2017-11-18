using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class SucursalCollections: List<Sucursal>
    {
        public SucursalCollections() { }

        public SucursalCollections(string json)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(SucursalCollections));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            SucursalCollections list = (SucursalCollections)serializador.ReadObject(stream);

            this.AddRange(list);
        }

        private SucursalCollections GenerarListado(int idRetail)
        {
            DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
            var listaDALC = from o in ctx.SUCURSALES
                            join r in ctx.RETAIL on o.RETAIL_ID equals r.ID_RETAIL
                            where r.ID_RETAIL== idRetail
                            select o;


            SucursalCollections lista = new SucursalCollections();
            foreach (var item in listaDALC)
            {
                Sucursal s = new Sucursal();

                s.IdSucursal = (int)item.ID_SUCURSAL;
                s.Rut = item.RUT;
                s.RazonSocial = item.RAZON_SOCIAL;
                s.Nombre = item.NOMBRE;
                s.Direccion = item.DIRECCION;
                s.Telefono = (int)item.TELEFONO;
                s.IdComuna = (int)item.COMUNA_ID;
                s.IdRegion = (int)item.REGION_ID;
                s.Email = item.EMAIL;
                s.IdRetail = (int)item.RETAIL_ID;

                lista.Add(s);
            }
            return lista;

        }

        public string ReadAllSucursal(int idRetail)
        {

            var listaDA = new DALC.QueOfrecesEntities().SUCURSALES;
            return GenerarListado(idRetail).Serializar();
        }

        public string Serializar()
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(SucursalCollections));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }
}
