using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EbookWebApp.Models;
using EbookWebApp.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PagedList;

namespace EbookWebApp.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Book
        public ActionResult Index(string sortOrder, string searchString, string bookGenre, string currentFilter, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = sortOrder == "Title_desc" ? "Title_asc" : "Title_desc";
            ViewBag.AuthorSortParm = sortOrder == "Author_desc" ? "Author_asc" : "Author_desc";
            ViewBag.DateSortParm = sortOrder == "Date_desc" ? "Date_asc" : "Date_desc";
            ViewBag.RateSortParm = sortOrder == "Rate_desc" ? "Rate_asc" : "Rate_desc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var GenreLst = new List<string>();
            var GenreQry = from d in db.Books
                           orderby d.Genre
                           select d.Genre;
            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.bookGenre = new SelectList(GenreLst);
          
            var books = from s in db.Books
                        select s;

            foreach (var item in books.ToList())
            {
                var avgRating = db.Orders.Where(o => o.BookId == item.Id && o.Rank > 0).Select(o => o.Rank).Average();
                item.Overall = avgRating ?? 0;
            }
            db.SaveChanges();

            if (!string.IsNullOrEmpty(bookGenre))
            {
                books = books.Where(s => (s.Title.Contains(searchString) || s.Author.Contains(searchString)) && s.Genre == bookGenre);
            }
            else if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString) || s.Author.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Title_desc":
                    books = books.OrderByDescending(s => s.Title);
                    break;
                case "Title_asc":
                    books = books.OrderBy(s => s.Title);
                    break;
                case "Author_desc":
                    books = books.OrderByDescending(s => s.Author);
                    break;
                case "Author_asc":
                    books = books.OrderBy(s => s.Author);
                    break;
                case "Date_desc":
                    books = books.OrderByDescending(s => s.ReleaseDate);
                    break;
                case "Date_asc":
                    books = books.OrderBy(s => s.ReleaseDate);
                    break;

                case "Rate_desc":
                    books = books.OrderByDescending(s => s.Overall);
                    break;
                case "Rate_asc":
                    books = books.OrderBy(s => s.Overall);
                    break;

                default:
                    books = books.OrderBy(s => s.Title);
                    break;
            }


            int pageSize = 10;
            int pageNumber = (page ?? 1);
           


            var vm = books.ToList().Select(x => Mapper.Map<BookViewModel>(x)).ToList();

            return View(vm.ToPagedList(pageNumber, pageSize));
            //return View(vm);
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Author,Genre,ReleaseDate")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var vm = Mapper.Map<CreateBookViewModel>(book);
            return View(vm);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            var vm = Mapper.Map<CreateBookViewModel>(book);
            return View(vm);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Author,Genre,ReleaseDate")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var vm = Mapper.Map<CreateBookViewModel>(book);
            return View(vm);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
