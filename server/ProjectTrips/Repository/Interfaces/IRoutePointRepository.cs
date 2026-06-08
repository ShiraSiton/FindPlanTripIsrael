using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRoutePointRepository
    {
        Task<List<RoutePoint>> GetAllAsync();
        Task<List<RoutePoint>> GetByRouteIdAsync(int routeId);
        Task<RoutePoint?> GetByIdAsync(int id);
        Task<RoutePoint> AddAsync(RoutePoint item);
        Task<RoutePoint> UpdateAsync(RoutePoint item);
        Task UpdateRangeAsync(IEnumerable<RoutePoint> entities);
        Task<bool> DeleteAsync(int id);
        Task DeleteByRouteIdAsync(int routeId);
    }
}
