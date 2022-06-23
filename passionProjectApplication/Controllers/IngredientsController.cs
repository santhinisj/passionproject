using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using passionProjectApplication.Models;
using System.Web.Script.Serialization;
using passionProjectApplication.Models.ViewModels;

namespace passionProjectApplication.Controllers
{
    public class IngredientsController : Controller
    {
        private static readonly HttpClient client;
        static IngredientsController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44329/api/");
        }

        public ActionResult List()
        {
            //objective: communicte with Ingredients api to get the list

            string url = "ingredientdata/List";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<IngredientDto> Ingredientss = response.Content.ReadAsAsync<IEnumerable<IngredientDto>>().Result;


            return View(Ingredientss);
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(int id)
        {
            //communicate with Ingredients data api to retrieve one animal
            DetailsIngredients ViewModel =  new DetailsIngredients();

            string url = "ingredientdata/findIngredient/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            IngredientDto selectedIngredients = response.Content.ReadAsAsync<IngredientDto>().Result;
            ViewModel.selectedIngredient = selectedIngredients;

             url = "cocktailsdata/ListCocktailsForIngredient/" + id;
            response = client.GetAsync(url).Result;
            IEnumerable<CocktailDto> cocktails = response.Content.ReadAsAsync<IEnumerable<CocktailDto>>().Result;
            ViewModel.cocktails = cocktails;
            return View(ViewModel);
        }

       
        public ActionResult Error()
        {
            return View();
        }
        // GET: Ingredients/New
        public ActionResult New()
        {


            return View();
        }

        // POST: Ingredients/Create
        [HttpPost]
        public ActionResult Create(Ingredient Ingredients)
        {
            try
            {
                // TODO: Add insert logic here

                string url = "ingredientdata/addIngredient/";
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string jsonpayload = jss.Serialize(Ingredients);
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

        // GET: Ingredients/Edit/5
        public ActionResult Edit(int id)

        {
            string url = "ingredientdata/findIngredient/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            IngredientDto IngredientsDto = response.Content.ReadAsAsync<IngredientDto>().Result;

            return View(IngredientsDto);
        }

        // POST: Ingredients/Edit/5
        [HttpPost]
        public ActionResult Update(int id, Ingredient Ingredients)
        {
            try
            {
                // TODO: Add update logic here

                string url = "ingredientdata/updateIngredient/" + id;
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string jsonpayload = jss.Serialize(Ingredients);
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

        // GET: Ingredients/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = "ingredientdata/findIngredient/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            IngredientDto selectedIngredients = response.Content.ReadAsAsync<IngredientDto>().Result;
            return View(selectedIngredients);
        }

        // POST: Ingredients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                string url = "ingredientdata/deleteIngredient/" + id;
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

