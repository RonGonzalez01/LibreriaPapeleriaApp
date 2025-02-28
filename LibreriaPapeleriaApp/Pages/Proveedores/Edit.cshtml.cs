using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Services;

namespace LibreriaPapeleriaApp.Pages.Proveedores
{
    public class EditModel : PageModel
    {
        private readonly ProveedorService _proveedorService;

        public EditModel(ProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [BindProperty]
        public Proveedor Proveedor { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Proveedor = await _proveedorService.GetProveedorByIdAsync(id);

            if (Proveedor == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _proveedorService.UpdateProveedorAsync(Proveedor);
            return RedirectToPage("Index");
        }
    }
}