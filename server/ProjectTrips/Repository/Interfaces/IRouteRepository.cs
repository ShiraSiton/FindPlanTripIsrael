using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRouteRepository
    {
        Task<List<Route>> GetAllAsync(); 
        Task<List<Route>> GetByIdsAsync(List<int> ids);
        Task<Route?> GetByIdAsync(int id);
        Task<Route> AddAsync(Route item);
        Task<Route> UpdateAsync(Route item);
        Task<bool> DeleteAsync(int id);
    }
}
