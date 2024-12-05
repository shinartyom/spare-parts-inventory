using Microsoft.EntityFrameworkCore;
using WAD_00019330.Data;
using WAD_00019330.Models;

namespace WAD_00019330.Repositories
{
    public class SparePartRepository : IRepository<SparePart>
    {
        private readonly GeneralDBContext _context;

        public SparePartRepository(GeneralDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SparePart>> GetAll() => await _context.SpareParts.Include(t => t.SpareCategory).ToArrayAsync();

        public async Task<SparePart> GetByID(int id)
        {
            return await _context.SpareParts.Include(t => t.SpareCategory).FirstOrDefaultAsync(t => t.SparePartId == id);
        }

        public async Task Add(SparePart sparePart)
        {
            sparePart.SpareCategory = await _context.SpareCategories.FindAsync(sparePart.SparePartCategoryID.Value);

            await _context.SpareParts.AddAsync(sparePart);
            await _context.SaveChangesAsync();
        }

        public async Task Update(SparePart sparePart)
        {
            _context.Entry(sparePart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var sparePart = await _context.SpareParts.FindAsync(id);
            if (sparePart != null)
            {
                _context.SpareParts.Remove(sparePart);
                await _context.SaveChangesAsync();
            }
        }
    }
}
