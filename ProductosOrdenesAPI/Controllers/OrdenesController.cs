using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosOrdenesAPI.Data;
using ProductosOrdenesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ProductosOrdenesAPI.Controllers
{
    namespace ProductosOrdenesAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class OrdenesController : ControllerBase
        {
            private readonly ProductosOrdenesContext _context;

            public OrdenesController(ProductosOrdenesContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Orden>>> GetOrdenes()
            {
                return await _context.Ordenes.Include(o => o.DetallesOrden).ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Orden>> GetOrden(int id)
            {
                var orden = await _context.Ordenes.Include(o => o.DetallesOrden)
                                                  .FirstOrDefaultAsync(o => o.OrdenId == id);
                if (orden == null)
                {
                    return NotFound();
                }

                return orden;
            }

            [HttpPost]
            public async Task<ActionResult<Orden>> PostOrden(Orden orden)
            {
                _context.Ordenes.Add(orden);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetOrden", new { id = orden.OrdenId }, orden);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutOrden(int id, Orden orden)
            {
                if (id != orden.OrdenId)
                {
                    return BadRequest();
                }

                _context.Entry(orden).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(id))
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

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteOrden(int id)
            {
                var orden = await _context.Ordenes.FindAsync(id);
                if (orden == null)
                {
                    return NotFound();
                }

                _context.Ordenes.Remove(orden);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            private bool OrdenExists(int id)
            {
                return _context.Ordenes.Any(e => e.OrdenId == id);
            }
        }
    }
}
