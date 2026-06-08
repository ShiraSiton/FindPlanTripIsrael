using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(int id);
        Task<Region> AddAsync(Region item);
        Task<Region> UpdateAsync(Region item);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
        Task<bool> HasChildrenAsync(int parentId);
    }
}
