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
    
    public partial class FAMILIAS_PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAMILIAS_PRODUCTO()
        {
            this.PRODUCTOS = new HashSet<PRODUCTOS>();
            this.TIPOS_PRODUCTO = new HashSet<TIPOS_PRODUCTO>();
        }
    
        public long ID { get; set; }
        public string NOMBRE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTOS> PRODUCTOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIPOS_PRODUCTO> TIPOS_PRODUCTO { get; set; }
    }
}