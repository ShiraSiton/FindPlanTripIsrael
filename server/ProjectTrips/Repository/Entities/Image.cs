using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public ItemType ItemType { get; set; }
        [ForeignKey("Route")]
        public int? RouteId { get; set; }
        public virtual Route? Route { get; set; }
        [ForeignKey("Place")]
        public int? PlaceId { get; set; }
        public virtual Place? Place { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        [ForeignKey ("User")]
        public int CreatedByUserId { get; set; }
        public virtual User User { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
