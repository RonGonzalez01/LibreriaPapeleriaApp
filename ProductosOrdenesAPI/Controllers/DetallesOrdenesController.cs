using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosOrdenesAPI.Data;
using ProductosOrdenesAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosOrdenesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesOrdenesController : ControllerBase
    {
        private readonly ProductosOrdenesContext _context;

        public DetallesOrdenesController(ProductosOrdenesContext context)
        {
            _context = context;
        }

        // GET: api/DetallesOrdenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleOrden>>> GetDetalleOrdenes()
        {
            return await _context.DetalleOrdenes
                .Include(d => d.Orden)
                .Include(d => d.Producto)
                .ToListAsync();
        }

        // GET: api/DetallesOrdenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleOrden>> GetDetalleOrden(int id)
        {
            var detalleOrden = await _context.DetalleOrdenes
                .Include(d => d.Orden)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(d => d.DetalleOrdenId == id);

            if (detalleOrden == null)
            {
                return NotFound();
            }

            return detalleOrden;
        }

        // POST: api/DetallesOrdenes
        [HttpPost]
        public async Task<ActionResult<DetalleOrden>> PostDetalleOrden(DetalleOrden detalleOrden)
        {
            _context.DetalleOrdenes.Add(detalleOrden);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDetalleOrden), new { id = detalleOrden.DetalleOrdenId }, detalleOrden);
        }

        // PUT: api/DetallesOrdenes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleOrden(int id, DetalleOrden detalleOrden)
        {
            if (id != detalleOrden.DetalleOrdenId)
            {
                return BadRequest();
            }

            _context.Entry(detalleOrden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleOrdenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/DetallesOrdenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleOrden(int id)
        {
            var detalleOrden = await _context.DetalleOrdenes.FindAsync(id);
            if (detalleOrden == null)
            {
                return NotFound();
            }

            _context.DetalleOrdenes.Remove(detalleOrden);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleOrdenExists(int id)
        {
            return _context.DetalleOrdenes.Any(e => e.DetalleOrdenId == id);
        }
    }
}
