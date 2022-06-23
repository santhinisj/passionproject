using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace passionProjectApplication.Models.ViewModels
{
    public class DetailsCategory
    {
        public CategoryDto SelectedCategory { get; set; }
        public IEnumerable<CocktailDto> RelatedCocktails { get; set; }
    }
}