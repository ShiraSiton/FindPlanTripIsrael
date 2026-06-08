using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class TripSearchRequestDto
    {
        public int? RegionId { get; set; }
        public int? TypeId { get; set; }
        public double? MaxPrice { get; set; }
        public double? AvailableHours { get; set; }
        public Difficulty? Difficulty { get; set; }
        public Accessibility? Accessibility { get; set; }
        public bool? IsRainyDay { get; set; }

        public int Count { get; set; } = 5;
    }
}
