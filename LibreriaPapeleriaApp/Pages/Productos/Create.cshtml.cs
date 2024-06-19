using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Data;

namespace LibreriaPapeleriaApp.Pages.Productos
{
    public class CreateModel : PageModel
    {
        private readonly LibreriaPapeleriaContext _context;

        public CreateModel(LibreriaPapeleriaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Productos.Add(Producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexProductos");
        }
    }
}
