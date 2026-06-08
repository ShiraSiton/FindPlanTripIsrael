using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.RoutePoint
{
    public class RoutePointCreateDto
    {
        public int RouteId { get; set; }
        public int OrderInRoute { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double? EstimatedStayMinutes { get; set; }
        public bool IsStartPoint { get; set; }
        public bool IsEndPoint { get; set; }
    }
}
