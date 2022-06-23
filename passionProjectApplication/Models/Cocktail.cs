using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace passionProjectApplication.Models
{
    public class Cocktail
    {
        [Key]
        public int CocktailId { get; set; }
        public string CocktailName { get; set; }
        public bool IsIceRequired { get; set; }

        //a cocktail belong to one category
        //one category can have different cocktails
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }        
    }

    public class CocktailDto
    {
        public int CocktailId { get; set; }
        public string CocktailName { get; set; }
        public bool IsIceRequired { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public IEnumerable<string> Ingredients { get; set; }
    }
}