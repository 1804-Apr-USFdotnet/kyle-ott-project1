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
    public class ReviewTest
    {
        [TestMethod]
        public void TestDisplayAllReviews()
        {
            //Arrange
            ReviewController controller = new ReviewController();
            //Act
            var result = controller.Reviews(5) as ViewResult;
            var data = result.Model as IEnumerable<Review>;
            //Assert
            Assert.AreEqual("Moriah", data.ElementAt(2).CustName);
        }

        [TestMethod]
        public void TestDetailsOfReview()
        {
            //Arrange
            ReviewController controller = new ReviewController();
            //Act
            var result = controller.Details(19) as ViewResult;
            var data = result.Model as Review;
            //Assert
            Assert.AreEqual("Paul", data.CustName);
        }
    }
}
