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
    public class CocktailsDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CocktailsData/List
        [HttpGet]
        public IEnumerable<CocktailDto> List()
        {
            List<Cocktail> Cocktails = db.Cocktails.ToList();
            List<CocktailDto> CocktailDtos = new List<CocktailDto>();
            Cocktails.ForEach(a => CocktailDtos.Add(new CocktailDto()
            {
                CocktailId = a.CocktailId,
                CocktailName = a.CocktailName,
                IsIceRequired = a.IsIceRequired,
                CategoryId = a.Category.CategoryId,
                CategoryName = a.Category.CategoryName

            }));
            return CocktailDtos;
        }

        // GET: api/CocktailsData/findCocktail/5
        [ResponseType(typeof(Cocktail))]
        [HttpGet]
        public IHttpActionResult FindCocktail(int id)
        {
            Cocktail Cocktail = db.Cocktails.Find(id);
            CocktailDto CocktailDto = new CocktailDto()
            {
                CocktailId = Cocktail.CocktailId,
                CocktailName = Cocktail.CocktailName,
                IsIceRequired = Cocktail.IsIceRequired,
                CategoryId = Cocktail.Category.CategoryId,
                CategoryName= Cocktail.Category.CategoryName

            };
            
            if (Cocktail == null)
            {
                return NotFound();
            }

            return Ok(CocktailDto);
        }


        //agthers info about cocktails related to a particular category
        //api/cocktaildata/listcocktailsforcategory/3
        [HttpGet]
        [ResponseType(typeof(CocktailDto))]
        public IHttpActionResult ListCocktailsForCategory(int id)
        {
            List<Cocktail> Cocktails = db.Cocktails.Where(a => a.CategoryId == id).ToList();
            List<CocktailDto> CocktailDtos = new List<CocktailDto>();
            Cocktails.ForEach(a => CocktailDtos.Add(new CocktailDto()
            {
                CocktailId = a.CocktailId,
                CocktailName = a.CocktailName,
                IsIceRequired = a.IsIceRequired,
                CategoryId = a.Category.CategoryId,
                CategoryName = a.Category.CategoryName

            }));
            return Ok(CocktailDtos);

        }

        //agthers info about cocktails related to a particular ingredient
        //api/cocktailsdata/ListCocktailsForIngredient/3
        [HttpGet]
        [ResponseType(typeof(CocktailDto))]
        public IHttpActionResult ListCocktailsForIngredient(int id)
        {
            //all cocktails that have ingredients that match with this id
            List<Cocktail> Cocktails = db.Cocktails.Where(a => a.Ingredients.Any(k=>k.IngredientId== id)).ToList();
            List<CocktailDto> CocktailDtos = new List<CocktailDto>();
            Cocktails.ForEach(a => CocktailDtos.Add(new CocktailDto()
            {
                CocktailId = a.CocktailId,
                CocktailName = a.CocktailName,
                IsIceRequired = a.IsIceRequired,
                CategoryId = a.Category.CategoryId,
                CategoryName = a.Category.CategoryName

            }));

            return Ok(CocktailDtos);

        }


        // PUT: api/CocktailsData/UpdateCocktail/5
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateCocktail(int id, Cocktail cocktail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cocktail.CocktailId)
            {
                return BadRequest();
            }

            db.Entry(cocktail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CocktailExists(id))
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

        // POST: api/CocktailsData/AddCocktail
        [ResponseType(typeof(Cocktail))]
        [HttpPost]
        public IHttpActionResult AddCocktail(Cocktail cocktail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cocktails.Add(cocktail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cocktail.CocktailId }, cocktail);
        }

        // DELETE: api/CocktailsData/DeleteCocktail/5
        [ResponseType(typeof(Cocktail))]
        [HttpPost]
        public IHttpActionResult DeleteCocktail(int id)
        {
            Cocktail cocktail = db.Cocktails.Find(id);
            if (cocktail == null)
            {
                return NotFound();
            }

            db.Cocktails.Remove(cocktail);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CocktailExists(int id)
        {
            return db.Cocktails.Count(e => e.CocktailId == id) > 0;
        }
    }
}