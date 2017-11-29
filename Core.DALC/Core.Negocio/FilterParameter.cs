using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio
{
    public class FilterParameter
    {
        public string parameter { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public FilterParameter() { }

        public int IdCategoria { get; set; }
        public int IdRetail { get; set; }
        public FilterParameter(string parameter, int min, int max,int IdCategoria,int IdRetail)
        {
            this.parameter = parameter;
            this.min = min;
            this.max = max;
            this.IdCategoria = IdCategoria;
            this.IdRetail = IdRetail;
        }
    }
}
