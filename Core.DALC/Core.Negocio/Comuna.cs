using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Comuna
    {
        public int IdComuna { get; set; }
        public string Nombre { get; set; }
        public int IdRegion { get; set; }
        public Comuna() { }
        public Comuna(int IdComuna, string Nombre,int IdRegion)
        {
            this.IdComuna = IdComuna;
            this.Nombre = Nombre;
            this.IdRegion = IdRegion;
        }
    }
}
