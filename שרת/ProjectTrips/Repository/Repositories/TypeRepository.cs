using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly IContext _context;

        public TypeRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<Repository.Entities.Type>> GetAllAsync()
        {
            return await _context.Types.ToListAsync();
        }

        public async Task<List<Repository.Entities.Type>> GetAllPlaceTypeAsync()
        {
            return await _context.Types.Where(t => t.ContentType == ContentType.Place).ToListAsync();
        }
        public async Task<List<Repository.Entities.Type>> GetAllRouteTypeAsync()
        {
            return await _context.Types.Where(t => t.ContentType == ContentType.Route).ToListAsync();
        }
        public async Task<List<Repository.Entities.Type>> GetAllDayTripTypeAsync()
        {
            return await _context.Types.Where(t => t.ContentType == ContentType.DayTrip).ToListAsync();
        }

        public async Task<Repository.Entities.Type?> GetByIdAsync(int id)
        {
            return await _context.Types
                .Include(t => t.Places)
                .Include(t => t.Routes)
                .Include(t => t.DayTrips)
                .FirstOrDefaultAsync(t => t.Id == id);
        }


        public async Task<Repository.Entities.Type?> GetByIdPlaceTypeAsync(int id)
        {
            return await _context.Types
                .Include(t => t.Places)
                .FirstOrDefaultAsync(t => t.ContentType == ContentType.Place && t.Id == id);
        }
        public async Task<Repository.Entities.Type?> GetByIdRouteTypeAsync(int id)
        {
            return await _context.Types
                .Include(t => t.Routes)
                .FirstOrDefaultAsync(t => t.ContentType == ContentType.Route && t.Id == id);
        }
        public async Task<Repository.Entities.Type?> GetByIdDayTripTypeAsync(int id)
        {
            return await _context.Types
                .Include(t => t.DayTrips)
                .FirstOrDefaultAsync(t => t.ContentType == ContentType.DayTrip && t.Id == id);
        }
        public async Task<Repository.Entities.Type> AddAsync(Repository.Entities.Type type)
        {
            await _context.Types.AddAsync(type);
            await _context.save();
            return type;
        }

        public async Task<Repository.Entities.Type> UpdateAsync(Repository.Entities.Type type)
        {
            _context.Types.Update(type);
            await _context.save();
            return type;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var type = await GetByIdAsync(id);
            if (type == null) 
                return false;
            _context.Types.Remove(type);
            await _context.save();
            return true;
        }
    }
}
