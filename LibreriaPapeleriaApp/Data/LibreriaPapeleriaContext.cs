using Microsoft.EntityFrameworkCore;
using LibreriaPapeleriaApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LibreriaPapeleriaApp.Data
{
    public class LibreriaPapeleriaContext : IdentityDbContext<IdentityUser>
    {
        public LibreriaPapeleriaContext(DbContextOptions<LibreriaPapeleriaContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<DetalleOrden> DetalleOrdenes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleOrden>()
                .HasKey(d => d.DetalleOrdenId);

            modelBuilder.Entity<DetalleOrden>()
                .HasOne(d => d.Orden)
                .WithMany(o => o.DetallesOrden)
                .HasForeignKey(d => d.OrdenId);

            modelBuilder.Entity<DetalleOrden>()
                .HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.ProductoId);

            // Configurar las propiedades decimal con HasColumnType
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Orden>()
                .Property(o => o.Total)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<DetalleOrden>()
                .Property(d => d.PrecioUnitario)
                .HasColumnType("decimal(10,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
