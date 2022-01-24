using System;
using Microsoft.EntityFrameworkCore;
using Restaurants.Core;

namespace Restaurants.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}