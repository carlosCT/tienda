namespace PruebaTecnica.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<pedido> pedido { get; set; }
        public virtual DbSet<producto> producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cliente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.documento)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .HasMany(e => e.pedido)
                .WithRequired(e => e.cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pedido>()
                .HasMany(e => e.producto)
                .WithMany(e => e.pedido)
                .Map(m => m.ToTable("productosxpedido").MapLeftKey("idPedido").MapRightKey("idProducto"));

            modelBuilder.Entity<producto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.precio)
                .HasPrecision(18, 0);
        }
    }
}
