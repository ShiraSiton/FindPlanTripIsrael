using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IImageRepository
    {
        Task<List<Image>> GetAllAsync();
        Task<List<Image>> GetFilteredImagesAsync(ItemType? itemType, int? placeId, int? routeId);
        Task<Image?> GetByIdAsync(int id);
        Task<Image?> GetMainImageAsync(ItemType itemType, int? placeId, int? routeId);
        Task<Image> AddAsync(Image item);
        Task<Image> UpdateAsync(Image item);
        Task<bool> DeleteAsync(int id);
    }
}
