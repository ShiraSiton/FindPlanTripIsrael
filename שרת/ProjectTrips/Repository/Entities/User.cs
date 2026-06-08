using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public DateOnly CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public DateTime RefreshTokenCreated { get; set; }
        public bool RefreshTokenRevoked { get; set; }
        public ICollection<DayTrip> DayTrips { get; set; }
        public ICollection<Place> Places { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Route> Routes { get; set; }
    }
}
