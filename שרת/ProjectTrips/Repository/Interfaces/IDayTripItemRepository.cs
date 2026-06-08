using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDayTripItemRepository
    {
        Task<List<DayTripItem>> GetAllAsync();
        Task<List<DayTripItem>> GetByDayTripIdAsync(int dayTripId);
        Task<List<DayTripItem>> GetByRouteIdAsync(int routeId);
        Task<List<DayTripItem>> GetByPlaceIdAsync(int placeId);
        Task<DayTripItem?> GetByIdAsync(int id);
        Task<DayTripItem> AddAsync(DayTripItem item);
        Task<DayTripItem> UpdateAsync(DayTripItem item);
        Task<bool> DeleteAsync(int id);
        Task DeleteByDayTripIdAsync(int dayTripId);
    }
}
