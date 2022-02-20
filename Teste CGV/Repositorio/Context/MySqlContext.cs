using Dominio.Advogado;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<Advogado> Advogados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=advogados;Uid=root;DefaultCommandTimeout=60;Allow User Variables=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Advogado>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Nome).IsRequired();
            });
        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if(entry.State == EntityState.Added)
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCriacao").IsModified = false;
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("ID") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("ID").CurrentValue = Guid.NewGuid();

                if (entry.State == EntityState.Modified)
                    entry.Property("ID").IsModified = false;
            }
            return base.SaveChanges();
        }
    }
}
