using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Services;


namespace LibreriaPapeleriaApp.Pages.Proveedores
{
    public class IndexModel : PageModel
    {
        private readonly ProveedorService _proveedorService;

        public IndexModel(ProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        public IList<Proveedor> Proveedores { get; set; }

        public async Task OnGetAsync()
        {
            var proveedores = await _proveedorService.GetProveedoresAsync();
            Proveedores = proveedores.ToList(); // Convertir a List<Proveedor> para evitar el error de conversión
        }
    }
}
