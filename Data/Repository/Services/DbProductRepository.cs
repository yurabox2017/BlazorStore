using BlazorStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Repository.Services
{
    public class DbProductRepository : IRepositoryProduct
    {
        private readonly ApplicationDbContext _db;
        public DbProductRepository(ApplicationDbContext db) => _db = db;

        public async Task<bool> CreateProductAsync(Product product)
        {
            if (product is null)
                return false;
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var productFromDb = await _db.Products.FindAsync(id);
            if (productFromDb is null)
                return false;
            _db.Products.Remove(productFromDb);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllProductsAsync() => await _db.Products.Include(x => x.Category).ToListAsync();

        public async Task<Product> GetSingleProductAsync(int id) => await _db.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id.Equals(id));


        public async Task<bool> UpdateProductAsync(Product product)
        {
            var productFromDb = await _db.Products.FindAsync(product.Id);
            if (productFromDb is null)
                return false;

            if (product.Image is null)
                product.Image = productFromDb.Image;


            _db.Products.Update(product);

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetAllCategories() => await _db.Categories.ToListAsync();
        public async Task<List<GoodsMarker>> GetAllGoodsMarkers() => await _db.GoodsMarkers.ToListAsync();

    }
}
