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
    
    public partial class REGISTROS_STOCK
    {
        public long ID { get; set; }
        public long ID_PRODUCTO { get; set; }
        public string TIPO { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public long ID_DOCUMENTO { get; set; }
        public int CANTIDAD_ENTRADA { get; set; }
        public int CANTIDAD_SALIDA { get; set; }
        public int CANTIDAD_SALDO { get; set; }
        public System.DateTime FECHA { get; set; }
        public Nullable<System.DateTime> CREATED_AT { get; set; }
        public Nullable<System.DateTime> UPDATED_AT { get; set; }
    
        public virtual PRODUCTOS PRODUCTOS { get; set; }
    }
}
