using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD_00019330.Data;
using WAD_00019330.Models;
using WAD_00019330.Repositories;

namespace WAD_00019330.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpareCategoriesController : ControllerBase
    {
        private readonly IRepository<SpareCategory> _spareCategoryRepository;
        public SpareCategoriesController(IRepository<SpareCategory> spareCategoryRepository)
        {
            _spareCategoryRepository = spareCategoryRepository;
        }

        // GET: api/SpareCategories
        [HttpGet]
        public async Task<IEnumerable<SpareCategory>> GetSpareCategories() => await _spareCategoryRepository.GetAll();

        // POST: api/SpareCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpareCategory>> PostSpareCategory(SpareCategory spareCategory)
        {
            await _spareCategoryRepository.Add(spareCategory);
            return CreatedAtAction(nameof(GetSpareCategory), new { id = spareCategory.SpareCategoryId }, spareCategory);
        }

        // PUT: api/SpareCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutSpareCategory(int id, SpareCategory spareCategory)
        {
            await _spareCategoryRepository.Update(spareCategory);
            return NoContent();
        }

        // GET: api/SpareCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpareCategory>> GetSpareCategory(int id)
        {
            SpareCategory spareCategory = await _spareCategoryRepository.GetByID(id);
            if (spareCategory == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(spareCategory);
            }
        }

        // DELETE: api/SpareCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpareCategory(int id)
        {
            await _spareCategoryRepository.Delete(id);
            return NoContent();
        }

        //private bool SpareCategoryExists(int id)
        //{
        //    return (_context.SpareCategories?.Any(e => e.SpareCategoryId == id)).GetValueOrDefault();
        //}
    }
}
