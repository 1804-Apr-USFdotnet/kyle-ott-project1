using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data = Restaurant.Data;
using Restaurant.Data;

namespace RestaurantReviews.Model
{
    public class LibHelper
    {
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


        public void AddRestaurant(Restaurant item)
        {
            using (var db = new RestaurantDBEntities())
            {
                db.Restaurants.Add(LibraryToData(item));
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
                Name = libModel.Name,
                FoodType = libModel.FoodType
            };
            return dataModel;
        }
    }
}
