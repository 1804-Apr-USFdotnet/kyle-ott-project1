using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data = Restaurant.Data;
using Restaurant.Data;

namespace Restaurant.Data
{
    public class LibHelper
    {
        //gets all restaurants
        public IEnumerable<Restaurant> GetRestaurants()
        {
            IEnumerable<Restaurant> result;
            using (var db = new RestaurantDBEntities())
            {
                var dataList = db.Restaurants.ToList();
                result = dataList.Select(x => DataToLibrary(x)).ToList();
            }
            return result;
        }
        //Gets all reviews
        public IEnumerable<Review> GetReviews()
        {
            IEnumerable<Review> result;
            using (var db = new RestaurantDBEntities())
            {
                var dataList = db.Reviews.ToList();
                result = dataList.Select(x => DataToLibraryRev(x)).ToList();
            }
            return result;
        }

        //add review to DB
        public void AddReview(Review item)
        {
            using (var db = new RestaurantDBEntities())
            {
                db.Reviews.Add(LibraryToDataRev(item));
                db.SaveChanges();
            }
        }
        //delete review from DB
        public void DeleteReview(Review item)
        {
            using (var db = new RestaurantDBEntities())
            {
                db.Reviews.Remove(db.Reviews.Find(item.ID));
                db.SaveChanges();
            }
        }
        //Delete restaurant from DB
        public void DeleteRestaurant(Restaurant item)
        {
            using (var db = new RestaurantDBEntities())
            {
                
                db.Restaurants.Remove(db.Restaurants.Find(item.ID));
                db.SaveChanges();
            }
        }
        //add restaurant to DB
        public void AddRestaurant(Restaurant item)
        {
            using (var db = new RestaurantDBEntities())
            {
                db.Restaurants.Add(LibraryToData(item));
                db.SaveChanges();
            }
        }
        //Edit a restaurant object
        public void EditRestaurant(Restaurant item)
        {
            using (var db = new RestaurantDBEntities())
            {
                Restaurant restaurant = new Restaurant();
                restaurant = db.Restaurants.Find(item.ID);
                restaurant.Name = item.Name;
                restaurant.FoodType = item.FoodType;
                restaurant.Address = item.Address;
                db.Entry(restaurant).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        //Edit a review object
        public void EditReview(Review item)
        {
            using (var db = new RestaurantDBEntities())
            {
                Review review = new Review();
                review = db.Reviews.Find(item.ID);
                review.Rating = item.Rating;
                review.CustName = item.CustName;
                db.Entry(review).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        // mapping

        public static Restaurant DataToLibrary(Data.Restaurant dataModel)
        {
            var libModel = new Restaurant()
            {
                ID = dataModel.ID,
                Name = dataModel.Name,
                FoodType = dataModel.FoodType,
                Address = dataModel.Address
            };
            return libModel;
        }
        public static Review DataToLibraryRev(Data.Review dataModel)
        {
            var libModel = new Review()
            {
                ID = dataModel.ID,
                Rating = dataModel.Rating,
                CustName = dataModel.CustName,
                RestID = dataModel.RestID
            };
            return libModel;
        }

        public static Data.Restaurant LibraryToData(Restaurant libModel)
        {
            var dataModel = new Data.Restaurant()
            {
                ID = libModel.ID,
                Name = libModel.Name,
                FoodType = libModel.FoodType,
                Address = libModel.Address
            };
            return dataModel;
        }

        public static Data.Review LibraryToDataRev(Review libModel)
        {
            var dataModel = new Data.Review()
            {
                ID = libModel.ID,
                Rating = libModel.Rating,
                CustName = libModel.CustName,
                RestID = libModel.RestID
            };
            return dataModel;
        }
    }
}
