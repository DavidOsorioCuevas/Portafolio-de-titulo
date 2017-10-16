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

        private SucursalCollections GenerarListado(List<DALC.SUCURSALES> listaDALC)
        {

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

        public string ReadAllSucursal()
        {

            var listaDA = new DALC.QueOfrecesEntities().SUCURSALES;
            return GenerarListado(listaDA.ToList()).Serializar();
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
