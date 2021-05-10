using BlazorStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Repository.Services
{
    public interface IOrdersRepository
    {
        Task<List<OrderDetails>> GetAllOrderDetails();
    }
}
