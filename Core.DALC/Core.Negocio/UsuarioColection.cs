using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class UsuarioColection : List<Usuario>
    {
        public UsuarioColection() { }

        public UsuarioColection(string json)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(UsuarioColection));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            UsuarioColection list = (UsuarioColection)serializador.ReadObject(stream);

            this.AddRange(list);

        }

        private UsuarioColection GenerarListado(List<DALC.USUARIO> listaDALC)
        {

            UsuarioColection lista = new UsuarioColection();
            foreach (var item in listaDALC)
            {
                Usuario usuario = new Usuario();

                usuario.IdUsuario = (int)item.ID_USUARIO;
                usuario.IdPerfil = (int)item.PERFIL_ID;
                usuario.NombreUsuario = item.NOMBRE_USUARIO;
                usuario.Password = item.PASSWORD;
                usuario.Nombre = item.NOMBRE;
                usuario.Apellido = item.APELLIDO;
                usuario.Rut = item.RUT;
                usuario.Activo = Convert.ToChar(item.ACTIVO);
                usuario.IdSucursal = (int)item.SUCURSAL_ID;
                usuario.FechaNacimiento = item.FECHA_NACIMIENTO;
                usuario.Sexo = Convert.ToChar(item.SEXO);
                usuario.Email = item.EMAIL;
                usuario.NumeroCelular = (int)item.NUMERO_CELULAR;
                usuario.Puntos = (int)item.PUNTOS;

                lista.Add(usuario);
            }
            return lista;

        }

        public string ReadAllUsuarios()
        {

            var listaDA = new DALC.QueOfrecesEntities().USUARIO;
            return GenerarListado(listaDA.ToList()).Serializar();
        }

        public string Serializar()
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(UsuarioColection));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }
    }
}
