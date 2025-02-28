using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibreriaPapeleriaApp.Data; // Asegúrate de tener la referencia al contexto de la base de datos
using System.Threading.Tasks;
using System.Linq;
using LibreriaPapeleriaApp.Services;
using LibreriaPapeleriaApp.Models;

namespace LibreriaPapeleriaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenesController : ControllerBase
    {
        private readonly ProductOrdenService _productOrdenService;

        public OrdenesController(ProductOrdenService productOrdenService)
        {
            _productOrdenService = productOrdenService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orden>>> Get()
        {
            return Ok(await _productOrdenService.GetOrdenesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orden>> Get(int id)
        {
            var orden = await _productOrdenService.GetOrdenByIdAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            return Ok(orden);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Orden orden)
        {
            await _productOrdenService.CreateOrdenAsync(orden);
            return CreatedAtAction(nameof(Get), new { id = orden.OrdenId }, orden);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Orden orden)
        {
            if (id != orden.OrdenId)
            {
                return BadRequest();
            }
            await _productOrdenService.UpdateOrdenAsync(orden);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productOrdenService.DeleteOrdenAsync(id);
            return NoContent();
        }
    }
}