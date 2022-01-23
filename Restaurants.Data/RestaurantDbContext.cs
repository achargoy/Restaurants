using System;
using Microsoft.EntityFrameworkCore;
using Restaurants.Core;

namespace Restaurants.Data
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
