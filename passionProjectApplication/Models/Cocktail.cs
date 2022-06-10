using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace passionProjectApplication.Models
{
    public class Cocktail
    {
        [Key]
        public int CocktailId { get; set; }
        public string CocktailName { get; set; }
        public bool IsIceRequired { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }        
    }

    public class CocktailDto
    {
        public int CocktailId { get; set; }
        public string CocktailName { get; set; }
        public bool IsIceRequired { get; set; }
    }
}