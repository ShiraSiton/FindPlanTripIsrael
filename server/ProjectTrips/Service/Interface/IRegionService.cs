using Service.Dto.Region;
using Service.Dto.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRegionService
    {
        Task<List<RegionDto>> GetAllAsync();
        Task<RegionDto> GetByIdAsync(int id);
        Task<RegionDto> AddAsync(RegionCreateUpdateDto dto);
        Task<RegionDto> UpdateAsync(int adminId, int id, RegionCreateUpdateDto dto);
        Task<bool> DeleteAsync(int adminId, int id);
    }
}
