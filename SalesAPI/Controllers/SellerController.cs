using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesAPI.DbModel;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly DbSalesContext _context;

        public SellerController(DbSalesContext context)
        {
            _context = context;
        }

        // GET: api/Seller
        [HttpGet]
        public IEnumerable<Seller> GetSeller()
        {
            return _context.Seller;
        }

        // GET: api/Seller/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeller([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seller = await _context.Seller.FindAsync(id);

            if (seller == null)
            {
                return NotFound();
            }

            return Ok(seller);
        }

        // PUT: api/Seller/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeller([FromRoute] int id, [FromBody] Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seller.Id)
            {
                return BadRequest();
            }

            _context.Entry(seller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(id))
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

        // POST: api/Seller
        [HttpPost]
        public async Task<IActionResult> PostSeller([FromBody] Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Seller.Add(seller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeller", new { id = seller.Id }, seller);
        }

        // DELETE: api/Seller/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeller([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seller = await _context.Seller.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }

            _context.Seller.Remove(seller);
            await _context.SaveChangesAsync();

            return Ok(seller);
        }

        private bool SellerExists(int id)
        {
            return _context.Seller.Any(e => e.Id == id);
        }
    }
}