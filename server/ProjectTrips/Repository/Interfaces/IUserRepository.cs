using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<DateOnly> GetCreateAtByUserIdAsync(int userId);
        Task<User?> GetByRefreshTokenAsync(string refreshToken);
        Task<User> AddAsync(User item);
        Task<User> UpdateAsync(User item);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsByEmailAsync(int userId, string email);
    }
}
