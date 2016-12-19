using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.recipes
{
    class Recipe
    {
        public String name { get; set; }
        public String description { get; set; }
        public String creator { get; set; }
        public String imagePath { get; set; }

        public List<Step> steps { get; set; }
    }
}   
