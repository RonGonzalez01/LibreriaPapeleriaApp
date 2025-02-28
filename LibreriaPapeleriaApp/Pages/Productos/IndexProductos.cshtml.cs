using System.Collections.Generic;
using System.Threading.Tasks;
using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibreriaPapeleriaApp.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly ProductOrdenService _productOrdenService;

        public IndexModel(ProductOrdenService productOrdenService)
        {
            _productOrdenService = productOrdenService;
        }

        public IList<Producto> Productos { get; set; }

        public async Task OnGetAsync()
        {
            var productos = await _productOrdenService.GetProductosAsync();
            Productos = productos.ToList(); // Convertir a List<Producto> para evitar el error de conversión
        }
    }
}