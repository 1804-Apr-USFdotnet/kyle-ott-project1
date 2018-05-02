using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Interfaces;
using RestaurantReviews.Model;

namespace RestaurantReviews.Model
{
    public class Functions : IFunctions
    {
        LibHelper libHelper = new LibHelper();

        //gets the top three restaurants based on rating
        public void GetTopThree()
        {
            Dictionary<string, double> myDict = new Dictionary<string, double>();
            var results = libHelper.GetRestaurants();
            foreach (var restaurant in results)
            {
                myDict.Add(restaurant.Name, AverageRating(restaurant.Name));
            }
            var sortedDict = from entry in myDict orderby entry.Value ascending select entry;
            
            Console.WriteLine(sortedDict.ElementAt(sortedDict.Count() - 1) + ", " + sortedDict.ElementAt(sortedDict.Count() - 2) + ", " + sortedDict.ElementAt(sortedDict.Count() - 3));
        }

        //displays all restaurants
        public void DisplayAll()
        {
            var results = libHelper.GetRestaurants();
            foreach (var restaurant in results)
                Console.WriteLine(restaurant.Name);
        }

        //prints the details of a restaurant
        public void Details(string restName)
        {
            var results = libHelper.GetRestaurants();
            foreach (var restaurant in results)
            {
                if (restaurant.Name == restName)
                {
                    Console.WriteLine("Name: " + restaurant.Name + " Food Type: " + restaurant.FoodType + " Address: " + restaurant.Address);
                }
            }
        }

        //prints all the reviews of a restaurant
        public void AllReviews(string restName)
        {
            int restID = 0;
            var results = libHelper.GetRestaurants();
            var resultsRev = libHelper.GetReviews();
            foreach (var restaurant in results)
            {
                if (restaurant.Name == restName)
                {
                    restID = restaurant.ID;
                    foreach (var review in resultsRev)
                    {
                        if (review.RestID == restID)
                        {
                            Console.WriteLine("Customer Name: " + review.CustName + " Rating: " + review.Rating);
                        }
                    }
                }
            }
        }

        //searches all restaurants for any string
        public void SearchRestaurant(string restName)
        {
            var results = libHelper.GetRestaurants();
            foreach (var restaurant in results)
            {
                if (restaurant.Name.Contains(restName))
                {
                    Console.WriteLine("Found: " + restaurant.Name);
                }
            }
        }

        //prints the average rating
        public void GetAverageRating(string restName)
        {
            int restID = 0;
            int result = 0;
            double result2 = 0;
            var results = libHelper.GetRestaurants();
            var resultsRev = libHelper.GetReviews();
            foreach (var restaurant in results)
            {
                if (restaurant.Name == restName)
                {
                    restID = restaurant.ID;
                    foreach (var review in resultsRev)
                    {
                        if (review.RestID == restID)
                        {
                            result += review.Rating;
                        }
                    }
                }
            }
            result2 = (double)result / 3;
            Console.WriteLine("Average Review: " + result2);
        }

        // help with getting top 3
        public double AverageRating(string restName)
        {
            int restID = 0;
            int result = 0;
            double result2 = 0;
            var results = libHelper.GetRestaurants();
            var resultsRev = libHelper.GetReviews();
            foreach (var restaurant in results)
            {
                if (restaurant.Name == restName)
                {
                    restID = restaurant.ID;
                    foreach (var review in resultsRev)
                    {
                        if (review.RestID == restID)
                        {
                            result += review.Rating;
                        }
                    }
                }
            }
            result2 = (double)result / 3;
            return result2;
        }
    }
}
