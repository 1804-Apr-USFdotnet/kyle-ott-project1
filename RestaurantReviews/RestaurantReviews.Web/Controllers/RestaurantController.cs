using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Web.Models;

namespace RestaurantReviews.Web.Controllers
{
    public class RestaurantController : Controller
    {
        Restaurant.Web.Models.Restaurant restaurant = new Restaurant.Web.Models.Restaurant();


        public ActionResult Index()
        {
            return View();
        }

        //Search all restaurants for any string entered
        public ActionResult Search(FormCollection form)
        {
            return View(restaurant.GetRestaurantByName(form[0]));
        }

        //Shows all restaurants in DB
        public ActionResult DisplayAll()
        {
            return View(restaurant.GetRestaurants());
        }
        //gets average rating for a restaurant
        public ActionResult AverageRating(int id)
        {
            return View(restaurant.GetAverageRating(id));
        }
        // GET: Restaurant/Details
        public ActionResult Details(int id)
        {
            return View(restaurant.GetRestaurantById(id));
        }
        //Shows top three restaurants based on rating
        public ActionResult TopThree()
        {
            RestRevViewModel restRev = new RestRevViewModel();
            restRev.topThree = restaurant.GetTopThree();
            return View(restRev);
        }


        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(Restaurant.Web.Models.Restaurant restaurant)
        {
            try
            {
                // TODO: Add insert logic here
                restaurant.AddRestaurant(restaurant);
                return RedirectToAction("DisplayAll");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(Restaurant.Web.Models.Restaurant restaurant)
        {
            try
            {
                // TODO: Add update logic here
                restaurant.UpdateRestaurant(restaurant);
                return RedirectToAction("DisplayAll");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View(restaurant.GetRestaurantById(id));
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(Restaurant.Web.Models.Restaurant restaurant)
        {
            try
            {
                // TODO: Add delete logic here
                restaurant.DeleteRestaurant(restaurant);

                return View("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
