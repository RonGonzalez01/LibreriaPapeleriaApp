using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.UsuarioId == id);

            if (Usuario == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
