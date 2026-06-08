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
    public class RoutePointRepository : IRoutePointRepository
    {
        private readonly IContext _context;
        public RoutePointRepository(IContext context)
        {
            this._context = context;
        }

        public async Task<RoutePoint> AddAsync(RoutePoint item)
        {
            _context.RoutePoints.Add(item);
            await _context.save();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null)
                return false;
            _context.RoutePoints.Remove(item);
            await _context.save();
            return true;
        }
        
        public async Task DeleteByRouteIdAsync(int routeId)
        {
            var items = await _context.RoutePoints
                .Where(x => x.RouteId == routeId)
                .ToListAsync();

            _context.RoutePoints.RemoveRange(items);

            await _context.save();
        }

        public async Task<List<RoutePoint>> GetAllAsync()
        {
            return await _context.RoutePoints.ToListAsync();
        }

        public async Task<List<RoutePoint>> GetByRouteIdAsync(int routeId)
        {
            return await _context.RoutePoints
                .Where(rp => rp.RouteId == routeId)
                .OrderBy(rp => rp.OrderInRoute)
                .ToListAsync();
        }
        public async Task<RoutePoint?> GetByIdAsync(int id)
        {
            return await _context.RoutePoints.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<RoutePoint> UpdateAsync(RoutePoint item)
        {
            _context.RoutePoints.Update(item);
            await _context.save();
            return item;
        }

        public async Task UpdateRangeAsync(IEnumerable<RoutePoint> entities)
        {
            _context.RoutePoints.UpdateRange(entities);
            await _context.save();
        }
    }
}