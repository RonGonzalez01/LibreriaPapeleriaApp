using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibreriaPapeleriaApp.Pages.Productos
{
    public class DetailsModel : PageModel
    {
        private readonly LibreriaPapeleriaContext _context;

        public DetailsModel(LibreriaPapeleriaContext context)
        {
            _context = context;
        }

        public Producto Producto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producto = await _context.Productos.FirstOrDefaultAsync(m => m.ProductoId == id);

            if (Producto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
