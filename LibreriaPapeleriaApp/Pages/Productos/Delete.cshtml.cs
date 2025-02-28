using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Services;

namespace LibreriaPapeleriaApp.Pages.Productos
{
    public class DeleteModel : PageModel
    {
        private readonly ProductOrdenService _productOrdenService;

        public DeleteModel(ProductOrdenService productOrdenService)
        {
            _productOrdenService = productOrdenService;
        }

        [BindProperty]
        public Producto Producto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Producto = await _productOrdenService.GetProductoByIdAsync(id);

            if (Producto == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _productOrdenService.DeleteProductoAsync(id);
            return RedirectToPage("Index");
        }
    }
}
