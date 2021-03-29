using BlazorStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Repository
{
    public interface IRepositoryCategory
    {
        Task<List<Category>> GetAllCategories();
    }
}
