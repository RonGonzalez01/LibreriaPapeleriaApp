using Microsoft.AspNetCore.Mvc;
using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibreriaPapeleriaApp.Services;

namespace LibreriaPapeleriaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductOrdenService _productOrdenService;

        public ProductosController(ProductOrdenService productOrdenService)
        {
            _productOrdenService = productOrdenService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            return Ok(await _productOrdenService.GetProductosAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await _productOrdenService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Producto producto)
        {
            await _productOrdenService.CreateProductoAsync(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.ProductoId }, producto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return BadRequest();
            }
            await _productOrdenService.UpdateProductoAsync(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productOrdenService.DeleteProductoAsync(id);
            return NoContent();
        }
    }
}
