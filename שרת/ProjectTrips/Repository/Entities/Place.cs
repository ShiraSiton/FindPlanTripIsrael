using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{ 
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }
        [ForeignKey("Region")]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
        public Accessibility Accessibility {  get; set; }
        public double Price { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }
        public int? AverageStayMinutes { get; set; }
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
        public ICollection<Image> Images { get; set; }
        public ICollection<Review> Reviews { get; set; }
        
        // ==========================
        // ✅ שדות מזג אוויר עתידיים
        // ==========================

        // טמפרטורה במעלות צלזיוס
        public double? MinTemperature { get; set; }    // טמפ' מינימום שהמקום מתאים לה
        public double? MaxTemperature { get; set; }    // טמפ' מקסימום שהמקום מתאים לה

        // מהירות רוח מקסימלית (בקמ"ש או מטר/שנייה)
        public double? MaxWindSpeed { get; set; }

        // אחוז גשם מקסימלי שהמקום מתאים לו (0-100)
        public double? MaxRainProbability { get; set; }

        // לחות מקסימלית שהמקום מתאים לה (אופציונלי)
        public double? MaxHumidity { get; set; }

        // עננות (אופציונלי, אחוז 0-100)
        public double? MaxCloudCoverage { get; set; }

        // האם המקום סובל גשם בכלל
        public bool AllowRain { get; set; } = true;

        public bool HasCommonWeather { get; set; }
    }
}
