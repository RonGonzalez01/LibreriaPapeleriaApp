using System.Collections.Generic;
using System.Threading.Tasks;
using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibreriaPapeleriaApp.Pages.Productos
{
    public class IndexProductosModel : PageModel
    {
        private readonly LibreriaPapeleriaContext _context;

        public IndexProductosModel(LibreriaPapeleriaContext context)
        {
            _context = context;
        }

        public IList<Producto> Productos { get; set; }

        public async Task OnGetAsync()
        {
            Productos = await _context.Productos.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexProductos");
        }
    }
}
