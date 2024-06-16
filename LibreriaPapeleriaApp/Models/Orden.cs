using System;
using System.Collections.Generic;

namespace LibreriaPapeleriaApp.Models
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        // Relación con Usuario
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Relación con DetalleOrdenes
        public List<DetalleOrden> DetallesOrden { get; set; }
    }
}
