//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class RUBRO
    {
        public RUBRO()
        {
            this.PRODUCTO = new HashSet<PRODUCTO>();
        }
    
        public decimal ID_RUBRO { get; set; }
        public string TIPO { get; set; }
        public string DESCRIPCION { get; set; }
    
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }
    }
}
