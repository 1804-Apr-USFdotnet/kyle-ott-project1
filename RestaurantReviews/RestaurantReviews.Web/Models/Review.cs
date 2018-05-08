using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Restaurant.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models
{
    public class Review
    {
        private LibHelper _db = new LibHelper();
        [Required(ErrorMessage = "ID is required.")]
        [RegularExpression(@"[0-9]", ErrorMessage = "Invalid ID Value")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Rating is required.")]
        [RegularExpression(@"[1-5]", ErrorMessage = "Invalid ID Value")]
        public int Rating { get; set; }
        [Required(ErrorMessage = "CustName is required.")]
        public string CustName { get; set; }
        [Required(ErrorMessage = "RestID is required to link the review to a Restaurant.")]
        [RegularExpression(@"[0-9]", ErrorMessage = "Invalid RestID Value")]
        public int RestID { get; set; }

        //add a review for a restaurant
        public void AddReview(Review review)
        {
            _db.AddReview(ToDataRev(review));
            Debug.Write("Added 1 Review");
        }
        //delete a review 
        public void DeleteReview(Review review)
        {
            _db.DeleteReview(ToDataRev(review));
            Debug.Write("Deleted 1 Review");
        }
        //edit a resview
        public void UpdateReview(Review review)
        {
            _db.EditReview(ToDataRev(review));
        }
        //gets all reviews
        public IEnumerable<Review> GetReviews()
        {

            var revs = _db.GetReviews().ToList();
            var result = revs.Select(x => ToWebRev(x));
            return result;
        }
        //gets a review based on ID
        public Review GetReviewById(int id)
        {
            return ToWebRev(_db.GetReviews().Where(x => x.ID == id).FirstOrDefault());
        }

        //gets all reviews for a restaurant ID
        public IEnumerable<Review> GetReviewsById(int id)
        {
            var resultsRev = _db.GetReviews();
            List<Review> rev = new List<Review>();
            foreach (var review in resultsRev)
            {
                if (review.RestID == id)
                {
                    rev.Add(ToWebRev(review));
                }
            }
            var result = rev.Select(x => (x));
            return result;
        }


        //mapping
        public static Review ToWebRev(Data.Review dataRestaurant)
        {
            var webReview = new Review()
            {
                ID = dataRestaurant.ID,
                Rating = dataRestaurant.Rating,
                CustName = dataRestaurant.CustName,
                RestID = dataRestaurant.RestID.GetValueOrDefault()
            };
            return webReview;
        }

        public static Data.Review ToDataRev(Review webRestaurant)
        {
            var dataRestaurant = new Data.Review()
            {
                ID = webRestaurant.ID,
                Rating = webRestaurant.Rating,
                CustName = webRestaurant.CustName,
                RestID = webRestaurant.RestID
            };
            return dataRestaurant;
        }
    }
}
