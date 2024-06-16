using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibreriaPapeleriaApp.Pages.Usuarios
{
    public class DeleteModel : PageModel
    {
        private readonly LibreriaPapeleriaContext _context;

        public DeleteModel(LibreriaPapeleriaContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Usuario = await _context.Usuarios.FindAsync(id);

            if (Usuario != null)
            {
                _context.Usuarios.Remove(Usuario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
