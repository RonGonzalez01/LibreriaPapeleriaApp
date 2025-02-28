using System.Linq;
using System.Threading.Tasks;
using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibreriaPapeleriaApp.Pages.Ordenes
{
    public class DetailsModel : PageModel
    {
        private readonly ProductOrdenService _productOrdenService;

        public DetailsModel(ProductOrdenService productOrdenService)
        {
            _productOrdenService = productOrdenService;
        }

        public Orden Orden { get; set; }
        public IList<DetalleOrden> DetallesOrden { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Orden = await _productOrdenService.GetOrdenByIdAsync(id);

            if (Orden == null)
            {
                return NotFound();
            }

            DetallesOrden = Orden.DetallesOrden.ToList(); // Convert to IList<DetalleOrden>
            return Page();
        }
    }
}
