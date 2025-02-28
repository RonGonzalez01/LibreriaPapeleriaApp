namespace ProductosOrdenesAPI.Models
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string UsuarioId { get; set; }
        public ICollection<DetalleOrden> DetallesOrden { get; set; }
    }

}
