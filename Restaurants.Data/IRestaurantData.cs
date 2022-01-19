using System.Collections.Generic;
using System.Linq;
using Restaurants.Core;

namespace Restaurants.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant(){ Id=1, Name="Dominos", CuisineType = CuisineType.None, Location="FairFax" },
                new Restaurant(){ Id=2, Name="McDonalds", CuisineType = CuisineType.None, Location="Meryland" },
                new Restaurant(){ Id=3, Name="Subway", CuisineType = CuisineType.None, Location="FairFax" }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
