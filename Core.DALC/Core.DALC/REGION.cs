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
    
    public partial class REGION
    {
        public REGION()
        {
            this.COMUNA = new HashSet<COMUNA>();
            this.RETAIL = new HashSet<RETAIL>();
            this.SUCURSALES = new HashSet<SUCURSALES>();
            this.USUARIO = new HashSet<USUARIO>();
        }
    
        public decimal ID_REGION { get; set; }
        public string NOMBRE { get; set; }
    
        public virtual ICollection<COMUNA> COMUNA { get; set; }
        public virtual ICollection<RETAIL> RETAIL { get; set; }
        public virtual ICollection<SUCURSALES> SUCURSALES { get; set; }
        public virtual ICollection<USUARIO> USUARIO { get; set; }
    }
}
