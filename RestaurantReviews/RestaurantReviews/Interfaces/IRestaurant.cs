using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Interfaces
{
    public interface IRestaurant
    {
        int ID { get; set; }
        string Name { get; set; }
        string FoodType { get; set; }
        string Address { get; set; }
        int AverageRating { get; set; }
    }
}
