using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class DayTripItem
    {
        public int Id { get; set; }
        [ForeignKey("DayTrip")]
        public int DayTripId { get; set; }
        public virtual DayTrip DayTrip { get; set; }
        public ItemType ItemType { get; set; }
        [ForeignKey("Route")]
        public int? RouteId { get; set; }
        public virtual Route? Route { get; set; }
        [ForeignKey("Place")]
        public int? PlaceId { get; set; }
        public virtual Place? Place { get; set; }
        public int OrderInTrip { get; set; }
        public double EstimatedDuration { get; set; }
        public TravelMode? Mode { get; set; }
    }
}
