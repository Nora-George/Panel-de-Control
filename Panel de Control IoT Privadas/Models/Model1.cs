using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Panel_de_Control_IoT_Privadas.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Casas> Casas { get; set; }
        public virtual DbSet<Historials> Historials { get; set; }
        public virtual DbSet<Privadas> Privadas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Administrador> Administradores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Casas>()
                .HasMany(e => e.Usuarios)
                .WithRequired(e => e.Casas)
                .HasForeignKey(e => e.CasaID);

            modelBuilder.Entity<Privadas>()
                .HasMany(e => e.Casas)
                .WithRequired(e => e.Privadas)
                .HasForeignKey(e => e.PrivadaID);

            modelBuilder.Entity<Privadas>()
                .HasMany(e => e.Historials)
                .WithRequired(e => e.Privadas)
                .HasForeignKey(e => e.PrivadaID);
        }
    }
}
