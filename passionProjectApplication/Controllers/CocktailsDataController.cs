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
            List<Cocktail> Cocktails = db.CocktailSet.ToList();
            List<CocktailDto> CocktailDtos = new List<CocktailDto>();
            Cocktails.ForEach(a => CocktailDtos.Add(new CocktailDto()
            {
                CocktailId = a.CocktailId,
                CocktailName = a.CocktailName,
                IsIceRequired = a.IsIceRequired

            }));
            return CocktailDtos;
        }

        // GET: api/CocktailsData/findCocktail/5
        [ResponseType(typeof(Cocktail))]
        [HttpGet]
        public IHttpActionResult FindCocktail(int id)
        {
            Cocktail cocktail = db.CocktailSet.Find(id);
            
            if (cocktail == null)
            {
                return NotFound();
            }

            return Ok(cocktail);
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

            db.CocktailSet.Add(cocktail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cocktail.CocktailId }, cocktail);
        }

        // DELETE: api/CocktailsData/DeleteAnimal/5
        [ResponseType(typeof(Cocktail))]
        [HttpPost]
        public IHttpActionResult DeleteCocktail(int id)
        {
            Cocktail cocktail = db.CocktailSet.Find(id);
            if (cocktail == null)
            {
                return NotFound();
            }

            db.CocktailSet.Remove(cocktail);
            db.SaveChanges();

            return Ok(cocktail);
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
            return db.CocktailSet.Count(e => e.CocktailId == id) > 0;
        }
    }
}