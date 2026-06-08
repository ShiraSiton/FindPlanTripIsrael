using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.DayTripItem
{
    public class DayTripItemToAdd
    {
        public ItemType ItemType { get; set; }
        public int? RouteId { get; set; }
        public int? PlaceId { get; set; }
        public TravelMode? Mode { get; set; }
    }
}
