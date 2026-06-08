using AutoMapper;
using Repository.Entities;
using Repository.Interfaces;
using Service.Dto.Review;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository repository;
        private readonly IPlaceRepository repositoryPlace;
        private readonly IRouteRepository repositoryRoute;
        private readonly IDayTripRepository repositoryDayTrip;
        private readonly IUserRepository repositoryUser;
        private readonly IMapper mapper;
        public ReviewService(IReviewRepository repository, IPlaceRepository repositoryPlace, IRouteRepository repositoryRoute, IDayTripRepository repositoryDayTrip, IUserRepository userRepository, IMapper mapper)
        {
            this.repository = repository;
            this.repositoryPlace = repositoryPlace;
            this.repositoryRoute = repositoryRoute;
            this.repositoryDayTrip = repositoryDayTrip;
            this.repositoryUser = userRepository;
            this.mapper = mapper;
        }
        public async Task<ReviewDto> CreateReviewAsync(ReviewCreateDto dto)
        {
            ValidateDto(dto);

            await ValidateContentTargetAync(dto);

            var user = await repositoryUser.GetByIdAsync(dto.UserId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            var review = mapper.Map<Review>(dto);

            var existingReview = await repository.ExistsAsync(review);
            if (existingReview)
                throw new InvalidOperationException($"This user has already commented on this {dto.ContentType}");

            review.Comment = dto.Comment.Trim();
            review.CreatedAt = DateOnly.FromDateTime(DateTime.Now);

            return mapper.Map<ReviewDto>(await repository.AddAsync(review));
        }
        private void ValidateDto(ReviewCreateDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.Comment))
                throw new ArgumentException("Comment cannot be empty");

            if (dto.Comment.Length > 1000)
                throw new ArgumentException("Comment too long");
        }
        private async Task ValidateContentTargetAync(ReviewCreateDto dto)
        {
            int count =
                (dto.PlaceId.HasValue ? 1 : 0) +
                (dto.RouteId.HasValue ? 1 : 0) +
                (dto.DayTripId.HasValue ? 1 : 0);

            if (count != 1)
                throw new ArgumentException("Review must reference exactly one content item");

            switch (dto.ContentType)
            {
                case ContentType.Place:

                    if (!dto.PlaceId.HasValue)
                        throw new ArgumentException("PlaceId required");

                    var place = await repositoryPlace.GetByIdAsync(dto.PlaceId.Value);
                    if (place == null)
                        throw new KeyNotFoundException("Place not found");

                    break;

                case ContentType.Route:

                    if (!dto.RouteId.HasValue)
                        throw new ArgumentException("RouteId required");

                    var route = await repositoryRoute.GetByIdAsync(dto.RouteId.Value);
                    if (route == null)
                        throw new KeyNotFoundException("Route not found");

                    break;

                case ContentType.DayTrip:

                    if (!dto.DayTripId.HasValue)
                        throw new ArgumentException("DayTripId required");

                    var trip = await repositoryDayTrip.GetByIdAsync(dto.DayTripId.Value);
                    if (trip == null)
                        throw new KeyNotFoundException("DayTrip not found");

                    break;

                default:
                    throw new ArgumentException("Invalid content type");
            }
        }
        public async Task<List<ReviewDto>> GetReviewsForPlaceAsync(int placeId)
        {
            var reviews = await repository.GetByContentAsync(ContentType.Place, placeId);

            return mapper.Map<List<ReviewDto>>(reviews);
        }
        public async Task<List<ReviewDto>> GetReviewsForRouteAsync(int routeId)
        {
            var reviews = await repository.GetByContentAsync(ContentType.Route, routeId);

            return mapper.Map<List<ReviewDto>>(reviews);
        }
        public async Task<List<ReviewDto>> GetReviewsForDayTripAsync(int dayTripId)
        {
            var reviews = await repository.GetByContentAsync(ContentType.DayTrip, dayTripId);

            return mapper.Map<List<ReviewDto>>(reviews);
        }
        public async Task<bool> DeleteReviewAsync(int userId, int reviewId)
        {
            var review = await repository.GetByIdAsync(reviewId);
            if (review == null)
                throw new KeyNotFoundException("Review not found");

            var user = await repositoryUser.GetByIdAsync(userId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            if (user.Id != review.UserId && user.Role != Role.Admin)
                throw new UnauthorizedAccessException("Only admin or creator can delete review");

            return await repository.DeleteAsync(reviewId);
        }
    }
}
