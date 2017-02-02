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
using CookBook.GUI;

namespace CookBook
{
    [Activity(Label = "RecipeDetails", MainLauncher =false)]
    public class RecipeDetailsActivity : Activity
    {
        /// <summary>
        /// Auto-generated OnCreate method for an activity
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RecipeDetails);
            // Find required GUI Elements from the Layout by their IDs
            ImageButton btnRecipes = FindViewById<ImageButton>(Resource.Id.imageButtonRecipes);
            TextView textViewRecipeDetailsAuthor = FindViewById<TextView>(Resource.Id.textViewRecipeDetailsAuthor);
            TextView textViewRecipeDetailsTitle = FindViewById<TextView>(Resource.Id.textViewRecipeDetailsTitle);
            TextView textViewRecipeDetailsDescription = FindViewById<TextView>(Resource.Id.textViewRecipeDetailsDescription);
            Recipe recipe;

            // Take the extra(ID) that was attached when clicked on an object from the list (see RecipesActivity)
            int recipeId = Intent.GetIntExtra("RecipeId", 0);

            // Get the recipeManager to be able to handle recipes correctly (and find the recipe by ID in this case)
            RecipeManager recipeManager = new RecipeManager();
            recipe = recipeManager.SelectRecipe(recipeId);

            // Set content from the recipe to the layout
            textViewRecipeDetailsTitle.Text = recipe.Name;
            textViewRecipeDetailsAuthor.Text = recipe.Creator;
            textViewRecipeDetailsDescription.Text = recipe.Description;

            Button buttonRecipeDetailsPrepare = FindViewById<Button>(Resource.Id.buttonRecipeDetailsPrepare);
            buttonRecipeDetailsPrepare.Click += (object sender, EventArgs e) =>
            {
                var myIntent = new Intent(this, typeof(StepsActivity));
                myIntent.PutExtra("RecipeId", recipeId);
                StartActivityForResult(myIntent, 0);
            };
        }
    }
}