using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibreriaPapeleriaApp.Pages.Ordenes
{
    public class DeleteModel : PageModel
    {
        private readonly ProductOrdenService _productOrdenService;

        public DeleteModel(ProductOrdenService productOrdenService)
        {
            _productOrdenService = productOrdenService;
        }

        [BindProperty]
        public Orden Orden { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Orden = await _productOrdenService.GetOrdenByIdAsync(id);

            if (Orden == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _productOrdenService.DeleteOrdenAsync(id);
            return RedirectToPage("Index");
        }
    }
}
