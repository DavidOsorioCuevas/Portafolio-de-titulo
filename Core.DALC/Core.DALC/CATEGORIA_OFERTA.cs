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
    
    public partial class CATEGORIA_OFERTA
    {
        public CATEGORIA_OFERTA()
        {
            this.OFERTA = new HashSet<OFERTA>();
        }
    
        public decimal ID_CATEGORIA_OFERTA { get; set; }
        public string NOMBRE { get; set; }
    
        public virtual ICollection<OFERTA> OFERTA { get; set; }
    }
}
