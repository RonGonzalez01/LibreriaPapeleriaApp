using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Services;

namespace LibreriaPapeleriaApp.Pages.Productos
{
    public class EditModel : PageModel
    {
        private readonly ProductOrdenService _productOrdenService;

        public EditModel(ProductOrdenService productOrdenService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productOrdenService.UpdateProductoAsync(Producto);
            return RedirectToPage("Index");
        }
    }
}