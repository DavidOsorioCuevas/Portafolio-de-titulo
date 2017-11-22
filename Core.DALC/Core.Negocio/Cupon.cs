using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Cupon
    {

        public int IdCupon { get; set; }
        public int IdDescuento { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Hasta { get; set; }

        public Descuento Descuento { get; set; }

        public string fc { get; set; }
        public string Codigo { get; set; }

        public Cupon() { }

        public Cupon(int IdCupon, int IdDescuento, string fc, int IdUsuario, DateTime Fecha_Creacion, DateTime Fecha_Hasta, string Codigo)
        {
            this.IdCupon = IdCupon;
            this.IdDescuento = IdDescuento;
            this.IdUsuario = IdUsuario;
            this.Fecha_Creacion = Fecha_Creacion;
            this.Fecha_Hasta = Fecha_Hasta;
            this.Codigo = Codigo;
            this.fc = fc;
        }
    }
}
