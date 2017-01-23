using CookBook.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.recipes
{
    public enum TimeUnits { Seconds, Minutes, Hours };

    public class Step
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Timer { get; private set; }
        public string ImagePath { get; set; }
        public int ImageId { get; set; }
        public List<Ingredient> Ingredients { get; }

        public Step()
        {
            Ingredients = new List<Ingredient>();
        }

        /// <summary>
        /// Gets the input timer value and converts it to seconds.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="unit">The unit.</param>
        public void SetTimer(int amount, TimeUnits unit)
        {
            int seconds = 0;
            switch (unit)
            {
                case TimeUnits.Hours:
                    seconds = amount * 3600;
                    break;
                case TimeUnits.Minutes:
                    seconds = amount * 60;
                    break;
                case TimeUnits.Seconds:
                    seconds = amount;
                    break;
            }
            Timer = seconds;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            try
            {
                Ingredients.Add(ingredient);
            }
            catch (NullReferenceException ex)
            {
                //LOG this exception;
            }
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            if (Ingredients.Contains(ingredient))
            {
                Ingredients.Remove(ingredient);
            }
        }
    }
}
