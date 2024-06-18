namespace LibreriaPapeleriaApp.Models
{
    public class DetalleOrden
    {
        public int DetalleOrdenId { get; set; }
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; } // Tipo decimal
    }
}
