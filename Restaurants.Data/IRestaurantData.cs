using System.Collections.Generic;
using System.Linq;
using Restaurants.Core;

namespace Restaurants.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int Id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
        Restaurant Add(Restaurant newRestaurant);
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

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == updatedRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.CuisineType = updatedRestaurant.CuisineType;
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant GetById(int Id)
        {
            return restaurants.FirstOrDefault(r => r.Id == Id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Count + 1;
            return newRestaurant;
        }
    }
}
