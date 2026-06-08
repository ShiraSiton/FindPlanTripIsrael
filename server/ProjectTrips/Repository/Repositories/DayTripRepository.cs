using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class DayTripRepository : IDayTripRepository
    {
        private readonly IContext _context;
        public DayTripRepository(IContext context)
        {
            this._context = context;
        }
        public async Task<DayTrip> AddAsync(DayTrip item)
        {
            _context.DayTrips.Add(item);
            await _context.save();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null)
                return false;
            _context.DayTrips.Remove(item);
            await _context.save();
            return true;
        }

        public async Task<List<DayTrip>> GetAllAsync()
        {
            return await BaseQuery().ToListAsync();
        }

        public async Task<List<DayTrip>> GetTopThreeOrderByNumberOfViewsAsync()
        {
            return await BaseQuery()
                //.Where(d => d.ApprovalStatus == ApprovalStatus.Approved)
                .OrderByDescending(d => d.NumberOfViews)
                .Take(3)
                .ToListAsync();
        }

        public IQueryable<DayTrip> GetFilteredDayTrips()
        {
            return BaseQuery()
                .Include(d => d.User)
                //.Where(d => d.ApprovalStatus == ApprovalStatus.Approved)
                .AsQueryable();
        }

        public async Task<DayTrip?> GetByIdAsync(int id)
        {
            return await BaseQuery()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DayTrip> UpdateAsync(DayTrip item)
        {
            _context.DayTrips.Update(item);
            await _context.save();
            return item;
        }

        public async Task<bool> ExistsByHashAsync(int currentTripId, string hash)
        {
            return await _context.DayTrips.AnyAsync(t => t.Id != currentTripId && t.TripHash == hash);
        }

        public async Task<List<DayTrip>> GetByUserIdAsync(int userId)
        {
            return await _context.DayTrips.Where(t => t.CreatedByUserId == userId).ToListAsync();
        }

        private IQueryable<DayTrip> BaseQuery()
        {
            return _context.DayTrips
                .Include(x => x.Reviews)
                .Include(x => x.Type)
                .Include(x => x.Region)
                .Include(x => x.DayTripItems)
                    .ThenInclude(i => i.Place)
                        .ThenInclude(j => j.Images)
                .Include(x => x.DayTripItems)
                    .ThenInclude(i => i.Route)
                        .ThenInclude(j => j.Images)
                .Include(x => x.DayTripItems)
                    .ThenInclude(i => i.Route)
                        .ThenInclude(j => j.RoutePoints);
        }


        public async Task<List<DayTrip>> GetFilteredTripsAsync()
        {
            return await _context.DayTrips
                .Include(t => t.Region)
                .Include(t => t.Type)
                .Include(t => t.DayTripItems)
                .ToListAsync();
        }
    }
}