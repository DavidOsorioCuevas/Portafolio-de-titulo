using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Region
    {
        public int IdRegion { get; set; }
        public string Nombre { get; set; }

        public Region() { }
        public Region(int IdRegion, string Nombre)
        {
            this.IdRegion = IdRegion;
            this.Nombre = Nombre;
        }
    }
}
