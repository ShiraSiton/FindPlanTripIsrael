using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.Review
{
    public class ReviewCreateDto
    {
        public ContentType ContentType { get; set; }

        public int? PlaceId { get; set; }

        public int? RouteId { get; set; }

        public int? DayTripId { get; set; }

        public int UserId { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 2)]
        public string Comment { get; set; }
    }
}
