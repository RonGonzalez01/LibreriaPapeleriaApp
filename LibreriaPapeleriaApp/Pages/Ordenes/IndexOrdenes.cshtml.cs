using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LibreriaPapeleriaApp.Pages.Ordenes
{
    public class IndexOrdenesModel : PageModel
    {
        private readonly LibreriaPapeleriaContext _context;

        public IndexOrdenesModel(LibreriaPapeleriaContext context)
        {
            _context = context;
        }

        public IList<Orden> Ordenes { get; set; }

        public async Task OnGetAsync()
        {
            Ordenes = await _context.Ordenes
                .Include(o => o.DetallesOrden)
                .ToListAsync();
        }
    }
}
