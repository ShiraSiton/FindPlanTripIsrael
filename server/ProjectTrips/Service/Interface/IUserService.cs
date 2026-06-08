using Service.Dto;
using Service.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> AddAsync(CreateUserDto dto);
        Task<UserDto> LoginAsync(LoginDto dto);
        Task<bool> SaveRefreshTokenAsync(int userId, string refreshToken);
        Task<UserDto> GetUserByRefreshTokenAsync(string refreshToken);
        Task<bool> DeleteUserAsync(int adminId, int id);
        Task<UserDto> UpdateProfileAsync(int userId, UpdateProfileDto dto);
        Task<UserDto> ChangePasswordAsync(int userId, ChangePasswordDto dto);
        Task<UserDto> ChangeRoleAsync(int adminId, int targetUserId, ChangeRoleDto dto);
        Task<bool> ReactivateUserAsync(int adminId, int userId);
        Task<UserStatisticsDto> GetUserStatisticsAsync(int userId);
    }
}
