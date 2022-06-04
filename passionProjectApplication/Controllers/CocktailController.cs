using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace passionProjectApplication.Controllers
{
    public class CocktailController : Controller
    {
        // GET: Cocktail 
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cocktail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cocktail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cocktail/Create
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

        // GET: Cocktail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cocktail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cocktail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cocktail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
