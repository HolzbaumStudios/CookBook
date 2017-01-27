using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.recipes
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public string ImagePath { get; set; }
        public int ImageId { get; set; }
        public List<Step> Steps { get; private set; }
        public List<String> Tags { get; private set; }

        /// <summary>
        /// Constructor for en empty recipe
        /// </summary>
        public Recipe()
        {
            Id = 0;
            Steps = new List<Step>();
            Tags = new List<String>();
        }

        public void AddStep(Step step)
        {
            Steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            Steps.Remove(step);
        }

        public void AddTag(String tag)
        {
            Tags.Add(tag);
        }

        public void RemoveTag(String tag)
        {
            Tags.Remove(tag);
        }
    }
}   
