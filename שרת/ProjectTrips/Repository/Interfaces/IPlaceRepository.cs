using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPlaceRepository
    {
        Task<List<Place>> GetAllAsync();
        Task<List<Place>> GetByIdsAsync(List<int> ids);
        Task<Place?> GetByIdAsync(int id);
        Task<Place> AddAsync(Place item);
        Task<Place> UpdateAsync(Place item);
        Task<bool> DeleteAsync(int id);
    }
}
