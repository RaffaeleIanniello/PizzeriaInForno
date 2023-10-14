using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PizzeriaInForno.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<dettagli> dettagli { get; set; }
        public virtual DbSet<ordini> ordini { get; set; }
        public virtual DbSet<prodotti> prodotti { get; set; }
        public virtual DbSet<utenti> utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ordini>()
                .HasMany(e => e.dettagli)
                .WithRequired(e => e.ordini)
                .HasForeignKey(e => e.fkOrdini)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<prodotti>()
                .HasMany(e => e.dettagli)
                .WithRequired(e => e.prodotti)
                .HasForeignKey(e => e.fkProdotti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<utenti>()
                .HasMany(e => e.ordini)
                .WithRequired(e => e.utenti)
                .HasForeignKey(e => e.fkUtenti)
                .WillCascadeOnDelete(false);
        }
    }
}
