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
using CookBook.recipes;

namespace CookBook
{
    [Activity(Label = "RecipeDetails", MainLauncher =false)]
    public class RecipeDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RecipeDetails);
            ImageButton btnRecipes = FindViewById<ImageButton>(Resource.Id.imageButtonRecipes);
            TextView textViewRecipeDetailsAuthor = FindViewById<TextView>(Resource.Id.textViewRecipeDetailsAuthor);
            Recipe recipe;

            //string s = Intent.GetStringExtra("RecipeId");
            //int recipeId = Int32.Parse(s);
            int recipeId = Intent.GetIntExtra("RecipeId", 0);

            Console.WriteLine(recipeId + "Ich heisse Thomas");

            RecipeManager recipeManager = new RecipeManager();
            recipe = recipeManager.SelectRecipe(recipeId);

            textViewRecipeDetailsAuthor.Text = recipe.Creator;

        }
    }
}