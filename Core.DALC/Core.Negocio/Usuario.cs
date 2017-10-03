﻿using System;
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
        //comentario usuarios.

            //assasasasasa
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
        public char? Sexo { get; set; }
        public string Email { get; set; }
        public int NumeroCelular { get; set; }
        public int Puntos { get; set; }


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
        }

        public bool Read()
        {
            try
            {
                Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities(); // estas dos lineas wn.. la conexion esta mala al ado         
                Core.DALC.USUARIO usuario = ctx.USUARIO.First(u => u.NOMBRE_USUARIO == NombreUsuario);

                this.IdUsuario = (int)usuario.ID_USUARIO;
                this.IdPerfil = (int)usuario.ID_PERFIL;
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
                ctx = null;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool LeerId() {
            try
            {
                Core.DALC.QueOfrecesEntities ctx = new Core.DALC.QueOfrecesEntities(); // estas dos lineas wn.. la conexion esta mala al ado         
                Core.DALC.USUARIO usuario = ctx.USUARIO.First(u => u.ID_USUARIO == IdUsuario);
               
                this.IdPerfil = (int)usuario.ID_PERFIL;
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
                
                ctx = null;

                return true;
            }
            catch (Exception ex)
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
                usuario.ID_PERFIL = this.IdPerfil;
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

                ctx.USUARIO.Add(usuario);
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

            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(Usuario));
            MemoryStream stream = new MemoryStream();

            serializador.WriteObject(stream, this);

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
                DALC.USUARIO user = ctx.USUARIO.First(u => u.NOMBRE_USUARIO == NombreUsuario);

                ctx.Entry(user).State = System.Data.EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool ActualizarUsuario() {

            try
            {
                DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
                DALC.USUARIO usuario = ctx.USUARIO.First(u => u.ID_USUARIO == IdUsuario);

               
                usuario.ID_PERFIL = this.IdPerfil;
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

                ctx.SaveChanges();
                ctx = null;
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }



    }
}