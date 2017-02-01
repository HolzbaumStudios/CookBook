using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Recipes
{
    /// <summary>
    /// The base class for all recipes containing all information the recipe needs.
    /// </summary>
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

        /// <summary>
        /// Adds an object of type Step to the recipe.
        /// </summary>
        /// <param name="step"></param>
        public void AddStep(Step step)
        {
            Steps.Add(step);
        }

        /// <summary>
        /// Removes an object of type Step from the recipe.
        /// </summary>
        /// <param name="step"></param>
        public void RemoveStep(Step step)
        {
            Steps.Remove(step);
        }

        /// <summary>
        /// Adds a tag as String to the recipe.
        /// </summary>
        /// <param name="tag"></param>
        public void AddTag(String tag)
        {
            Tags.Add(tag);
        }

        /// <summary>
        /// Removes a tag from the recipe.
        /// </summary>
        /// <param name="tag"></param>
        public void RemoveTag(String tag)
        {
            Tags.Remove(tag);
        }
    }
}   
