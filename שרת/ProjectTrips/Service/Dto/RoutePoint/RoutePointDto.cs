using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.RoutePoint
{
    public class RoutePointDto
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int OrderInRoute { get; set; }
        public string Title { get; set; }  
        public string Description { get; set; }  
        public double? EstimatedStayMinutes { get; set; }
        public bool IsStartPoint { get; set; }
        public bool IsEndPoint { get; set; }
    }
}
