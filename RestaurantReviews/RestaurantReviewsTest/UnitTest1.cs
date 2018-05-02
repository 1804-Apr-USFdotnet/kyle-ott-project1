using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviews.Model;
using RestaurantReviews;

namespace RestaurantReviewsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLibHelper()
        {
            //arrange
            LibHelper libHelper = new LibHelper();
            String restName = "IHOP";
            String expected = "Diner";
            String actual = "";

            //act
            var results = libHelper.GetRestaurants();

            //assert
            foreach (var restaurant in results)
            {
                if (restaurant.Name == restName)
                {
                    actual = restaurant.FoodType;
                }
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
