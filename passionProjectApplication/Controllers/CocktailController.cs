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
    public class CocktailController : Controller
    {
        // GET: Cocktail 
        private static readonly HttpClient client;

        static CocktailController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44329/api/");
        }

        public ActionResult List()
        {
            //objective: communicte with cocktail api to get the list
           
            string url = "cocktailsdata/List";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<CocktailDto> cocktails = response.Content.ReadAsAsync<IEnumerable<CocktailDto>>().Result;

  
            return View(cocktails);
        }

        // GET: Cocktail/Details/5
        public ActionResult Details(int id)
        {
            //communicate with cocktail data api to retrieve one animal
            DetailsCocktail ViewModel =  new DetailsCocktail();
            string url = "CocktailsData/findcocktail/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            CocktailDto selectedCocktail = response.Content.ReadAsAsync<CocktailDto>().Result;
           // url = "ingredientdata/ListIngredientsForCocktail" + id;
            //response = client.GetAsync(url).Result;
            //IEnumerable<IngredientDto> AllIngredients = response.Content.ReadAsAsync<IEnumerable<IngredientDto>>().Result;

            ///ViewModel.AllIngredients = AllIngredients;
            ViewModel.SelectedCocktail = selectedCocktail;
           
            return View(ViewModel);
        }

        public ActionResult Error()
        {
            return View();
        }
        // GET: Cocktail/New
        public ActionResult New()
        {
            string url = "categorydata/list";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<CategoryDto> categories = response.Content.ReadAsAsync<IEnumerable<CategoryDto>>().Result;

            return View(categories);
        }

        // POST: Cocktail/Create
        [HttpPost]
        public ActionResult Create(Cocktail cocktail)
        {
            try
            {
                // TODO: Add insert logic here
                
                string url = "CocktailsData/addCocktail/";
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
            UpdateCocktail  ViewModel =  new UpdateCocktail();
            string url = "CocktailsData/findcocktail/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            CocktailDto cocktailDto = response.Content.ReadAsAsync<CocktailDto>().Result;   
            ViewModel.selectedCocktail = cocktailDto;

             url = "categorydata/list" ;
             response = client.GetAsync(url).Result;
            IEnumerable<CategoryDto> CategoriesOptions = response.Content.ReadAsAsync<IEnumerable<CategoryDto>>().Result;

            ViewModel.CategoriesOptions = CategoriesOptions;
            return View(ViewModel);
        }

        // POST: Cocktail/Edit/5
        [HttpPost]
        public ActionResult Update(int id, Cocktail cocktail)
        {
            try
            {
                // TODO: Add update logic here

                string url = "CocktailsData/updatecocktail/" + id;
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

        // GET: Cocktail/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = "CocktailsData/findcocktail/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            CocktailDto selectedCocktail =  response.Content.ReadAsAsync<CocktailDto>().Result;
            return View(selectedCocktail);
        }

        // POST: Cocktail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                string url = "CocktailsData/deletecocktail/" + id;
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
