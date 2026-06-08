using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDayTripRepository
    {
        Task<List<DayTrip>> GetAllAsync();
        Task<List<DayTrip>> GetTopThreeOrderByNumberOfViewsAsync();
        IQueryable<DayTrip> GetFilteredDayTrips();
        Task<DayTrip?> GetByIdAsync(int id);
        Task<List<DayTrip>> GetByUserIdAsync(int userId);
        Task<DayTrip> AddAsync(DayTrip item);
        Task<DayTrip> UpdateAsync(DayTrip item);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsByHashAsync(int currentTripId, string hash);

        Task<List<DayTrip>> GetFilteredTripsAsync();
    }
}
