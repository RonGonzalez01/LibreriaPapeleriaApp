using Microsoft.EntityFrameworkCore;
using ProveedoresAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProveedoresAPI.Data
{
    public class ProveedoresContext : DbContext
    {
        public ProveedoresContext(DbContextOptions<ProveedoresContext> options) : base(options) { }
        public DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedor>()
                .Property(p => p.Nombre)
                .IsRequired();

            modelBuilder.Entity<Proveedor>()
                .Property(p => p.Direccion)
                .IsRequired();

            modelBuilder.Entity<Proveedor>()
                .Property(p => p.Telefono)
                .HasMaxLength(15);
        }
    }
}