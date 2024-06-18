using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace LibreriaPapeleriaApp.Pages.Usuarios
{
    public class DetailsModel : PageModel
    {
        private readonly LibreriaPapeleriaContext _context;

        public DetailsModel(LibreriaPapeleriaContext context)
        {
            _context = context;
        }

        public Usuario Usuario { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Usuario = await _context.Usuarios.FindAsync(id);

            if (Usuario == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
