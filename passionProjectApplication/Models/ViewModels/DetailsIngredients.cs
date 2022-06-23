using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace passionProjectApplication.Models.ViewModels
{
    public class DetailsIngredients
    {
        public IngredientDto selectedIngredient { get; set; }
        public IEnumerable<CocktailDto> cocktails { get; set; }
    }
}