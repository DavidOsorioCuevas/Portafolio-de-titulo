using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rut { get; set; }
        public char? Activo { get; set; }
        public int IdSucursal { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string Pasaporte { get; set; }
        public int IdComuna { get; set; }
        public int Idregion { get; set; }
        public char? Sexo { get; set; }
        public string Email { get; set; }
        public int NumeroCelular { get; set; }
        public int Puntos { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string CodigoActivacion { get; set; }

        public string fn { get; set; } //fecha de nacimiento en formato string para aplicación web

        public string Response { get; set; }

        public Usuario()
        {
            this.Init();
        }

        public Usuario(string json)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Usuario));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            Usuario user = (Usuario)serializador.ReadObject(stream);

            this.IdUsuario = user.IdUsuario;
            this.IdPerfil = user.IdPerfil;
            this.NombreUsuario = user.NombreUsuario;
            this.Password = user.Password;
            this.Nombre = user.Nombre;
            this.Apellido = user.Apellido;
            this.Rut = user.Rut;
            this.Activo = user.Activo;
            this.IdSucursal = user.IdSucursal;
            this.FechaNacimiento = user.FechaNacimiento;
            this.Sexo = user.Sexo;
            this.Email = user.Email;
            this.NumeroCelular = user.NumeroCelular;
            this.Puntos = user.Puntos;
            this.FechaCreacion = user.FechaCreacion;
            this.CodigoActivacion = user.CodigoActivacion;
            this.fn = user.fn;

        }

        

        public string NuevoWeb()
        {
            Core.DALC.QueOfrecesEntities db= new Core.DALC.QueOfrecesEntities();
            Core.DALC.USUARIO usuario = new Core.DALC.USUARIO();
            Random rnd = new Random();
            int cod = rnd.Next(1000,9999);
            string codigo = cod.ToString();

            
            var resultEmail = from a in db.USUARIO where a.EMAIL.Equals(this.Email) select new { a };
            var resultRut = from a in db.USUARIO where a.RUT.Equals(this.Rut) select new { a };
         if (resultEmail.Count()>0)
            {
                this.Response = "EE";
                return SerializarUsuario(this);
            }
            else if (resultRut.Count()>0)
            {
             
                this.Response = "RPE";
                return SerializarUsuario(this);
            }
            else
            {
                usuario.PERFIL_ID = 3;

                usuario.NOMBRE_USUARIO = "0";
                usuario.PASSWORD = this.Password;
                usuario.NOMBRE = this.Nombre;
                usuario.APELLIDO = this.Apellido;
                usuario.RUT = this.Rut;
                usuario.ACTIVO = "0";
                usuario.SUCURSAL_ID = 0;
                usuario.FECHA_NACIMIENTO = (DateTime?)DateTime.Parse(this.fn);
                usuario.SEXO = this.Sexo.ToString();
                usuario.EMAIL = this.Email;
                usuario.NUMERO_CELULAR = this.NumeroCelular;
                usuario.PUNTOS = 0;
                usuario.FECHA_CREACION = (DateTime?)DateTime.Now;



                usuario.CODIGO_ACTIVACION = codigo;

                db.USUARIO.Add(usuario);
                db.SaveChanges();
                this.CodigoActivacion = codigo;
                this.Response = "OK";
                return SerializarUsuario(this);
            }

           

        }

        public string ActivarUsuario()
        {
            Usuario user = new Usuario();
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            var result= from a in ctx.USUARIO where a.ID_USUARIO==this.IdUsuario && a.CODIGO_ACTIVACION.Equals(this.CodigoActivacion) select new{ a};
            if (result.Count()>0)
            {

                ctx.USUARIO.Find(this.IdUsuario).ACTIVO = "1";
                ctx.SaveChanges();
                user.Response = "OK";
                user.Nombre = result.First().a.NOMBRE;
            }else
            {
                user.Response = "CI";
            }
            return SerializarUsuario(user);
        }

        public string PuntosTraer()
        {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            Usuario user = new Usuario();
            var result = from a in ctx.USUARIO where a.ID_USUARIO == this.IdUsuario select new { a.PUNTOS };
            user.Puntos = (int)result.First().PUNTOS;
            return SerializarUsuario(user);
        }
        public string ValidarWeb()
        {
            Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
            Usuario user = new Usuario();
            var result = from a in ctx.USUARIO where this.Email.Equals(a.EMAIL) && this.Password.Equals(a.PASSWORD)
                         select new{ a.ID_USUARIO,a.NOMBRE,a.PERFIL_ID,a.ACTIVO,a.PUNTOS,a.EMAIL,a.APELLIDO,a.NUMERO_CELULAR,a.FECHA_NACIMIENTO,a.SEXO,a.CODIGO_ACTIVACION};
            if (result.Count()>0)
            {
                if (result.First().PERFIL_ID!=3)
                {
                    user.Response = "NV";
                }else if (result.First().PERFIL_ID == 3 && result.First().ACTIVO.Equals("0"))
                {
                    user.IdUsuario = (int)result.First().ID_USUARIO;
                    user.Response = "UNA";
                    user.CodigoActivacion = result.First().CODIGO_ACTIVACION;
                }
                else {
                    user.Response = "OK";
                    user.IdUsuario = (int)result.First().ID_USUARIO;
                    user.Activo = result.First().ACTIVO[0];
                    user.Nombre = result.First().NOMBRE;
                    user.Puntos = (int)result.First().PUNTOS;
                    user.Email = result.First().EMAIL;
                    user.Apellido = result.First().APELLIDO;
                    user.NumeroCelular = (int)result.First().NUMERO_CELULAR;
                    user.FechaNacimiento = result.First().FECHA_NACIMIENTO;
                    user.Sexo = Convert.ToChar(result.First().SEXO);

                } 

                
            }else
            {
                user.Response="NV";
            }

            return SerializarUsuario(user);
        }

        private void Init()
        {
            IdUsuario = 0;
            IdPerfil = 0;
            NombreUsuario = string.Empty;
            Password = string.Empty;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Rut = string.Empty;
            Activo = null;
            IdSucursal = 0;
            FechaNacimiento = null;
            Sexo = null;
            Email = string.Empty;
            NumeroCelular = 0;
            Puntos = 0;
            FechaCreacion = null;
            IdComuna = 0;
            Idregion = 0;
            CodigoActivacion = string.Empty;
            Response = string.Empty;
        }

        public bool Read()
        {
            try
            {
                Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();       
                Core.DALC.USUARIO usuario = ctx.USUARIO.First(u => u.NOMBRE_USUARIO == NombreUsuario);

                this.IdUsuario = (int)usuario.ID_USUARIO;
                this.IdPerfil = (int)usuario.PERFIL_ID;
                this.NombreUsuario = usuario.NOMBRE_USUARIO;
                this.Password = usuario.PASSWORD;
                this.Nombre = usuario.NOMBRE;
                this.Apellido = usuario.APELLIDO;
                this.Rut = usuario.RUT;
                this.Activo = Convert.ToChar(usuario.ACTIVO);
                this.IdSucursal = (int)usuario.SUCURSAL_ID;
                this.FechaNacimiento = usuario.FECHA_NACIMIENTO;
                this.Sexo = Convert.ToChar(usuario.SEXO);
                this.Email = usuario.EMAIL;
                this.NumeroCelular = (int)usuario.NUMERO_CELULAR;
                this.FechaCreacion = usuario.FECHA_CREACION;
                this.CodigoActivacion = usuario.CODIGO_ACTIVACION;

                ctx = null;

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool LeerId() {
            try
            {
                Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();          
                Core.DALC.USUARIO usuario = ctx.USUARIO.First(u => u.ID_USUARIO == IdUsuario);
               
                this.IdPerfil = (int)usuario.PERFIL_ID;
                this.NombreUsuario = usuario.NOMBRE_USUARIO;
                this.Password = usuario.PASSWORD;
                this.Nombre = usuario.NOMBRE;
                this.Apellido = usuario.APELLIDO;
                this.Rut = usuario.RUT;
                this.Activo = Convert.ToChar(usuario.ACTIVO);
                this.IdSucursal = (int)usuario.SUCURSAL_ID;
                this.FechaNacimiento = usuario.FECHA_NACIMIENTO;
                this.Sexo = Convert.ToChar(usuario.SEXO);
                this.Email = usuario.EMAIL;
                this.NumeroCelular = (int)usuario.NUMERO_CELULAR;
                this.Puntos = (int)usuario.PUNTOS;
                this.FechaCreacion = usuario.FECHA_CREACION;
                this.CodigoActivacion = usuario.CODIGO_ACTIVACION;

                ctx = null;

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Create()
        {
            try
            {
                Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities();
                Core.DALC.USUARIO usuario = new Core.DALC.USUARIO();

                usuario.ID_USUARIO = this.IdUsuario;
                usuario.PERFIL_ID = this.IdPerfil;
                usuario.NOMBRE_USUARIO = this.NombreUsuario;
                usuario.PASSWORD = this.Password;
                usuario.NOMBRE = this.Nombre;
                usuario.APELLIDO = this.Apellido;
                usuario.RUT = this.Rut;
                usuario.ACTIVO = this.Activo.ToString();
                usuario.SUCURSAL_ID = this.IdSucursal;
                usuario.FECHA_NACIMIENTO = this.FechaNacimiento;
                usuario.SEXO = this.Sexo.ToString();
                usuario.EMAIL = this.Email;
                usuario.NUMERO_CELULAR = this.NumeroCelular;
                usuario.PUNTOS = this.Puntos;
                usuario.FECHA_CREACION = this.FechaCreacion;
                usuario.CODIGO_ACTIVACION = this.CodigoActivacion;

                ctx.USUARIO.Add(usuario);
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

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Usuario));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }

        public string SerializarUsuario(Usuario user)
        {

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Usuario));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, user);

            string ser = Encoding.UTF8.GetString(stream.ToArray());

            return ser.ToString();

        }

        public bool ValidarUsuarioWPF(string username, string password)
        {
            this.NombreUsuario = username;

            if (Read())
            {
                if (this.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool EliminarUsuario()
        {
            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.USUARIO user = ctx.USUARIO.First(u => u.ID_USUARIO == IdUsuario);

                ctx.Entry(user).State = System.Data.EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ActualizarUsuario() {

            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.USUARIO usuario = ctx.USUARIO.First(u => u.NOMBRE_USUARIO == NombreUsuario);

               
                usuario.PERFIL_ID = this.IdPerfil;
                usuario.NOMBRE_USUARIO = this.NombreUsuario;
                usuario.PASSWORD = this.Password;
                usuario.NOMBRE = this.Nombre;
                usuario.APELLIDO = this.Apellido;
                usuario.RUT = this.Rut;
                usuario.ACTIVO = this.Activo.ToString();
                usuario.SUCURSAL_ID = this.IdSucursal;
                usuario.FECHA_NACIMIENTO = this.FechaNacimiento;
                usuario.SEXO = this.Sexo.ToString();
                usuario.EMAIL = this.Email;
                usuario.NUMERO_CELULAR = this.NumeroCelular;
                usuario.PUNTOS = this.Puntos;
                usuario.PASSAPORTE = this.Pasaporte;
                usuario.NACIONALIDAD = this.Nacionalidad;
                usuario.FECHA_CREACION = this.FechaCreacion;
                usuario.CODIGO_ACTIVACION = this.CodigoActivacion;
                

                ctx.SaveChanges();
                ctx = null;
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }



    }
}
