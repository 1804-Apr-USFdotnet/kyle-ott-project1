using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Interfaces;

namespace RestaurantReviews
{
    public class Restaurant : IRestaurant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FoodType { get; set; }
        public string Address { get; set; }
        public int AverageRating { get; set; }

    }
}
