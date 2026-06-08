using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITypeRepository
    {
        Task<List<Repository.Entities.Type>> GetAllAsync();
        Task<List<Repository.Entities.Type>> GetAllPlaceTypeAsync();
        Task<List<Repository.Entities.Type>> GetAllRouteTypeAsync();
        Task<List<Repository.Entities.Type>> GetAllDayTripTypeAsync();
        Task<Repository.Entities.Type?> GetByIdAsync(int id);
        Task<Repository.Entities.Type?> GetByIdPlaceTypeAsync(int id);
        Task<Repository.Entities.Type?> GetByIdRouteTypeAsync(int id);
        Task<Repository.Entities.Type?> GetByIdDayTripTypeAsync(int id);
        Task<Repository.Entities.Type> AddAsync(Repository.Entities.Type type);
        Task<Repository.Entities.Type> UpdateAsync(Repository.Entities.Type type);
        Task<bool> DeleteAsync(int id);
    }
}
