using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EbookWebApp.Models;
using EbookWebApp.ViewModels;
using Microsoft.AspNet.Identity;

namespace EbookWebApp.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Order
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("OrderManage");
            }

            var userId = User.Identity.GetUserId();
            var orders = db.Orders.Where(u => u.AplicationUserId == userId).Include(o => o.AplicationUser).Include(o => o.Book);
            //var vm = orders.ProjectTo<OrderViewModel>().ToList();
            var vm = orders.ToList().Select(x => Mapper.Map<OrderViewModel>(x)).ToList();
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult OrderManage(string searchString)
        {
            var orders = from s in db.Orders
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.AplicationUser.FirstName.Contains(searchString) 
                                                     || s.Book.Title.Contains(searchString) 
                                                     || s.Book.Author.Contains(searchString));
            }

            var vm = orders.ToList().Select(x => Mapper.Map<OrderViewModel>(x)).ToList();
            return View(vm);
        }

        // GET: Order/Get/5
        [Authorize]
        public ActionResult Get(int id)
        {
            Book book = db.Books.Find(id);
            var vm =  Mapper.Map<BookViewModel>(book);
            return View(vm);
        }

        //POST Order/Get/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Get([Bind(Include = "Id")] CreateOrderViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var order = db.Orders.SingleOrDefault(o => o.BookId == model.Id && o.AplicationUserId == userId);
            if (ModelState.IsValid)
            {                
                if (order == null)
                {
                    db.Orders.Add(new Order
                    {
                        BookId = model.Id,
                        AplicationUserId = User.Identity.GetUserId()
                    });
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            Book book = db.Books.First(o => o.Id == model.Id);
            var vm = Mapper.Map<BookViewModel>(book);
            ModelState.AddModelError(String.Empty, "You already have this eBook.");
            return View(vm);
        }

        // GET: Order/Rate
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Rate(int orderid, int rank)
        {
            Order order = db.Orders.Find(orderid);
            order.Rank = rank;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
