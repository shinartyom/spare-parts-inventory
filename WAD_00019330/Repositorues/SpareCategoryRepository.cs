using Microsoft.EntityFrameworkCore;
using WAD_00019330.Data;
using WAD_00019330.Models;

namespace WAD_00019330.Repositories
{
    public class SpareCategoryRepository : IRepository<SpareCategory>
    {
        private readonly GeneralDBContext _context;
        public SpareCategoryRepository(GeneralDBContext context)
        {
            _context = context;
        }

        public async Task Add(SpareCategory spareCategory)
        {
            await _context.SpareCategories.AddAsync(spareCategory);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.SpareCategories.FindAsync(id);
            if (entity != null)
            {
                _context.SpareCategories.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SpareCategory>> GetAll() => await _context.SpareCategories.ToArrayAsync();

        public async Task<SpareCategory> GetByID(int id) => await _context.SpareCategories.FindAsync(id);

        public async Task Update(SpareCategory spareCategory)
        {
            _context.Entry(spareCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
