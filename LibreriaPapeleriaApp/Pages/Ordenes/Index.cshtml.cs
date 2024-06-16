using System.Collections.Generic;
using System.Threading.Tasks;
using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibreriaPapeleriaApp.Pages.Ordenes
{
    public class IndexModel : PageModel
    {
        private readonly LibreriaPapeleriaContext _context;

        public IndexModel(LibreriaPapeleriaContext context)
        {
            _context = context;
        }

        public IList<Models.Ordenes> Ordenes { get; set; }

        public async Task OnGetAsync()
        {
            Ordenes = await _context.Ordenes
                .Include(o => o.Detalles) // Carga los detalles de la orden
                .ToListAsync();
        }
    }
}
