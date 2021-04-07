using BlazorStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Repository.Services
{
    public interface IRepositoryProduct
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Category>> GetAllCategories();
        Task<List<GoodsMarker>> GetAllGoodsMarkers();
        Task<bool> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<Product> GetSingleProductAsync(int id);

    }
}
