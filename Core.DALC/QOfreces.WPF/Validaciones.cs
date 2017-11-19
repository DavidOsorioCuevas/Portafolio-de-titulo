using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace QOfreces.WPF
{
    public class Validaciones
    {

        public Validaciones()
        {

        }

        public string validarNombreUsuario(string nombre)
        {
            if (nombre.Length < 1)
            {
                return "Ingrese un nombre usuario";
            }
            else if (nombre.Length > 20)
            {
                return "Nombre usuario no puede superar los 20 caracteres";
            }
            else
            {
                return "OK";
            }

        }

        public string validarContraseña(string contraseña)
        {
            if (contraseña.Length < 1)
            {
                return "Ingrese contraseña";
            }
            else if (contraseña.Length < 4 && contraseña.Length > 12)
            {
                return "La contraseña debe estar entre 4 y 12 caracteres";
            }
            else
            {
                return "OK";
            }

        }

        public string validarNombre(string nombre)
        {

            if (nombre.Length < 1)
            {
                return "Ingrese nombre";
            }
            else if (nombre.Length < 4 || nombre.Length > 12)
            {
                return "El nombre debe estar entre 4 y 12 caracteres";
            }
            else
            {
                return "OK";
            }

        }

        public string validarPrecio(string precio)
        {
            string valorPrecio = Convert.ToString(precio);

            if (valorPrecio.Length == 0)
            {
                return "Ingrese precio";
            }
            else
            {
                return "OK";
            }


        }

        public string validarCodigoInterno(string codigoInterno)
        {

            if (codigoInterno.Length == 0)
            {
                return "Ingrese Codigo Interno";
            }
            else
            {
                return "OK";
            }

        }

        public string validarMinCantidad(string minCantidad)
        {
            string valorMinCantidad = Convert.ToString(minCantidad);

            if (valorMinCantidad.Length == 0)
            {
                return "Ingrese Cantidad Minima";
            }
            else
            {
                return "OK";
            }

        }

        public string validarMaxCantidad(string maxCantidad)
        {
            string valorMaxCantidad = Convert.ToString(maxCantidad);


            if (valorMaxCantidad.Length == 0)
            {
                return "Ingrese Cantidad Maxima";
            }
            else
            {
                return "OK";
            }

        }

        public string validarCorreo(string correo)
        {

            if (String.IsNullOrEmpty(correo))
            {
                return "El correo no puede estar en blanco";
            }
            if (correo != null && !Regex.IsMatch(correo, "^[\\w-]+(\\.[\\w-]+)*@([a-z0-9-]+(\\.[a-z0-9-]+)*?\\.[a-z]{2,6}|(\\d{1,3}\\.){3}\\d{1,3})(:\\d{4})?$", RegexOptions.IgnoreCase))
            {
                return "Digite un correo válido";
            }
            else
            {
                return "OK";
            }
        }

        public string validarRazonSocial(string razonSocial)
        {

            if (razonSocial.Length < 1)
            {
                return "Ingrese razon Social";
            }
            else if (razonSocial.Length < 4 || razonSocial.Length > 12)
            {
                return "Razon Social debe contener entre 4 y 12 caracteres";
            }
            else
            {
                return "OK";
            }
        }

        public string validarRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }

            if (validacion != true)
            {
                return "Rut de Formato Invalido";
            }
            else if (rut.Length < 1)
            {
                return "Ingrese Rut";
            }
            else if (rut.Length < 4 || rut.Length > 12)
            {
                return "El Rut debe contener entre 4 y 12 caracteres";
            }
            {
                return "OK";
            }

        }
    }
}
