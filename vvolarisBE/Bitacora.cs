//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace vvolarisBE
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bitacora
    {
        public int Codigo { get; set; }
        public string UsuarioID { get; set; }
        public int ClaseID { get; set; }
        public int AccionID { get; set; }
        public string Detalle { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    
        public virtual Accion Accion { get; set; }
        public virtual Clase Clase { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
