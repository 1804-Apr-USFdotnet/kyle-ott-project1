using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Restaurant.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models
{
    //helper to display topThree
    public class RestRevViewModel
    {
        [Key]
        public int ID { get; set; }
        public String topThree { get; set; }
        //public Reviews reviews { get; set; }
        //public Restaurant restaurant { get; set; }

    }
    public class Reviews
    {
        public int ID { get; set; }
        public int Rating { get; set; }
        public string CustName { get; set; }
        public int RestID { get; set; }
    }
    public class Restaurant
    {
        //private RestContext _db = new RestContext();
        private LibHelper _db = new LibHelper();

        public int ID { get; set; }
        public string Name { get; set; }
        public string FoodType { get; set; }
        public string Address { get; set; }
        public double AverageRating { get; set; }
        //return all restaurants and make a list
        public IEnumerable<Restaurant> GetRestaurants()
        {
            
            var rests = _db.GetRestaurants().ToList();
            var result = rests.Select(x => ToWeb(x));
            return result;
        }
        //return one restaurant from ID
        public Restaurant GetRestaurantById(int id)
        {
            return ToWeb(_db.GetRestaurants().Where(x => x.ID == id).FirstOrDefault());
        }
        //returns all restaurants containing the string passed
        public IEnumerable<Restaurant> GetRestaurantByName(String id)
        {
            var results = _db.GetRestaurants().ToList();
            var result = results.Select(x => ToWeb(x));
            List<Restaurant> match = new List<Restaurant>();
            foreach (var rest in result)
            {
                if (rest.Name.Contains(id))
                {
                    match.Add(rest);
                }
            }
            var resultAll = match.Select(x => x);
            return resultAll;
        }
        //add restaurant to DB
        public void AddRestaurant(Restaurant restaurant)
        {
            _db.AddRestaurant(ToData(restaurant));
            //_db.SaveChanges();
            Debug.Write("Added 1 Restaurant");
        }
        //delete restaurant from DB
        public void DeleteRestaurant(Restaurant restaurant)
        {
            _db.DeleteRestaurant(ToData(restaurant));
            //_db.SaveChanges();
            Debug.Write("Deleted 1 Restaurant");
        }
        //edit a restaurant in DB
        public void UpdateRestaurant(Restaurant restaurant)
        {
            _db.EditRestaurant(ToData(restaurant));
            //_db.SaveChanges();

        }
        //get the average rating of a restaurant
        public Restaurant GetAverageRating(int id)
        {
            Restaurant restaurant = new Restaurant();
            Review review = new Review();
            double result2 = 0;
            double result = 0;
            restaurant = GetRestaurantById(id);
            var rev = review.GetReviewsById(restaurant.ID);
            foreach (var revIn in rev)
            {
                if (revIn.RestID == id)
                {
                    result += revIn.Rating;
                }
            }
            result2 = result / rev.Count();
            restaurant.AverageRating = result2;
            return restaurant;
        }
        //gets the top three restaurants based on rating
        public String GetTopThree()
        {
            RestRevViewModel rev = new RestRevViewModel();
            Dictionary<string, double> myDict = new Dictionary<string, double>();
            
            var results = GetRestaurants();
            foreach (var restaurant in results)
            {
                var avg = restaurant.GetAverageRating(restaurant.ID);

                myDict.Add(restaurant.Name, avg.AverageRating);
            }
            var sortedDict = from entry in myDict orderby entry.Value ascending select entry;

            return (sortedDict.ElementAt(sortedDict.Count() - 1).ToString() + ", " + sortedDict.ElementAt(sortedDict.Count() - 2).ToString() + ", " + sortedDict.ElementAt(sortedDict.Count() - 3).ToString());
            
        }

        //mapping
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

        public static Review ToWebRev(Data.Review dataRestaurant)
        {
            var webReview = new Review()
            {
                ID = dataRestaurant.ID,
                Rating = dataRestaurant.Rating,
                CustName = dataRestaurant.CustName,
                RestID = dataRestaurant.RestID.GetValueOrDefault()
            };
            return webReview;
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
        public static Data.Review ToDataRev(Review webRestaurant)
        {
            var dataRestaurant = new Data.Review()
            {
                ID = webRestaurant.ID,
                Rating = webRestaurant.Rating,
                CustName = webRestaurant.CustName,
                RestID = webRestaurant.RestID
            };
            return dataRestaurant;
        }
    }
}
