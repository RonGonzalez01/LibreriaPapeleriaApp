using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace LibreriaPapeleriaApp.Pages.Usuarios
{
    public class CreateModel : PageModel
    {
        private readonly LibreriaPapeleriaContext _context;

        public CreateModel(LibreriaPapeleriaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; }

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

            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
