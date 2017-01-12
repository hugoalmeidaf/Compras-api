using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Data
{
    public class CompraContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Lista> Listas { get; set; }
        public DbSet<Item> Itens { get; set; }

        public CompraContext():base(@"Server=tcp:is21khuc6y.database.windows.net,1433;Database=Compras;User ID=semteto@is21khuc6y;Password=$3mt3tO2815;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")
        {

        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasKey(l => l.ID);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.DataCadastro)
                .IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.UltimoAcesso)
                .IsOptional();

            modelBuilder.Entity<Lista>()
                .HasRequired(l => l.Pessoa)
                .WithMany(p => p.Listas)
                .HasForeignKey(l => l.PessoaID);                

            modelBuilder.Entity<Lista>()
                .HasKey(l => l.ID);

            modelBuilder.Entity<Lista>()
                .Property(l => l.Nome).HasMaxLength(150).IsRequired();

            modelBuilder.Entity<Lista>()
                .Property(l => l.DataCadastro).IsRequired();

            modelBuilder.Entity<Item>()
                .HasRequired(i => i.Lista)
                .WithMany(l => l.Itens)
                .HasForeignKey(i => i.ListaID);

            modelBuilder.Entity<Item>()
                .HasKey(l => l.ID);

            modelBuilder.Entity<Item>()
                .Property(l => l.Nome).HasMaxLength(150).IsRequired();

            modelBuilder.Entity<Item>()
               .Property(l => l.DataCadastro).IsRequired();

            modelBuilder.Entity<Item>()
                .Property(l => l.Realizado).IsRequired();
            

            modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
            modelBuilder.Entity<Lista>().ToTable("Lista");
            modelBuilder.Entity<Item>().ToTable("Item");
        }
    }
}