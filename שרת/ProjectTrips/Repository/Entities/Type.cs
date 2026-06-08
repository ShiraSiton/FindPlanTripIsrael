using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Type
    {
        public int Id { get; set; }
        public ContentType ContentType { get; set; }
        public string TypeName { get; set; }
        public ICollection<Place> Places { get; set; }
        public ICollection<Route> Routes { get; set; }
        public ICollection<DayTrip> DayTrips { get; set; }
    }
}
