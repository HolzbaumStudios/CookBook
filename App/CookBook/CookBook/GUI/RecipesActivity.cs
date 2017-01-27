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
    [Activity(Label = "Recipes", MainLauncher = false)]
    public class RecipesActivity : Activity
    {
        // Variablen deklarieren
        private ListView myListView;
        private List<Recipe> myRecipeList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Instanzieren
            SetContentView(Resource.Layout.Recipes);
            myListView = FindViewById<ListView>(Resource.Id.listViewRecipes);

            RecipeManager recipeManager = new RecipeManager();
            myRecipeList = recipeManager.GetListOfAllRecipes();

            // ArrayAdapter (Context context,int txtviewresource ID) Klasse um die Liste im gewünschten Format darzustellen
            // this steht hier für die Activity welche eine Subklasse von Context darstellt, daher ist das kein Problem)
            RecipesAdapter adapter = new RecipesAdapter(this, myRecipeList);

            myListView.Adapter = adapter;

            myListView.ItemClick += MyListView_ItemClick;

        }
        // Clickevent handler
        private void MyListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent myIntent = new Intent(this, typeof(RecipeDetailsActivity));
            myIntent.PutExtra("RecipeId", myRecipeList[e.Position].Id);
            StartActivityForResult(myIntent, 0);
        }

    }        
}