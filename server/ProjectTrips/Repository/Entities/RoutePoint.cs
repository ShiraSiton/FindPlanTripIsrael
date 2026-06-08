using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class RoutePoint
    {
        public int Id { get; set; }
        [ForeignKey("Route")]
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
        public int OrderInRoute { get; set; }
        public string Title { get; set; }   // "ירידה בשביל האדום"
        public string Description { get; set; }  // פירוט מה רואים/עושים
        //public string? NavigationInstruction { get; set; }
        public double? EstimatedStayMinutes { get; set; }
        public bool IsStartPoint { get; set; }
        public bool IsEndPoint { get; set; }
        //public RoutePointType Type { get; set; }
    }
}
