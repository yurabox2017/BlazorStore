using BlazorStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Repository.Services
{
    public class DbOrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _db;
        public DbOrdersRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<OrderDetails>> GetAllOrderDetails()
        {
            return await _db.OrderDetails.Include(x => x.Order).Include(x => x.Product).Include(x => x.Customer).ToListAsync();
        }
    }
}
