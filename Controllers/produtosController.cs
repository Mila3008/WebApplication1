using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class produtosController : ControllerBase
    {
        private readonly WebApplication1Context _context;

        public produtosController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: api/produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<produtos>>> Getprodutos()
        {
            return await _context.produtos.ToListAsync();
        }

        // GET: api/produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<produtos>> Getprodutos(Guid id)
        {
            var produtos = await _context.produtos.FindAsync(id);

            if (produtos == null)
            {
                return NotFound();
            }

            return produtos;
        }

        // PUT: api/produtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putprodutos(Guid id, produtos produtos)
        {
            if (id != produtos.Id)
            {
                return BadRequest();
            }

            _context.Entry(produtos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!produtosExists(id))
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

        // POST: api/produtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<produtos>> Postprodutos(produtos produtos)
        {
            _context.produtos.Add(produtos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getprodutos", new { id = produtos.Id }, produtos);
        }

        // DELETE: api/produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteprodutos(Guid id)
        {
            var produtos = await _context.produtos.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }

            _context.produtos.Remove(produtos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool produtosExists(Guid id)
        {
            return _context.produtos.Any(e => e.Id == id);
        }
    }
}
