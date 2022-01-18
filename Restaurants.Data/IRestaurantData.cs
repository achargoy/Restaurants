using System.Collections.Generic;
using System.Linq;
using Restaurants.Core;

namespace Restaurants.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
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

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
