using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WirelessMedia.Models;

namespace WirelessMedia.Controllers
{
    public class HomeController : Controller
    {

        private ProductsDBEntities db = new ProductsDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var productToEdit = (from m in db.Products
                               where m.Id == id
                               select m).First();

            return View(productToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Products productToEdit)
        {
            var originalProduct = (from m in db.Products
                                   where m.Id == productToEdit.Id
                                 select m).First();

            if (!ModelState.IsValid)
                return View(originalProduct);

            db.Entry(originalProduct).CurrentValues.SetValues(productToEdit);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
