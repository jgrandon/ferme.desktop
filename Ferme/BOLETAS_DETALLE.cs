//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ferme
{
    using System;
    using System.Collections.Generic;
    
    public partial class BOLETAS_DETALLE
    {
        public long ID { get; set; }
        public long ID_BOLETA { get; set; }
        public long ID_PRODUCTO { get; set; }
        public int CANTIDAD { get; set; }
        public int VALOR_UNITARIO { get; set; }
        public int SUBTOTAL { get; set; }
    
        public virtual BOLETAS BOLETAS { get; set; }
        public virtual PRODUCTOS PRODUCTOS { get; set; }
    }
}
