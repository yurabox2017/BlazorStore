using BlazorStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Repository.Services
{
    public class DbGoodsMarkerRepository : IRepositoryGoodsMarker
    {
        private readonly ApplicationDbContext _db;
        public DbGoodsMarkerRepository(ApplicationDbContext db) => _db = db;

        public async Task<bool> CreateGoodsMarkerAsync(GoodsMarker goodsMarker)
        {
            if (goodsMarker is null)
                return false;
            await _db.GoodsMarkers.AddAsync(goodsMarker);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteGoodsMarkerAsync(int id)
        {
            var goodsMarkerFromDb = await _db.GoodsMarkers.FindAsync(id);
            if (goodsMarkerFromDb is null)
                return false;
            _db.GoodsMarkers.Remove(goodsMarkerFromDb);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<GoodsMarker>> GetAllGoodsMarkersAsync() => await _db.GoodsMarkers.ToListAsync();

        public async Task<GoodsMarker> GetSingleGoodsMarkerAsync(int id) => await _db.GoodsMarkers.FindAsync(id);


        public async Task<bool> UpdateGoodsMarkerAsync(GoodsMarker goodsMarker)
        {
            var goodsMarkerFromDb = await _db.GoodsMarkers.FindAsync(goodsMarker.Id);
            if (goodsMarkerFromDb is null)
                return false;

            goodsMarkerFromDb.Name = goodsMarker.Name;

            await _db.SaveChangesAsync();
            return true;
        }
    }
}
