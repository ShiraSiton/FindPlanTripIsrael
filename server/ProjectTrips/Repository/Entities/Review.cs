using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public ContentType ContentType { get; set; }
        [ForeignKey("Place")]
        public int? PlaceId { get; set; }
        public virtual Place? Place { get; set; }
        [ForeignKey("Route")]
        public int? RouteId { get; set; }
        public virtual Route? Route { get; set; }
        [ForeignKey("DayTrip")]
        public int? DayTripId { get; set; }
        public virtual DayTrip? DayTrip { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Comment { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
