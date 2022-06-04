using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace passionProjectApplication.Models
{
    public class Cocktail
    {
        public int CocktailId { get; set; }
        public string CocktailName { get; set; }
        public bool IsIceRequired { get; set; }
    }

    public class CocktailDto
    {
        public int CocktailId { get; set; }
        public string CocktailName { get; set; }
        public bool IsIceRequired { get; set; }
    }
}