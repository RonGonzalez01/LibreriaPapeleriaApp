using LibreriaPapeleriaApp.Models;
using LibreriaPapeleriaApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaPapeleriaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoresController : ControllerBase
    {
        private readonly ProveedorService _proveedorService;

        public ProveedoresController(ProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> Get()
        {
            return Ok(await _proveedorService.GetProveedoresAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> Get(int id)
        {
            var proveedor = await _proveedorService.GetProveedorByIdAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Proveedor proveedor)
        {
            await _proveedorService.CreateProveedorAsync(proveedor);
            return CreatedAtAction(nameof(Get), new { id = proveedor.ProveedorId }, proveedor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Proveedor proveedor)
        {
            if (id != proveedor.ProveedorId)
            {
                return BadRequest();
            }
            await _proveedorService.UpdateProveedorAsync(proveedor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _proveedorService.DeleteProveedorAsync(id);
            return NoContent();
        }
    }
}
