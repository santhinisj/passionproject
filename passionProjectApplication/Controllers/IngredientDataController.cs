using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using passionProjectApplication.Models;

namespace passionProjectApplication.Controllers
{
    public class IngredientDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ingredientdata/List
        [HttpGet]
        [ResponseType(typeof(IngredientDto))]
        public IHttpActionResult List()
        {
            List<Ingredient> Ingredients = db.Ingredients.ToList();
            List<IngredientDto> IngredientDtos = new List<IngredientDto>();
            Ingredients.ForEach(a => IngredientDtos.Add(new IngredientDto()
            {
                IngredientId = a.IngredientId,
                IngredientName = a.IngredientName,

            })); 
            return Ok(IngredientDtos);
        }

        // GET: IngredientData/Details/5
        [ResponseType(typeof(Ingredient))]
        [HttpGet]
        public IHttpActionResult FindIngredient(int id)
        {
            Ingredient Ingredient = db.Ingredients.Find(id);
            IngredientDto ingredientDto = new IngredientDto()
            {
                IngredientId = Ingredient.IngredientId,
                IngredientName = Ingredient.IngredientName,

            };

            return Ok(ingredientDto);
        }

        [HttpGet]
        [ResponseType(typeof(IngredientDto))]
        public IHttpActionResult ListIngredientsForCocktail(int id)
        {
            List<Ingredient> Ingredients = db.Ingredients.Where(K=>K.Cocktails.Any(a=>a.CocktailId == id)).ToList();
            List<IngredientDto> IngredientDtos = new List<IngredientDto>();
            Ingredients.ForEach(k => IngredientDtos.Add(new IngredientDto()
            {
                IngredientId = k.IngredientId,
                IngredientName = k.IngredientName,
            }));
            return Ok(IngredientDtos);
        }


        // PUT: api/IngredientData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateIngredient(int id, Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredient.IngredientId)
            {
                return BadRequest();
            }

            db.Entry(ingredient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/IngredientData
        [ResponseType(typeof(Ingredient))]
        public IHttpActionResult AddIngredient(Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ingredients.Add(ingredient);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ingredient.IngredientId }, ingredient);
        }

        // DELETE: api/IngredientData/5
        [ResponseType(typeof(Ingredient))]
        public IHttpActionResult DeleteIngredient(int id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            db.Ingredients.Remove(ingredient);
            db.SaveChanges();

            return Ok(ingredient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngredientExists(int id)
        {
            return db.Ingredients.Count(e => e.IngredientId == id) > 0;
        }
    }
}