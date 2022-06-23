using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using passionProjectApplication.Models;
using System.Web.Script.Serialization;
using passionProjectApplication.Models.ViewModels;

namespace passionProjectApplication.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category 
        private static readonly HttpClient client;

        static CategoryController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44329/api/");
        }

        public ActionResult List()
        {
            //objective: communicte with Category api to get the list

            string url = "categorydata/List";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<CategoryDto> categories = response.Content.ReadAsAsync<IEnumerable<CategoryDto>>().Result;


            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            //communicate with Category data api to retrieve one animal
            DetailsCategory ViewModel = new DetailsCategory();
            string url = "CategoryData/findCategory/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            CategoryDto selectedCategory = response.Content.ReadAsAsync<CategoryDto>().Result;
            ViewModel.SelectedCategory = selectedCategory;
            url = "cocktailsdata/listcocktailsforcategory/" + id;
            response = client.GetAsync(url).Result;
            IEnumerable<CocktailDto> RelatedCocktails = response.Content.ReadAsAsync<IEnumerable<CocktailDto>>().Result;
            ViewModel.RelatedCocktails = RelatedCocktails;
            return View(ViewModel);
        }

        public ActionResult Error()
        {
            return View();
        }
        // GET: Category/New
        public ActionResult New()
        {


            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category Category)
        {
            try
            {
                // TODO: Add insert logic here

                string url = "CategoryData/addCategory/";
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string jsonpayload = jss.Serialize(Category);
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

        // GET: Category/Edit/5
        public ActionResult Edit(int id)

        {
            string url = "CategoryData/findCategory/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            CategoryDto CategoryDto = response.Content.ReadAsAsync<CategoryDto>().Result;

            return View(CategoryDto);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Update(int id, Category Category)
        {
            try
            {
                // TODO: Add update logic here

                string url = "CategoryData/updateCategory/" + id;
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string jsonpayload = jss.Serialize(Category);
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

        // GET: Category/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = "CategoryData/findCategory/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            CategoryDto selectedCategory = response.Content.ReadAsAsync<CategoryDto>().Result;
            return View(selectedCategory);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                string url = "CategoryData/deleteCategory/" + id;
                HttpContent content = new StringContent("");
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
    }
}

