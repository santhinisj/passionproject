using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace passionProjectApplication.Models.ViewModels
{
    public class UpdateCocktail
    {
        public CocktailDto selectedCocktail { get; set; }
        public IEnumerable<CategoryDto> CategoriesOptions { get; set; }
    }
}