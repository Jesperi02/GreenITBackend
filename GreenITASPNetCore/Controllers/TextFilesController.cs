using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenITASPNetCore.Models;

namespace GreenITASPNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextFilesController : ControllerBase
    {
        private readonly FileContext _context;

        public TextFilesController(FileContext context)
        {
            _context = context;
        }

        // GET: api/TextFiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TextFile>>> GetTextFiles()
        {
            return await _context.TextFiles.ToListAsync();
        }

        // GET: api/TextFiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TextFile>> GetTextFile(long id)
        {
            var textFile = await _context.TextFiles.FindAsync(id);

            if (textFile == null)
            {
                return NotFound();
            }

            return textFile;
        }

        // PUT: api/TextFiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTextFile(long id, TextFile textFile)
        {
            if (id != textFile.Id)
            {
                return BadRequest();
            }

            _context.Entry(textFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TextFileExists(id))
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

        // POST: api/TextFiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TextFile>> PostTextFile(TextFile textFile)
        {
            _context.TextFiles.Add(textFile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTextFile", new { id = textFile.Id }, textFile);
        }

        // DELETE: api/TextFiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTextFile(long id)
        {
            var textFile = await _context.TextFiles.FindAsync(id);
            if (textFile == null)
            {
                return NotFound();
            }

            _context.TextFiles.Remove(textFile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TextFileExists(long id)
        {
            return _context.TextFiles.Any(e => e.Id == id);
        }
    }
}
