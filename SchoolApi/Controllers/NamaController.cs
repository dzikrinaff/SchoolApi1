using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApi.Models;
using SchoolApi.Data;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamaController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public NamaController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Namases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nama>>> GetNamases()
        {
            return await _context.Namas
                .Include(n => n.Kelas)
                .Include(n => n.jurusan)
                .ToListAsync();
        }

        // GET: api/Namases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nama>> GetNama(int id)
        {
            var nama = await _context.Namas
                .Include(n => n.Kelas)
                .Include(n => n.jurusan)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (nama == null)
            {
                return NotFound();
            }

            return nama;
        }

        // POST: api/Namases
        [HttpPost]
        public async Task<ActionResult<Nama>> PostNama(Nama nama)
        {
            await PopulateNavigationProperties(nama);

            _context.Namas.Add(nama);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNama), new { id = nama.Id }, nama);
        }

        // PUT: api/Namases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNama(int id, Nama nama)
        {
            if (id != nama.Id)
            {
                return BadRequest();
            }

            await PopulateNavigationProperties(nama);

            _context.Entry(nama).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NamaExists(id))
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

        // DELETE: api/Namases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNama(int id)
        {
            var nama = await _context.Namas.FindAsync(id);
            if (nama == null)
            {
                return NotFound();
            }

            _context.Namas.Remove(nama);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NamaExists(int id)
        {
            return _context.Namas.Any(e => e.Id == id);
        }

        private async Task PopulateNavigationProperties(Nama nama)
        {
            if (nama.KelasId > 0)
            {
                nama.Kelas = await _context.Kelas.FindAsync(nama.KelasId);
            }

            if (nama.JurusanId > 0)
            {
                nama.jurusan = await _context.jurusans.FindAsync(nama.JurusanId);
            }
        }
    }
}
