using Service.Dto;
using Service.Dto.DayTrip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IGetBestTripsService
    {
        Task<List<RecommendedTripDto>> GetBestTripsAsync(TripSearchRequestDto request);
    }
}
