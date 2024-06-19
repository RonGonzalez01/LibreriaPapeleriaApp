using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Data;

namespace LibreriaPapeleriaApp.Pages.Productos
{
    public class DeleteModel : PageModel
    {
        private readonly LibreriaPapeleriaContext _context;

        public DeleteModel(LibreriaPapeleriaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producto = await _context.Productos.FindAsync(id);

            if (Producto == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producto = await _context.Productos.FindAsync(id);

            if (Producto != null)
            {
                _context.Productos.Remove(Producto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IndexProductos");
        }
    }
}
