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
    public class CategoryDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       

        // GET: api/categorydata/List
        [HttpGet]
        public IEnumerable<CategoryDto> List()
        {
            List<Category> Categories = db.Categories.ToList();
            List<CategoryDto> CategoryDtos = new List<CategoryDto>();
            Categories.ForEach(a => CategoryDtos.Add(new CategoryDto()
            {
                CategoryId = a.CategoryId,
                CategoryName = a.CategoryName,

            }));
            return CategoryDtos;
        }

     

        // GET: CategoryData/Details/5
        [ResponseType(typeof(Category))]
        [HttpGet]
        public IHttpActionResult FindCategory(int id)
        {
            Category Category = db.Categories.Find(id);
            CategoryDto categoryDto = new CategoryDto()
            {
                CategoryId = Category.CategoryId,
                CategoryName = Category.CategoryName,

            };

            return Ok(categoryDto);
        }

     
        // PUT: api/CategoryData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/CategoryData/addcategory
        [ResponseType(typeof(Category))]
        public IHttpActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryId }, category);
        }

        // DELETE: api/CategoryData/deletecategory/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.CategoryId == id) > 0;
        }
    }
}