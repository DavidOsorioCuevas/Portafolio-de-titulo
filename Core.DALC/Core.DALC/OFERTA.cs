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
    
    public partial class OFERTA
    {
        public OFERTA()
        {
            this.PRODUCTO1 = new HashSet<PRODUCTO>();
            this.VALORACION = new HashSet<VALORACION>();
        }
    
        public decimal ID_OFERTA { get; set; }
        public string IMAGEN_OFERTA { get; set; }
        public Nullable<decimal> MIN_PRODUCTO { get; set; }
        public Nullable<decimal> MAX_PRODUCTO { get; set; }
        public string ESTADO_OFERTA { get; set; }
        public Nullable<System.DateTime> FECHA_OFERTA { get; set; }
        public decimal SUCURSALES_ID { get; set; }
        public decimal CATEGORIA_OFERTA_ID { get; set; }
        public decimal PRODUCTO_ID { get; set; }
    
        public virtual CATEGORIA_OFERTA CATEGORIA_OFERTA { get; set; }
        public virtual PRODUCTO PRODUCTO { get; set; }
        public virtual SUCURSALES SUCURSALES { get; set; }
        public virtual ICollection<PRODUCTO> PRODUCTO1 { get; set; }
        public virtual ICollection<VALORACION> VALORACION { get; set; }
    }
}