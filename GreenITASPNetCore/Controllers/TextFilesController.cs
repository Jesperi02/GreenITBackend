using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenITASPNetCore.Models;
using GreenITASPNetCore.Services;

namespace GreenITASPNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextFilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public TextFilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        // GET: api/TextFiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TextFile>>> GetTextFiles()
        {
            IEnumerable<TextFileDTO> response = await _fileService.GetFilesAsync();
            return Ok(response);
        }

        // GET: api/TextFiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TextFile>> GetTextFile(long id)
        {
            TextFileDTO textFileDTO = await _fileService.GetFileAsync(id);

            if (textFileDTO == null)
            {
                return NotFound();
            }

            return Ok(textFileDTO);
        }

        // PUT: api/TextFiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTextFile(long id, TextFileDTO textFileDTO)
        {
            if (id != textFileDTO.Id)
            {
                return BadRequest();
            }

            TextFileDTO updatedFile = await _fileService.UpdateFileAsync(textFileDTO);

            if (updatedFile == null)
            {
                return Problem();
            }

            return Ok(updatedFile);
        }

        // POST: api/TextFiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TextFile>> PostTextFile(TextFileDTO textFileDTO)
        {
            TextFileDTO newDTO = await _fileService.CreateFileAsync(textFileDTO);

            if (newDTO == null)
            {
                return Problem();
            }

            return Ok(newDTO);
            //return CreatedAtAction("GetItem", new { id = newDTO.Id }, newDTO);
        }

        // DELETE: api/TextFiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTextFile(long id)
        {
            bool deleted = await _fileService.DeleteFileAsync(id);

            if (deleted)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
