using Microsoft.EntityFrameworkCore;
using LibreriaPapeleriaApp.Models;

namespace LibreriaPapeleriaApp.Data
{
    public class LibreriaPapeleriaContext : DbContext
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
