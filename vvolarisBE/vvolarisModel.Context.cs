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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class vvolarisbdEntities : DbContext
    {
        public vvolarisbdEntities()
            : base("name=vvolarisbdEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Accion> Accions { get; set; }
        public virtual DbSet<Aerolinea> Aerolineas { get; set; }
        public virtual DbSet<Bitacora> Bitacoras { get; set; }
        public virtual DbSet<Clase> Clases { get; set; }
        public virtual DbSet<Consecutivo> Consecutivoes { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<EstadoVuelo> EstadoVueloes { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Puerta> Puertas { get; set; }
        public virtual DbSet<Reservacion> Reservacions { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<TipoPago> TipoPagoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vuelo> Vueloes { get; set; }
    }
}
