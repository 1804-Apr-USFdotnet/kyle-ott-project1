using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Interfaces;

namespace RestaurantReviews.Class
{
    public class Review : IReview
    {
        public int ID { get; set; }
        public int Rating { get; set; }
        public string CustName { get; set; }
        public int RestID { get; set; }
    }
}
