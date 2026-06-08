using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }
        public double DurationMinutes { get; set; }
        public double LengthKm { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
        [ForeignKey("Region")]
        public int? RegionId { get; set; }
        public Region? Region { get; set; }
        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }
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
        public bool HasCommonWeather { get; set; }
        public double? AverageRating { get; set; }
        public int? RatingsCount { get; set; }
        [ForeignKey("User")]
        public int CreatedByUserId { get; set; }
        public virtual User User { get; set; }
        public DateOnly CreatedAt { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateOnly? ApprovedAt { get; set; }
        public string? RejectReason { get; set; }
        public ICollection<DayTripItem> DayTripItems { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<RoutePoint> RoutePoints { get; set; }
    }
}
