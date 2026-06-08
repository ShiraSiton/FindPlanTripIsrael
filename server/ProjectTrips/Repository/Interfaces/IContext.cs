using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IContext
    {
        public DbSet<DayTrip> DayTrips { get; }
        public DbSet<DayTripItem> DayTripItems { get; }
        public DbSet<Place> Places { get; }  
        public DbSet<Image> Images { get; }  
        public DbSet<Region> Regions { get; } 
        public DbSet<Review> Reviews { get; } 
        public DbSet<Route> Routes { get; }  
        public DbSet<RoutePoint> RoutePoints { get; } 
        public DbSet<Repository.Entities.Type> Types { get; }  
        public DbSet<User> Users { get; }
        public Task save();
    }
}
