namespace PruebaTecnica.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Colegio : DbContext
    {
        public Colegio()
            : base("name=Colegio")
        {
        }

        public virtual DbSet<cargo> cargo { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cargo>()
                .Property(e => e.car_des)
                .IsUnicode(false);

            modelBuilder.Entity<cargo>()
                .HasMany(e => e.usuario)
                .WithRequired(e => e.cargo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.usu_nom)
                .IsUnicode(false);
        }
    }
}
