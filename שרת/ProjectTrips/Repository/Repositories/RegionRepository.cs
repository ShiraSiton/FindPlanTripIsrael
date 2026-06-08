using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly IContext _context;
        public RegionRepository(IContext context)
        {
            this._context = context;
        }

        public async Task<Region> AddAsync(Region item)
        {
            _context.Regions.Add(item);
            await _context.save();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null)
                return false;
            _context.Regions.Remove(item);
            await _context.save();
            return true;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(int id)
        {
            return await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsync(Region item)
        {
            _context.Regions.Update(item);
            await _context.save();
            return item;
        }
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Regions.AnyAsync(x => x.RegionName == name);
        }
        public async Task<bool> HasChildrenAsync(int parentId)
        {
            return await _context.Regions.AnyAsync(x => x.ParentRegionId == parentId);
        }
    }
}