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
using CookBook.Recipes;

namespace CookBook
{
    // BaseAdapater is an abstract class. Therefore required functions have to be implemented
    class RecipesAdapter : BaseAdapter<Recipe>
    {
        private List<Recipe> myRecipes;
        private Context recipeContext;
        
        /// <summary>
        /// Method that gets an Activity in this case and a List-item and implements them
        /// </summary>
        /// <param name="context"></param>
        /// <param name="recipes"></param>
        public RecipesAdapter(Context context, List<Recipe> recipes)
        {
            myRecipes = recipes;
            recipeContext = context;
        }

        /// <summary>
        /// Method that counts the amount of objects received from the list that have to be showed
        /// </summary>
        /// <returns></returns>
        public override int Count
        {
            get
            {
                return myRecipes.Count;
            }
        }

        /// <summary>
        /// method that returns the position of the objects from the list
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override long GetItemId(int position)
        {
            return position;
        }

        /// <summary>
        /// method that returns the list including a specified listitem
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override Recipe this[int position]
        {
            get
            {
                return myRecipes[position];
            }
        }

        /// <summary>
        /// method that defines the view and also inflates rows that are null
        /// </summary>
        /// <param name="position"></param>
        /// <param name="convertView"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(recipeContext).Inflate(Resource.Layout.RecipesListItems, null, false);
            }

            // Refference to the textview from the layout
            TextView recipeName = row.FindViewById<TextView>(Resource.Id.recipeName);
            // Set what has to be shown in the row
            recipeName.Text = myRecipes[position].Name;

            return row;
        }
    }
}