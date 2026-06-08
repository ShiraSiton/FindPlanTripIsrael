using Service.Dto.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IReviewService
    {
        Task<ReviewDto> CreateReviewAsync(ReviewCreateDto dto);
        Task<List<ReviewDto>> GetReviewsForPlaceAsync(int placeId);
        Task<List<ReviewDto>> GetReviewsForRouteAsync(int routeId);
        Task<List<ReviewDto>> GetReviewsForDayTripAsync(int dayTripId);
        Task<bool> DeleteReviewAsync(int userId, int reviewId);
    }
}
