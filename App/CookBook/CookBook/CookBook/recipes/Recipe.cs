using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.recipes
{
    class Recipe
    {
        private int id;
        private String name;
        private String description;
        private String creator;
        private String imagePath;
        private List<Step> steps;

        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Creator { get; set; }
        public String ImagePath { get; set; }
        public List<Step> Steps { get; set; }
    }
}   
