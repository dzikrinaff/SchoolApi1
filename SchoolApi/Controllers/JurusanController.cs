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
    public class JurusanController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public JurusanController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Jurusans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jurusan>>> Getjurusans()
        {
            return await _context.jurusans.ToListAsync();
        }

        // GET: api/Jurusans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jurusan>> GetJurusan(int id)
        {
            var jurusan = await _context.jurusans.FindAsync(id);

            if (jurusan == null)
            {
                return NotFound();
            }

            return jurusan;
        }

        // PUT: api/Jurusans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJurusan(int id, Jurusan jurusan)
        {
            if (id != jurusan.Id)
            {
                return BadRequest();
            }

            _context.Entry(jurusan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JurusanExists(id))
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

        // POST: api/Jurusans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jurusan>> PostJurusan(Jurusan jurusan)
        {
            _context.jurusans.Add(jurusan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJurusan", new { id = jurusan.Id }, jurusan);
        }

        // DELETE: api/Jurusans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJurusan(int id)
        {
            var jurusan = await _context.jurusans.FindAsync(id);
            if (jurusan == null)
            {
                return NotFound();
            }

            _context.jurusans.Remove(jurusan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JurusanExists(int id)
        {
            return _context.jurusans.Any(e => e.Id == id);
        }
    }
}
