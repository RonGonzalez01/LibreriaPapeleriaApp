using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Data;
using Microsoft.EntityFrameworkCore;
using LibreriaPapeleriaApp.Services;

namespace LibreriaPapeleriaApp.Pages.Ordenes
{
    public class IndexModel : PageModel
    {
        private readonly ProductOrdenService _productOrdenService;

        public IndexModel(ProductOrdenService productOrdenService)
        {
            _productOrdenService = productOrdenService;
        }

        public IList<Orden> Ordenes { get; set; }

        public async Task OnGetAsync()
        {
            var ordenes = await _productOrdenService.GetOrdenesAsync();
            Ordenes = ordenes.ToList(); // Convertir a List<Orden> para evitar el error de conversión
        }
    }
}
