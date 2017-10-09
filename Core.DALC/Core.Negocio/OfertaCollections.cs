using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{

        public  class OfertaCollections : List<Oferta>
        {
            public OfertaCollections() { }

            public OfertaCollections(string json)
            {

                DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(OfertaCollections));
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

                OfertaCollections list = (OfertaCollections)serializador.ReadObject(stream);

                this.AddRange(list);

            }

            private OfertaCollections GenerarListado(List<DALC.OFERTA> listaDALC)
            {

                OfertaCollections lista = new OfertaCollections();
                foreach (var item in listaDALC)
                {
                    Oferta of = new Oferta();

                    of.IdOferta = (int)item.ID_OFERTA;
                    of.ImagenOferta = item.IMAGEN_OFERTA;
                    of.MinProductos = (int)item.MIN_PRODUCTO;
                    of.MaxProductos = (int)item.MAX_PRODUCTO;
                    of.EstadoOferta = Convert.ToChar(item.ESTADO_OFERTA);
                    of.FechaOferta = item.FECHA_OFERTA;
                    of.IdSucursal = (int)item.SUCURSALES_ID;
                    of.CategoriaIdOferta = (int)item.CATEGORIA_OFERTA_ID;
                    of.IdRegion = (int)item.REGION_ID;
                    of.IdComuna = (int)item.COMUNA_ID;
                    of.Nombre = item.NOMBRE;
                    of.Descripcion = item.DESCRIPCION;

                    lista.Add(of);
                }
                return lista;

            }

            public string ReadAllOfertas()
            {

                var listaDA = new DALC.QueOfrecesEntities().OFERTA;
                return GenerarListado(listaDA.ToList()).Serializar();
            }

            public string Serializar()
            {

                DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(OfertaCollections));
                MemoryStream stream = new MemoryStream();

                serializador.WriteObject(stream, this);

                string ser = Encoding.UTF8.GetString(stream.ToArray());

                return ser.ToString();

            }
        }
    }

