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
    
    public partial class BOLETAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOLETAS()
        {
            this.BOLETAS_DETALLE = new HashSet<BOLETAS_DETALLE>();
        }
    
        public long ID { get; set; }
        public long ID_CLIENTE { get; set; }
        public Nullable<long> ID_VENDEDOR { get; set; }
        public int TOTAL { get; set; }
        public int IVA { get; set; }
        public int NETO { get; set; }
        public System.DateTime FECHA_CREACION { get; set; }
        public System.DateTime FECHA_ENTREGA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOLETAS_DETALLE> BOLETAS_DETALLE { get; set; }
        public virtual CLIENTES CLIENTES { get; set; }
        public virtual TRABAJADORES TRABAJADORES { get; set; }
    }
}
