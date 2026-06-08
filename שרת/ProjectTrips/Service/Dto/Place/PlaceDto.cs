using Repository.Entities;
using Service.Dto.Image;
using Service.Dto.Region;
using Service.Dto.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.Place
{
    public class PlaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public TypeDto Type { get; set; }
        public RegionDto Region { get; set; }
        public EnumValueDto Accessibility { get; set; }
        public double Price { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }
        public int? AverageStayMinutes { get; set; }
        public double? AverageRating { get; set; }
        public int? RatingsCount { get; set; }
        public double? MinTemperature { get; set; }
        public double? MaxTemperature { get; set; }
        public double? MaxWindSpeed { get; set; }
        public double? MaxRainProbability { get; set; }
        public double? MaxHumidity { get; set; }
        public double? MaxCloudCoverage { get; set; }
        public bool AllowRain { get; set; } = true;
        public bool HasCommonWeather { get; set; }
        public int CreatedByUserId { get; set; }
        public DateOnly CreatedAt { get; set; }
        public EnumValueDto ApprovalStatus { get; set; }
        public DateOnly? ApprovedAt { get; set; }
        public string? RejectReason { get; set; }
        public ICollection<ImageDto> Images { get; set; }
    }
}
