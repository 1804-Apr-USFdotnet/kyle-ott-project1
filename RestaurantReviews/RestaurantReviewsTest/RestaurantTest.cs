using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviews.Model;
using RestaurantReviews;
using Restaurant.Web.Models;
using Restaurant.Web;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using RestaurantReviews.Web.Controllers;

namespace RestaurantReviewsTest
{
    [TestClass]
    public class RestaurantTest
    {
        [TestMethod]
        public void TestDisplayAllData()
        {
            //Arrange
            RestaurantController controller = new RestaurantController();
            //Act
            var result = controller.DisplayAll() as ViewResult;
            var data = result.Model as IEnumerable<Restaurant.Web.Models.Restaurant>;
            //Assert
            Assert.AreEqual("Sushi Avenue", data.ElementAt(2).Name);

        }

        [TestMethod]
        public void TestRestaurantDetails()
        {
            //Arrange
            RestaurantController controller = new RestaurantController();
            //Act
            var result = controller.Details(2) as ViewResult;
            var data = result.Model as Restaurant.Web.Models.Restaurant;
            //Assert
            Assert.AreEqual("3125 Cove Bend Dr, Tampa, FL", data.Address);

        }

        [TestMethod]
        public void TestAverageRating()
        {
            //Arrange
            RestaurantController controller = new RestaurantController();
            //Act
            var result = controller.AverageRating(4) as ViewResult;
            var data = result.Model as Restaurant.Web.Models.Restaurant;
            //Assert
            Assert.AreEqual(4, data.AverageRating);

        }

        [TestMethod]
        public void TestSearchByString()
        {
            //Arrange
            Restaurant.Web.Models.Restaurant restaurant = new Restaurant.Web.Models.Restaurant();
            //Act
            var result = restaurant.GetRestaurantByName("t");
            var data = result as IEnumerable<Restaurant.Web.Models.Restaurant>;
            //Assert
            Assert.AreEqual(2, data.Count());
        }
    }
}
