using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace passionProjectApplication.Models.ViewModels
{
    public class DetailsCocktail
    {
        public CocktailDto SelectedCocktail     { get; set; }
        public IEnumerable<IngredientDto> AllIngredients { get; set; }
    }
}