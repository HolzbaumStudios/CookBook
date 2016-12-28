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
        private string name;
        private string description;
        private string creator;
        private string imagePath;
        private List<String> tags;
        private List<Step> steps;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public string ImagePath { get; set; }
        public List<Step> Steps { get; set; }

        public Recipe()
        {
            tags = new List<String>();
        }

        public void AddTag(String tag)
        {
            tags.Add(tag);
        }

        public void RemoveTag(String tag)
        {
            tags.Remove(tag);
        }
    }
}   
