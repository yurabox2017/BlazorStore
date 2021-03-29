using BlazorStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Repository
{
    public class DbCategoryRepository : IRepositoryCategory
    {
        private readonly ApplicationDbContext _context;
        public DbCategoryRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
