using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using passionProjectApplication.Models;
using System.Web.Script.Serialization;

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
            IEnumerable<CocktailDto> cocktails = response.Content.ReadAsAsync<IEnumerable<CocktailDto>>().Result;
           
            return View(cocktails);
        }

        // GET: Cocktail/Details/5
        public ActionResult Details(int id)
        {
            //communicate with cocktail data api to retrieve one animal
            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44329/api/CocktailsData/findcocktail/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            CocktailDto selectedCocktail = response.Content.ReadAsAsync<CocktailDto>().Result;
            return View(selectedCocktail);
        }

        public ActionResult Error()
        {
            return View();
        }
        // GET: Cocktail/New
        public ActionResult New()
        {
            return View();
        }

        // POST: Cocktail/Create
        [HttpPost]
        public ActionResult Create(Cocktail cocktail)
        {
            try
            {
                // TODO: Add insert logic here
                HttpClient client = new HttpClient() { };
                string url = "https://localhost:44329/api/CocktailsData/addCocktail/";
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string jsonpayload = jss.Serialize(cocktail);
                HttpContent content = new StringContent(jsonpayload);
                content.Headers.ContentType.MediaType = "application/json";
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    return RedirectToAction("Error");
                }
                
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
