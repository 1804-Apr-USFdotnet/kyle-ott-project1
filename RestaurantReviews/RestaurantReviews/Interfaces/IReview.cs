using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Interfaces
{
    public interface IReview
    {
        int ID { get; set; }
        int Rating { get; set; }
        string CustName { get; set; }
        int RestID { get; set; }
    }
}
