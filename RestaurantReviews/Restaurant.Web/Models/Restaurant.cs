using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Restaurant.Data;

namespace Restaurant.Web.Models
{
    public class RestRevViewModel
    {
        public Reviews reviews { get; set; }
        public Restaurant restaurant { get; set; }

    }
    public class Reviews
    {
        public int Id { get; set; }
        public Restaurant Restaurant { get; set; }
    }
    public class Restaurant
    {
        private RestContext _db = new RestContext();

        public int ID { get; set; }
        public string Name { get; set; }
        public string FoodType { get; set; }
        public string Address { get; set; }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            var rests = _db.Restaurants.ToList();
            var result = rests.Select(x => ToWeb(x));
            return result;
        }
        public Restaurant GetRestaurantById(int id)
        {
            return ToWeb(_db.Restaurants.Where(x => x.ID == id).FirstOrDefault());
        }
        public void AddRestaurant(Restaurant restaurant)
        {
            _db.Restaurants.Add(ToData(restaurant));
            _db.SaveChanges();
            Debug.Write("Added 1 Restaurant");
        }
        public void UpdateRestaurant(int id, String updateStr)
        {
            var rest = ToWeb(_db.Restaurants.Where(x => x.ID == id).FirstOrDefault());
            rest.Name = updateStr;
            _db.SaveChanges();

        }
        
        public static Restaurant ToWeb(Data.Restaurant dataRestaurant)
        {
            var webRestaurant = new Restaurant()
            {
                ID = dataRestaurant.ID,
                Name = dataRestaurant.Name,
                FoodType = dataRestaurant.FoodType,
                Address = dataRestaurant.Address
            };
            return webRestaurant;
        }
        public static Data.Restaurant ToData(Restaurant webRestaurant)
        {
            var dataRestaurant = new Data.Restaurant()
            {
                ID = webRestaurant.ID,
                Name = webRestaurant.Name,
                FoodType = webRestaurant.FoodType,
                Address = webRestaurant.Address,
            };
            return dataRestaurant;
        }
    }
}
