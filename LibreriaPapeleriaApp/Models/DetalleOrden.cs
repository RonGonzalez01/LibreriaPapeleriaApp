using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaPapeleriaApp.Models
{
    public class DetalleOrden
    {
        public int DetalleOrdenId { get; set; }
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }  // Propiedad de navegación hacia Orden

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }  // Propiedad de navegación hacia Producto

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
