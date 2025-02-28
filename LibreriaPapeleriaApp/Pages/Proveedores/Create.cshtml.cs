using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Services;

namespace LibreriaPapeleriaApp.Pages.Proveedores
{
    public class CreateModel : PageModel
    {
        private readonly ProveedorService _proveedorService;

        public CreateModel(ProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [BindProperty]
        public Proveedor Proveedor { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _proveedorService.CreateProveedorAsync(Proveedor);
            return RedirectToPage("Index");
        }
    }
}
