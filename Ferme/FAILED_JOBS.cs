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
    
    public partial class FAILED_JOBS
    {
        public long ID { get; set; }
        public string CONNECTION { get; set; }
        public string QUEUE { get; set; }
        public string PAYLOAD { get; set; }
        public string EXCEPTION { get; set; }
        public System.DateTime FAILED_AT { get; set; }
    }
}
