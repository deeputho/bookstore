using DeepuTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeepuTestApp.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            ViewBag.ItemList = "Book Store Item List Page";
            BookStoreDBHandler BSHandler = new BookStoreDBHandler();
            ModelState.Clear();
            return View(BSHandler.GetBookList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            BookStoreDBHandler StoreDBHandler = new BookStoreDBHandler();
            return View(StoreDBHandler.GetBookList().Find(bookmodel => bookmodel.BookId == id));
        }

        // GET: Book/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookModel bookModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    BookStoreDBHandler StoreDBHandler = new BookStoreDBHandler();
                    if (StoreDBHandler.InsertItem(bookModel))
                    {
                        ViewBag.Message = "Item Added Successfully";
                        ModelState.Clear();
                    }
                }
                //return RedirectToAction("Index");
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BookStoreDBHandler StoreDBHandler = new BookStoreDBHandler();
            return View(StoreDBHandler.GetBookList().Find(bookmodel => bookmodel.BookId == id));
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookModel bookModel)
        {
            try
            {
                // TODO: Add update logic here
                BookStoreDBHandler StoreDBHandler = new BookStoreDBHandler();
                StoreDBHandler.UpdateBook(bookModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            BookStoreDBHandler StoreDBHandler = new BookStoreDBHandler();
            return View(StoreDBHandler.GetBookList().Find(bookmodel => bookmodel.BookId == id));
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BookModel bookModel)
        {
            try
            {
                // TODO: Add delete logic here
                BookStoreDBHandler StoreDBHandler = new BookStoreDBHandler();
                if (StoreDBHandler.DeleteBook(id))
                {
                    ViewBag.AlertMsg = "Item Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
