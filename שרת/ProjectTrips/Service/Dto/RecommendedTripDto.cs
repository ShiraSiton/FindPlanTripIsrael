using Service.Dto.DayTrip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class RecommendedTripDto
    {
        public DayTripDto trip { get; set; }
        public int MatchPercentage { get; set; }
    }
}
