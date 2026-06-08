using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class DayTrip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double TotalDurationHours { get; set; }
        public double TotalLengthKM { get; set; }
        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }
        [ForeignKey("Region")]
        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }
        public Accessibility Accessibility { get; set; }
        public Difficulty Difficulty { get; set; }
        public double Price { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public double? MinTemperature { get; set; }
        public double? MaxTemperature { get; set; }    
        public double? MaxWindSpeed { get; set; }
        public double? MaxRainProbability { get; set; }
        public double? MaxHumidity { get; set; }
        public double? MaxCloudCoverage { get; set; }
        public bool AllowRain { get; set; } = true;
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
        public string TripHash { get; set; }
        public int NumberOfViews { get; set; }
        public ICollection<DayTripItem> DayTripItems { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
