using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CookBook.Recipes
{
    /// <summary>
    /// This class contains all necessary methods to generate a shopping list, based on the recipe.
    /// NOTE: The shopping list is not present in the GUI yet!
    /// </summary>
    class ShoppingList
    {
        private Dictionary<String, ListIngredient> shoppingListMap = new Dictionary<String, ListIngredient>();

        /// <summary>
        /// Return a list of the necessary ingredients for the shopping list
        /// </summary>
        public List<ListIngredient> GetShoppingList()
        {
            var shoppingList = new List<ListIngredient>();
            foreach(KeyValuePair<String, ListIngredient> entry in shoppingListMap)
            {
                shoppingList.Add(entry.Value);
            }
            return shoppingList;
        }

        /// <summary>
        /// Add a listIngredient to the shopping list and control if the ingredient is already present.
        /// </summary>
        /// <param name=""></param>
        public void AddIngredientToList(ListIngredient ingredient)
        {
            if(shoppingListMap.ContainsKey(ingredient.ingredientName))
            {
                shoppingListMap[ingredient.ingredientName].AddAmount(ingredient.ingredientAmount);
            }
            else
            {
                shoppingListMap.Add(ingredient.ingredientName, ingredient);
            }
        }
    }

    /// <summary>
    /// A reduced form of Ingredient.cs, carrying only the necessary data for the shopping list.
    /// </summary>
    public class ListIngredient
    {
        public ListIngredient(String name, int amount, String unit)
        {
            ingredientName = name;
            ingredientAmount = amount;
            measuringUnit = unit;
        }

        public String ingredientName { get; set; }
        public int ingredientAmount { get; set; } //always store the values for 1 person
        public String measuringUnit { private get; set; }

        /// <summary>
        /// Return the needed amount of the ingredient multiplied by the number of portions.
        /// </summary>
        /// <param name="portions">The number of portions the recipe is set to.</param>
        /// <returns></returns>
        public int GetAmountBasedOnPortions(int portions)
        {
            return ingredientAmount * portions;
        }

        public void AddAmount(int amount)
        {
            ingredientAmount += amount;
        }
    }
}
 