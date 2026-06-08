using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IContext _context;
        public ImageRepository(IContext context)
        {
            this._context = context;
        }

        public async Task<Image> AddAsync(Image item)
        {
            _context.Images.Add(item);
            await _context.save();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null)
                return false;
            _context.Images.Remove(item);
            await _context.save();
            return true;
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await _context.Images.ToListAsync();
        }
        public async Task<List<Image>> GetFilteredImagesAsync(ItemType? itemType, int? placeId, int? routeId)
        {
            var query = _context.Images.AsQueryable();

            if (itemType != null)
                query = query.Where(x => x.ItemType == itemType);

            if (placeId != null)
                query = query.Where(x => x.PlaceId == placeId);

            if (routeId != null)
                query = query.Where(x => x.RouteId == routeId);

            return await query.ToListAsync();
        }

        public async Task<Image?> GetByIdAsync(int id)
        {
            return await _context.Images.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Image?> GetMainImageAsync(ItemType itemType, int? placeId, int? routeId)
        {
            return await _context.Images.FirstOrDefaultAsync(x =>
                x.ItemType == itemType &&
                x.IsMain &&
                (itemType == ItemType.Place ? x.PlaceId == placeId : x.RouteId == routeId)
            );
        }

        public async Task<Image> UpdateAsync(Image item)
        {
            _context.Images.Update(item);
            await _context.save();
            return item;
        }
    }
}
