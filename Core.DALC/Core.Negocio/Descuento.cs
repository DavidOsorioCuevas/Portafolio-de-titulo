using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class Descuento
    {
        public int IdDescuento { get; set; }
        public int MinPuntos { get; set; }
        public int MaxPuntos { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public int Porcentaje;
        public int Tope;


        public Descuento() {

            this.Init();
        }

        private void Init()
        {
            IdDescuento = 0;
            MinPuntos = 0;
            MaxPuntos = 0;
            FechaCaducidad = default(DateTime);
        }
    }
}
