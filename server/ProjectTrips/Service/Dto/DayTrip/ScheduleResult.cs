using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.DayTrip
{
    public class ScheduleResult
    {
        public TimeOnly EstimatedEndTime { get; set; }
        public List<string> Warnings { get; set; } = new();
    }
}
