using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using passionProjectApplication.Models;

namespace passionProjectApplication.Controllers
{
    public class CocktailController : Controller
    {
        // GET: Cocktail 

        public ActionResult List()
        {
            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44329/api/CocktailsData/List";
            HttpResponseMessage response = client.GetAsync(url).Result;
            Debug.WriteLine("The response code is");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<CocktailDto> cocktails = response.Content.ReadAsAsync<IEnumerable<CocktailDto>>().Result;
            Debug.WriteLine("Number of animals recieved");
            return View(cocktails);
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
