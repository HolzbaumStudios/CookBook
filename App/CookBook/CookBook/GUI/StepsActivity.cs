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

namespace CookBook.GUI
{
    [Activity(Label = "StepsActivity", MainLauncher =false)]
    public class StepsActivity : Activity
    {
        // Variablen deklarieren
        ListView myListView;
        Recipe recipe;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Instanzieren
            SetContentView(Resource.Layout.Steps);

            myListView = FindViewById<ListView>(Resource.Id.listViewSteps);
            int recipeId = Intent.GetIntExtra("RecipeId", 0);

            RecipeManager recipeManager = new RecipeManager();
            recipe = recipeManager.SelectRecipe(recipeId);

            Console.WriteLine(recipeId + "das ist die recipe id");

            // ArrayAdapter (Context context,int txtviewresource ID) Klasse um die Liste im gewünschten Format darzustellen
            // this steht hier für die Activity welche eine Subklasse von Context darstellt, daher ist das kein Problem)
            StepsAdapter adapter = new StepsAdapter(this, recipe);

            myListView.Adapter = adapter;
        }
    }
}