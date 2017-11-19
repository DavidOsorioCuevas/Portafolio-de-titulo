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

        public FilterParameter(string parameter, int min, int max)
        {
            this.parameter = parameter;
            this.min = min;
            this.max = max;
        }
    }
}
