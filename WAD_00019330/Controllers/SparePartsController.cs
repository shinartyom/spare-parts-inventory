using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using WAD_00019330.Data;
using WAD_00019330.Models;
using WAD_00019330.Repositories;

namespace WAD_00019330.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SparePartsController : ControllerBase
    {
        private readonly IRepository<SparePart> _sparePartRepository;
        public SparePartsController(IRepository<SparePart> sparePartRepository)
        {
            _sparePartRepository = sparePartRepository;
        }

        // GET: api/SpareParts
        [HttpGet]
        public async Task<IEnumerable<SparePart>> GetSpareParts() => await _sparePartRepository.GetAll();

        // POST: api/SpareParts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SparePart>> PostSparePart(SparePart sparePart)
        {
            await _sparePartRepository.Add(sparePart);
            return CreatedAtAction(nameof(GetSparePart), new { id = sparePart.SparePartId }, sparePart);
        }

        // PUT: api/SpareParts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutSparePart(int id, SparePart sparePart)
        {
            await _sparePartRepository.Update(sparePart);
            return NoContent();
        }

        // GET: api/SpareParts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SparePart>> GetSparePart(int id)
        {
            SparePart sparePart = await _sparePartRepository.GetByID(id);
            if (sparePart == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(sparePart);
            }
        }

        // DELETE: api/SpareParts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSparePart(int id)
        {
            await _sparePartRepository.Delete(id);
            return NoContent();
        }

        //private bool SparePartExists(int id)
        //{
        //    return (_context.SpareParts?.Any(e => e.SparePartId == id)).GetValueOrDefault();
        //}
    }
}
