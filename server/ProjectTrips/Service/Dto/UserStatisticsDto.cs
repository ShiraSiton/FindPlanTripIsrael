using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class UserStatisticsDto
    {
        public DateOnly JoinDate { get; set; }
        public int TripsCreated { get; set; }
        public int TripsViews { get; set; }
    }
}
