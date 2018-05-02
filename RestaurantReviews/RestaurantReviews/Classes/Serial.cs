using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RestaurantReviews.Model
{
    public class Serial
    {
        Restaurant rest = new Restaurant();
        
        public void main()
        {
            StreamWriter sw = new StreamWriter(@"C:\revature\ott-kyle-project0\RestaurantReviews\Serialization.txt");
            rest.ID = 5;
            rest.Name = "IHOP";
            rest.Address = "34543 Main St";
            rest.AverageRating = 4;

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(rest.GetType());
            x.Serialize(sw, rest);
            sw.Close();
            Restaurant restOut = (Restaurant)x.Deserialize(new StreamReader(@"C:\revature\ott-kyle-project0\RestaurantReviews\Serialization.txt"));
            Console.WriteLine(restOut.Name);
        }
    }
}
