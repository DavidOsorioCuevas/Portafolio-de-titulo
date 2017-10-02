using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json; //librerìa necesaria para trabajar con json
namespace Core.Negocio
{
    public class Procesos
    {
        public Procesos() { }


        /*Entrada json*/
        public string validarUsuarioWebJSON(string json)
        {
            DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
            Usuario userIN = new Usuario();
            Usuario userOUT = new Usuario();


            Newtonsoft.Json.JsonConvert.PopulateObject(json, userIN);

            var result = from a in ctx.USUARIO
                         where a.NOMBRE_USUARIO == userIN.NOMBRE_USUARIO && a.ID_PERFIL == 1
                         select new 
                         {
                           a.PASSWORD,
                           a.NOMBRE_USUARIO,
                           a.NOMBRE

                         };
            if (result.Count() > 0)
            {
                string pass = result.First().PASSWORD.ToString();
                if (userIN.PASSWORD.Equals(pass))
                {
                    
                    userOUT.NOMBRE=result.First().NOMBRE.ToString();
                    userOUT.NOMBRE_USUARIO=result.First().NOMBRE_USUARIO.ToString();
                    userOUT.PASSWORD=result.First().PASSWORD.ToString();
                }
                else
                {
                    userOUT.NOMBRE = "0";
                    userOUT.NOMBRE_USUARIO = "0";
                    userOUT.PASSWORD = "0";
                }
            }
            else
            {
                userOUT.NOMBRE = "0";
                userOUT.NOMBRE_USUARIO = "0";
                userOUT.PASSWORD = "0";
            }

            string jsonOUT=Newtonsoft.Json.JsonConvert.SerializeObject(userOUT);
            return jsonOUT;

        }

        public bool validarUsuarioWPF(string username, string password)
        {
            DALC.QueOfrecesEntities ctx = new DALC.QueOfrecesEntities();
            var result = from a in ctx.USUARIO
                         where a.NOMBRE_USUARIO == username && a.ID_PERFIL != 1
                         select new
                         {
                             a.PASSWORD
                         };
            if (result.Count() > 0)
            {
                string pass = result.First().PASSWORD.ToString();
                if (password.Equals(pass))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            /*
            if (username.Equals("user")&&password.Equals("1234"))
            {
                return true;
            }
            return false;*/
        }

    }
}
