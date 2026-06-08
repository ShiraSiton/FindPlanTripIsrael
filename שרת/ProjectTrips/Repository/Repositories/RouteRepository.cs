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
    public class RouteRepository : IRouteRepository
    {
        private readonly IContext _context;
        public RouteRepository(IContext context)
        {
            this._context = context;
        }

        public async Task<Route> AddAsync(Route item)
        {
            _context.Routes.Add(item);
            await _context.save();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null)
                return false;
            _context.Routes.Remove(item);
            await _context.save();
            return true;
        }

        public async Task<List<Route>> GetAllAsync()
        {
            return await BaseQuery().ToListAsync();
        }

        public async Task<List<Route>> GetByIdsAsync(List<int> ids)
        {
            return await BaseQuery()
                .Where(r => ids.Contains(r.Id))
                .ToListAsync();
        }

        public async Task<Route?> GetByIdAsync(int id)
        {
            return await BaseQuery().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Route> UpdateAsync(Route item)
        {
            _context.Routes.Update(item);
            await _context.save();
            return item;
        }

        private IQueryable<Route> BaseQuery()
        {
            return _context.Routes
                .Include(x => x.Type)
                .Include(x => x.Region);
        }
    }
}

