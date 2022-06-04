using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace passionProjectApplication.Models
{
    public class CocktailLiquors
    {
        public int CocktailLiquorsId { get; set; }
        [ForeignKey("Liquor")]
        public int LiquorId { get; set; }
        public virtual Liquor Liquor { get; set; }

        [ForeignKey("Cocktail")]
        public int CocktailId { get; set; }
        public virtual Cocktail Cocktail { get; set; }

        //quantity in ml
        public int quantity { get; set; }


    }
}