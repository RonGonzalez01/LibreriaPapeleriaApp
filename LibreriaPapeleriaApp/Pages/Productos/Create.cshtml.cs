using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Services;

namespace LibreriaPapeleriaApp.Pages.Productos
{
    public class CreateModel : PageModel
    {
        private readonly ProductOrdenService _productOrdenService;

        public CreateModel(ProductOrdenService productOrdenService)
        {
            _productOrdenService = productOrdenService;
        }

        [BindProperty]
        public Producto Producto { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productOrdenService.CreateProductoAsync(Producto);
            return RedirectToPage("Index");
        }
    }
}
