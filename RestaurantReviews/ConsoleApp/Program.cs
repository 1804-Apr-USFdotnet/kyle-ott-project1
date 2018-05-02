using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Model;
using NLog;

namespace ConsoleApp
{
    public class Program
    {
        //static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Serial ser = new Serial();
    
            Functions func = new Functions();
            var logger = NLog.LogManager.GetCurrentClassLogger();

            while (true)
            {
                Console.WriteLine(
@"

Please choose from the following options: 
1. Display all restaurants
2. Enter a restaurant name for their details
3. Enter a restaurant name for their reviews
4. Search for restaurants using any characters
5. Enter a restaurant name for their average rating
6. Show the top three restaurants based on ratings
0. To exit");
                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    func.DisplayAll();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Enter restaurant name: ");
                    string read = Console.ReadLine();
                    logger.Debug(read);
                    func.Details(read);
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Enter restaurant name: ");
                    string read = Console.ReadLine();
                    logger.Debug(read);
                    func.AllReviews(read);
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Enter any characters: ");
                    string read = Console.ReadLine();
                    logger.Debug(read);
                    func.SearchRestaurant(read);
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Enter restaurant name: ");
                    string read = Console.ReadLine();
                    logger.Debug(read);
                    func.GetAverageRating(read);
                }
                else if (choice == "6")
                {
                    func.GetTopThree();
                }
                else if (choice == "0")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("You entered an invalid key");
                }
            }
        }
    }
}
