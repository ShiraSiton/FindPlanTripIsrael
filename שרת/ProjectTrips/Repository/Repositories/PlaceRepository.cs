using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly IContext _context;
        public PlaceRepository(IContext context)
        {
            this._context = context;
        }

        public async Task<Place> AddAsync(Place item)
        {
            _context.Places.Add(item);
            await _context.save();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null)
                return false;
            _context.Places.Remove(item);
            await _context.save();
            return true;
        }

        public async Task<List<Place>> GetAllAsync()
        {
            return await BaseQuery().ToListAsync();
        }

        public async Task<Place?> GetByIdAsync(int id)
        {
            return await BaseQuery().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Place>> GetByIdsAsync(List<int> ids)
        {
            return await BaseQuery()
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();
        }

        public async Task<Place> UpdateAsync(Place item)
        {
            _context.Places.Update(item);
            await _context.save();
            return item;
        }

        private IQueryable<Place> BaseQuery()
        {
            return _context.Places
                    .Include(x => x.Type)
                    .Include(x => x.Region);
        }
    }
}