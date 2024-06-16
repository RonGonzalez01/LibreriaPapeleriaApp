using System.Linq;
using System.Threading.Tasks;
using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibreriaPapeleriaApp.Pages.Ordenes
{
    public class DetailsModel : PageModel
    {
        private readonly LibreriaPapeleriaContext _context;

        public DetailsModel(LibreriaPapeleriaContext context)
        {
            _context = context;
        }

        public Orden Orden { get; set; }
        public IList<DetalleOrden> DetallesOrden { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Orden = await _context.Ordenes
                .Include(o => o.Usuario)
                .Include(o => o.DetallesOrden)
                .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(m => m.OrdenId == id);

            if (Orden == null)
            {
                return NotFound();
            }

            DetallesOrden = Orden.DetallesOrden.ToList();

            return Page();
        }
    }
}
