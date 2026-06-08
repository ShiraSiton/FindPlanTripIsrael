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
    public class ReviewRepository : IReviewRepository
    {
        private readonly IContext _context;
        public ReviewRepository(IContext context)
        {
            this._context = context;
        }

        public async Task<Review> AddAsync(Review item)
        {
            _context.Reviews.Add(item);
            await _context.save();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null)
                return false;
            _context.Reviews.Remove(item);
            await _context.save();
            return true;
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await BaseQuery().ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await BaseQuery().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Review> UpdateAsync(Review item)
        {
            _context.Reviews.Update(item);
            await _context.save();
            return item;
        }
        public async Task<bool> ExistsAsync(Review item)
        {
            return await _context.Reviews.AnyAsync(r =>
                    r.UserId == item.UserId &&
                    r.ContentType == item.ContentType &&
                    r.PlaceId == item.PlaceId &&
                    r.RouteId == item.RouteId &&
                    r.DayTripId == item.DayTripId);
        }
        public async Task<List<Review>> GetByContentAsync(ContentType type, int contentId)
        {
            return await _context.Reviews
                .Where(r => r.ContentType == type &&
                r.ContentType == ContentType.DayTrip? 
                r.DayTripId == contentId :
                r.ContentType == ContentType.Route ?
                r.RouteId == contentId : 
                r.PlaceId == contentId)
                .OrderByDescending(r => r.CreatedAt).ToListAsync();
        }
        private IQueryable<Review> BaseQuery()
        {
            return _context.Reviews
                    .Include(x => x.User);
        }
    }
}
