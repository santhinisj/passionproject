using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace passionProjectApplication.Models
{
    public class CocktailJuice
    {
        public int CocktailJuiceId { get; set; }
        [ForeignKey("Cocktail")]
        public int CocktailId { get; set; }
        public virtual Cocktail Cocktail { get; set; }

        [ForeignKey("Juice")]
        public int JuiceId { get; set; }
        public virtual Juice Juice { get; set; }

        public int quantity { get; set; }
    }
}