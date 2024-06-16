using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibreriaPapeleriaApp.Data; // Asegúrate de tener la referencia al contexto de la base de datos
using System.Threading.Tasks;
using System.Linq;

namespace LibreriaPapeleriaApp.Controllers
{
    public class OrdenesController : Controller
    {
        private readonly LibreriaPapeleriaContext _context;

        public OrdenesController(LibreriaPapeleriaContext context)
        {
            _context = context;
        }

        // GET: /Ordenes
        public async Task<IActionResult> Index()
        {
            var ordenes = await _context.Ordenes
                .Include(o => o.Detalles)
                .ToListAsync();

            return View(ordenes);
        }
    }
}
