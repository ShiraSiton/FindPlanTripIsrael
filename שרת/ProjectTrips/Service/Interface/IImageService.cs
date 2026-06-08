using Repository.Entities;
using Service.Dto.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IImageService
    {
        Task<ImageDto> AddAsync(ImageCreateDto dto);
        Task<List<ImageDto>> GetAllAsync(ItemType? itemType = null, int? placeId = null, int? routeId = null);
        Task<List<ImageDto>> GetByPlaceIdAsync(int placeId);
        Task<List<ImageDto>> GetByRouteIdAsync(int routeId);
        Task<ImageDto> GetByIdAsync(int id);
        Task<ImageDto?> GetMainByPlaceIdAsync(int placeId);
        Task<ImageDto?> GetMainByRouteIdAsync(int routeId);
        Task<ImageDto> UpdateIsMainAsync(int userId, int imageId, UpdateIsMainImageDto dto);
        Task<bool> DeleteAsync(int userId, int imageId);
    }
}
