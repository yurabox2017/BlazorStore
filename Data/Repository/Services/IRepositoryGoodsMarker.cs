using BlazorStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Repository.Services
{
   public interface IRepositoryGoodsMarker
    {
        Task<List<GoodsMarker>> GetAllGoodsMarkersAsync();
        Task<bool> CreateGoodsMarkerAsync(GoodsMarker goodsMarker);
        Task<bool> UpdateGoodsMarkerAsync(GoodsMarker goodsMarker);
        Task<bool> DeleteGoodsMarkerAsync(int id);
        Task<GoodsMarker> GetSingleGoodsMarkerAsync(int id);
    }
}
