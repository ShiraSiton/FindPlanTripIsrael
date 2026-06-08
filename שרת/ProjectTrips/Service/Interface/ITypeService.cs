using Service.Dto.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITypeService
    {
        Task<List<TypeDto>> GetAllTypesAsync();
        Task<List<TypeDto>> GetAllDayTripTypesAsync();
        Task<List<TypeDto>> GetAllPlaceTypesAsync();
        Task<List<TypeDto>> GetAllRouteTypesAsync();
        Task<TypeDto> GetTypeByIdAsync(int id);
        Task<TypeDto> CreateTypeAsync(TypeCreateUpdateDto type);
        Task<TypeDto> UpdateTypeAsync(int adminId, int id, TypeCreateUpdateDto type);
        Task<bool> DeleteTypeAsync(int adminId, int id);
    }
}
