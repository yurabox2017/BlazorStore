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

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            if (category is null)
                return false;

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var categoryFromDb = await _context.Categories.FindAsync(id);
            if (categoryFromDb is null)
                return false;
            _context.Categories.Remove(categoryFromDb);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetAllCategoriesAsync() => await _context.Categories.ToListAsync();

        public async Task<Category> GetSingleCategoryAsync(int id) => await _context.Categories.FindAsync(id);

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            var categoryFromDb = await _context.Categories.FindAsync(category.Id);
            if (categoryFromDb is null)
                return false;

            categoryFromDb.Name = category.Name;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
