using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.DayTrip
{
    public class ComputedDayTripFields
    {
        public int? RegionId { get; set; }
        public double TotalDurationHours { get; set; }
        public double TotalLengthKM { get; set; }
        public double Price { get; set; }
        public Accessibility Accessibility { get; set; }
        public TimeOnly EndTime { get; set; }
        public Difficulty Difficulty { get; set; }
        public double? MinTemperature { get; set; }
        public double? MaxTemperature { get; set; }
        public double? MaxWindSpeed { get; set; }
        public double? MaxRainProbability { get; set; }
        public double? MaxHumidity { get; set; }
        public double? MaxCloudCoverage { get; set; }
        public bool AllowRain { get; set; }
        public bool HasCommonWeather { get; set; }
        public ScheduleResult ScheduleResult { get; set; }
    }
}
