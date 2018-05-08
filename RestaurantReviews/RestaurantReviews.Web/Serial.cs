using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Restaurant.Data;

namespace RestaurantReviews.Web.Model
{
    public class Serial
    {
        Restaurant.Web.Models.Restaurant rest = new Restaurant.Web.Models.Restaurant();
        
        public void main()
        {
            StreamWriter sw = new StreamWriter(@"C:\revature\ott-kyle-project1\RestaurantReviews\Serialization.txt");
            rest.ID = 5;
            rest.Name = "IHOP";
            rest.Address = "34543 Main St";
            rest.AverageRating = 4;

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(rest.GetType());
            x.Serialize(sw, rest);
            sw.Close();
            Restaurant.Web.Models.Restaurant restOut = (Restaurant.Web.Models.Restaurant)x.Deserialize(new StreamReader(@"C:\revature\ott-kyle-project1\RestaurantReviews\Serialization.txt"));
            Console.WriteLine(restOut.Name);
        }
    }
}
