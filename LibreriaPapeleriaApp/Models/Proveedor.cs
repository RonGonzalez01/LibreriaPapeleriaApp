﻿using System.ComponentModel.DataAnnotations;

namespace LibreriaPapeleriaApp.Models
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}

