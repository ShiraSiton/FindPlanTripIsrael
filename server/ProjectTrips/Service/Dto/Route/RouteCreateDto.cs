using Repository.Entities;
using Service.Dto.RoutePoint;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.Route
{
    public class RouteCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double DurationMinutes { get; set; }
        public double LengthKm { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
        public int? RegionId { get; set; }
        public int TypeId { get; set; }
        public Accessibility Accessibility { get; set; }
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
        public int CreatedByUserId { get; set; }
        public bool SendForApproval { get; set; }
        public List<RoutePointCreateDto> Points { get; set; } = new();
    }
}
