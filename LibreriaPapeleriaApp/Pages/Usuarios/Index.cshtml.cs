using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibreriaPapeleriaApp.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly LibreriaPapeleriaContext _context;

        public IndexModel(LibreriaPapeleriaContext context)
        {
            _context = context;
        }

        public IList<Usuario> Usuarios { get; set; }

        public async Task OnGetAsync()
        {
            Usuarios = await _context.Usuarios.ToListAsync();
        }
    }
}
