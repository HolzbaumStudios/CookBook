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

namespace CookBook.GUI
{
    [Activity(Label = "StepsActivity", MainLauncher =false)]
    public class StepsActivity : Activity
    {
        ListView myListView;
        Recipe recipe;

        /// <summary>
        /// Auto-generated OnCreate method for an activity
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Steps);

            myListView = FindViewById<ListView>(Resource.Id.listViewSteps);
            int recipeId = Intent.GetIntExtra("RecipeId", 0);

            RecipeManager recipeManager = new RecipeManager();
            recipe = recipeManager.SelectRecipe(recipeId);

            StepsAdapter adapter = new StepsAdapter(this, recipe);

            myListView.Adapter = adapter;
        }
    }
}