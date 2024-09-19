using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KelasController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public KelasController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Kelas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kelas>>> GetKelas()
        {
            return await _context.Kelas.ToListAsync();
        }

        // GET: api/Kelas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kelas>> GetKelas(int id)
        {
            var kelas = await _context.Kelas.FindAsync(id);

            if (kelas == null)
            {
                return NotFound();
            }

            return kelas;
        }

        // PUT: api/Kelas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKelas(int id, Kelas kelas)
        {
            if (id != kelas.Id)
            {
                return BadRequest();
            }

            _context.Entry(kelas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KelasExists(id))
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

        // POST: api/Kelas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kelas>> PostKelas(Kelas kelas)
        {
            _context.Kelas.Add(kelas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKelas", new { id = kelas.Id }, kelas);
        }

        // DELETE: api/Kelas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKelas(int id)
        {
            var kelas = await _context.Kelas.FindAsync(id);
            if (kelas == null)
            {
                return NotFound();
            }

            _context.Kelas.Remove(kelas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KelasExists(int id)
        {
            return _context.Kelas.Any(e => e.Id == id);
        }
    }
}
