using EbookWebApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EbookWebApp.Controllers
{
    public class RatingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rating
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetRating(int bookId, int rank)
        {
            Rating rating = new Rating();
            rating.Rank = rank;
            rating.BookId = bookId;
            rating.AplicationUserId = User.Identity.GetUserId();

            db.Ratings.Add(rating);
            db.SaveChanges();

            return RedirectToAction("Index", "Order");
        }
    }
}