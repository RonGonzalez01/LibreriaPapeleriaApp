using System;
using System.Collections.Generic;

namespace LibreriaPapeleriaApp.Models
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; } // Tipo decimal
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<DetalleOrden> DetallesOrden { get; set; }
    }
}
