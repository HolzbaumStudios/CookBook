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
    [Activity(Label = "Recipes", MainLauncher = false)]
    public class RecipesActivity : Activity
    {
        private ListView myListView;
        private List<Recipe> myRecipeList;

        /// <summary>
        /// Auto-generated OnCreate method for an activity
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Recipes);
            // Find a Listview GUI element over it's ID
            myListView = FindViewById<ListView>(Resource.Id.listViewRecipes);

            RecipeManager recipeManager = new RecipeManager();
            myRecipeList = recipeManager.GetListOfAllRecipes();

            // ArrayAdapter(Context context,int txtviewresource ID). Class to show my list in the format I define
            // "this" stands for this Activity (since it's a subclass from context there is no problem using "this")
            RecipesAdapter adapter = new RecipesAdapter(this, myRecipeList);

            // Attach my adapter to the view it has to show
            myListView.Adapter = adapter;

            // Start clickevent handler when a listitem has been clicked
            myListView.ItemClick += MyListView_ItemClick;

        }
        // Clickevent handler (also attaches the ID of the clicked object to the new Intent)
        private void MyListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent myIntent = new Intent(this, typeof(RecipeDetailsActivity));
            myIntent.PutExtra("RecipeId", myRecipeList[e.Position].Id);
            StartActivityForResult(myIntent, 0);
        }

    }        
}