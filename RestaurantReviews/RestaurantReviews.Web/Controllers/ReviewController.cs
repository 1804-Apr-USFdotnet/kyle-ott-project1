using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Web.Models;

namespace RestaurantReviews.Web.Controllers
{
    public class ReviewController : Controller
    {
        //Restaurant.Web.Models.Reviews reviews = new Restaurant.Web.Models.Reviews();
        Restaurant.Web.Models.Review reviews = new Review();
        Review review = new Review();


        //gets all reviews based on restaurants ID
        public ActionResult Reviews(int id)
        {
            return View(review.GetReviewsById(id));
        }
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            return View(review.GetReviewById(id));
        }

        // GET: Review/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(Review review)
        {
            try
            {
                // TODO: Add insert logic here
                review.AddReview(review);
                return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(Review review)
        {
            try
            {
                // TODO: Add update logic here
                review.UpdateReview(review);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            return View(review.GetReviewById(id));
        }

        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult Delete(Review review)
        {
            try
            {
                // TODO: Add delete logic here
                review.DeleteReview(review);

                return View("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
