using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibreriaPapeleriaApp.Pages.Ordenes
{
    public class CreateModel : PageModel
    {
        private readonly ProductOrdenService _productOrdenService;

        public CreateModel(ProductOrdenService productOrdenService)
        {
            _productOrdenService = productOrdenService;
        }

        [BindProperty]
        public Orden Orden { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productOrdenService.CreateOrdenAsync(Orden);
            return RedirectToPage("Index");
        }
    }
}