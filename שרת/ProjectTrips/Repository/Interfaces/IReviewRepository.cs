using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllAsync();
        Task<Review?> GetByIdAsync(int id);
        Task<Review> AddAsync(Review item);
        Task<Review> UpdateAsync(Review item);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(Review item);
        Task<List<Review>> GetByContentAsync(ContentType type, int contentId);
    }
}