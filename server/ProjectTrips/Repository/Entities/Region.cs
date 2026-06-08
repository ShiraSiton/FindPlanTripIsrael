using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string RegionName { get; set; }
        public int? ParentRegionId { get; set; }
        public Region? ParentRegion { get; set; }
        public ICollection<Region> SubRegions { get; set; } = new List<Region>();
        public ICollection<DayTrip> DayTrips { get; set; }
        public ICollection<Route> Routes { get; set; }
        public ICollection<Place> Places { get; set; }
    }
}
