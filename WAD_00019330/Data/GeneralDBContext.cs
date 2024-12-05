using Microsoft.EntityFrameworkCore;
using WAD_00019330.Models;

namespace WAD_00019330.Data
{
    public class GeneralDBContext : DbContext
    {
        public GeneralDBContext(DbContextOptions<GeneralDBContext> options) : base(options) { }

        public DbSet<SpareCategory> SpareCategories { get; set; }

        public DbSet<SparePart> SpareParts { get; set; }
    }
}
