using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.Review
{
    public class ReviewDto
    {
        public int Id { get; set; }

        public ContentType ContentType { get; set; }

        public int? PlaceId { get; set; }

        public int? RouteId { get; set; }

        public int? DayTripId { get; set; }

        public int UserId { get; set; }

        public string Comment { get; set; }

        public DateOnly CreatedAt { get; set; }
    }
}
