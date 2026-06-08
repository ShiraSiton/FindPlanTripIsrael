using Repository.Entities;
using Service.Dto.Place;
using Service.Dto.Route;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.DayTripItem
{
    public class DayTripItemDto
    {
        public int Id { get; set; }
        public int DayTripId { get; set; }
        public ItemType ItemType { get; set; }
        public RouteDto? Route { get; set; }
        public PlaceDto? Place { get; set; }
        public int OrderInTrip { get; set; }
        public int EstimatedDuration { get; set; }
        public TravelMode? Mode { get; set; }
    }
}
