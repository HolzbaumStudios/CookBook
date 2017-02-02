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
    class StepsAdapter : BaseAdapter<Step>
    {
        private Recipe myRecipe;
        private Context recipeContext;

        /// <summary>
        /// Method that gets an Activity in this case and a List-item and implements them
        /// </summary>
        /// <param name="context"></param>
        /// <param name="recipe"></param>
        public StepsAdapter(Context context, Recipe recipe)
        {
            myRecipe = recipe;
            recipeContext = context;
        }

        public override int Count
        {
            get
            {
                return myRecipe.Steps.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Step this[int position]
        {
            get
            {
                return myRecipe.Steps[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(recipeContext).Inflate(Resource.Layout.StepsListItems, null, false);
            }

            TextView textViewStepsDescription = row.FindViewById<TextView>(Resource.Id.textViewStepsDescription);
            textViewStepsDescription.Text = myRecipe.Steps[position].Description;
            TextView textViewStepsSteps = row.FindViewById<TextView>(Resource.Id.textViewStepsSteps);
            // Set what has to be shown in the row
            foreach (Ingredient ingredient in myRecipe.Steps[position].Ingredients)
            {
                textViewStepsSteps.Text = ingredient.Name + " " + ingredient.Quantity + " " + ingredient.Unit;
            }
            return row;
        }
    }
}