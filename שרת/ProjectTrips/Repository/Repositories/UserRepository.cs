using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IContext _context;
        public UserRepository(IContext context)
        {
            this._context = context;
        }

        public async Task<User> AddAsync(User item)
        {
            _context.Users.Add(item);
            await _context.save();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null)
                return false;
            _context.Users.Remove(item);
            await _context.save();
            return true;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(t => t.Email == email);
        }
        public async Task<DateOnly> GetCreateAtByUserIdAsync(int userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.CreatedAt)
                .FirstAsync();
        }

        public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        }

        public async Task<User> UpdateAsync(User item)
        {
            _context.Users.Update(item);
            await _context.save();
            return item;
        }

        public async Task<bool> ExistsByEmailAsync(int userId, string email)
        {
            return await _context.Users
                .AnyAsync(t => t.Email == email && t.Id != userId);
        }
    }
}