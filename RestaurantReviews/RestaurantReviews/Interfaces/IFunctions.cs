using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Interfaces
{
    interface IFunctions
    {
        void GetTopThree();
        void DisplayAll();
        void Details(String restName);
        void AllReviews(String RestName);
        void SearchRestaurant(String restName);
        void GetAverageRating(String restName);
    }
}
