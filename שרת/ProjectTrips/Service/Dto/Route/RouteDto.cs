using Repository.Entities;
using Service.Dto.Image;
using Service.Dto.Region;
using Service.Dto.RoutePoint;
using Service.Dto.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.Route
{
    public class RouteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EnumValueDto Difficulty { get; set; }
        public double DurationMinutes { get; set; }
        public double LengthKm { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
        public RegionDto? Region { get; set; }
        public TypeDto Type { get; set; }
        public EnumValueDto Accessibility { get; set; }
        public double Price { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }
        public double? MinTemperature { get; set; }
        public double? MaxTemperature { get; set; }
        public double? MaxWindSpeed { get; set; }
        public double? MaxRainProbability { get; set; }
        public double? MaxHumidity { get; set; }
        public double? MaxCloudCoverage { get; set; }
        public bool AllowRain { get; set; }
        public bool HasCommonWeather { get; set; }
        public double? AverageRating { get; set; }
        public int? RatingsCount { get; set; }
        public int CreatedByUserId { get; set; }
        public DateOnly CreatedAt { get; set; }
        public EnumValueDto ApprovalStatus { get; set; }
        public DateOnly? ApprovedAt { get; set; }
        public string? RejectReason { get; set; }
        public ICollection<ImageDto> Images { get; set; }
        public ICollection<RoutePointDto> RoutePoints { get; set; }
    }
}
