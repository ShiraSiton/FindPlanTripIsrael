using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.Place
{
    public class UpdateProfilePlaceDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int TypeId { get; set; }
        public int RegionId { get; set; }
        public Accessibility Accessibility { get; set; }
        public double Price { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }
        public int? AverageStayMinutes { get; set; }
        public double? MinTemperature { get; set; }
        public double? MaxTemperature { get; set; }
        public double? MaxWindSpeed { get; set; }
        public double? MaxRainProbability { get; set; }
        public double? MaxHumidity { get; set; }
        public double? MaxCloudCoverage { get; set; }
        public bool AllowRain { get; set; } = true;
    }
}
