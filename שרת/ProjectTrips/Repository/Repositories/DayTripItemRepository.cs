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
    public class DayTripItemRepository : IDayTripItemRepository
    {
        private readonly IContext _context;
        public DayTripItemRepository(IContext context)
        {
            this._context = context;
        }

        public async Task<DayTripItem> AddAsync(DayTripItem item)
        {
            _context.DayTripItems.Add(item);
            await _context.save();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null)
                return false;
            _context.DayTripItems.Remove(item);
            await _context.save();
            return true;
        }

        public async Task<List<DayTripItem>> GetAllAsync()
        {
            return await BaseQuery().ToListAsync();
        }

        public async Task<List<DayTripItem>> GetByDayTripIdAsync(int dayTripId)
        {
            return await BaseQuery()
                .Where(rp => rp.DayTripId == dayTripId)
                .OrderBy(rp => rp.OrderInTrip)
                .ToListAsync();
        }

        public async Task<List<DayTripItem>> GetByRouteIdAsync(int routeId)
        {
            return await BaseQuery()
                .Where(dti => dti.RouteId == routeId)
                .ToListAsync();
        }
        public async Task<List<DayTripItem>> GetByPlaceIdAsync(int placeId)
        {
            return await BaseQuery()
                .Where(dti => dti.PlaceId == placeId)
                .ToListAsync();
        }

        public async Task<DayTripItem?> GetByIdAsync(int id)
        {
            return await BaseQuery().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DayTripItem> UpdateAsync(DayTripItem item)
        {
            _context.DayTripItems.Update(item);
            await _context.save();
            return item;
        }

        public async Task DeleteByDayTripIdAsync(int dayTripId)
        {
            var items = await _context.DayTripItems
                .Where(x => x.DayTripId == dayTripId)
                .ToListAsync();

            _context.DayTripItems.RemoveRange(items);

            await _context.save();
        }

        private IQueryable<DayTripItem> BaseQuery()
        {
            return _context.DayTripItems
                    .Include(i => i.Place)
                    .Include(i => i.Route);
        }
    }
}

