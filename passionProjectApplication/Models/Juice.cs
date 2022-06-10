using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace passionProjectApplication.Models
{
    public class Juice
    {
        public int JuiceId { get; set; }
        public string JuiceName { get; set; }

        public ICollection<Cocktail> cocktails { get; set; }   
    }
}