using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace passionProjectApplication.Models
{
    public class Liquor
    {
        [Key]
        public int LiquorID { get; set; }
        public string LiquorName { get; set; }
    }
}