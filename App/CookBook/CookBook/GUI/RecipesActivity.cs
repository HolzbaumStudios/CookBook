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
    [Activity(Label = "Recipes", MainLauncher = true)]
    public class RecipesActivity : Activity
    {
        // Variablen deklarieren
        //private List<RecipeTest> myTestList;
        private ListView myListView;
        private List<Recipe> myRecipeList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Instanzieren
            SetContentView(Resource.Layout.Recipes);
            myListView = FindViewById<ListView>(Resource.Id.listView1);

            RecipeManager recipeManager = new RecipeManager();
            myRecipeList = recipeManager.GetListOfAllRecipes();

            Console.WriteLine(myRecipeList[0].Creator);
            Console.WriteLine("Ichzähle so viel:" + myRecipeList.Count());

            //myTestList = new List<RecipeTest>();
            //myTestList.Add(new RecipeTest() { RecipeName = "Risotto", RecipeID = 1, Description = "Isch wüki fein", Creator = "Roman" });
            //myTestList.Add(new RecipeTest() { RecipeName = "Pizza", RecipeID = 2, Description = "Isch au guet", Creator = "Pirata" });
            //myTestList.Add(new RecipeTest() { RecipeName = "Tiramisu", RecipeID = 3, Description = "Schuldet mir de Pedro", Creator = "Pedro" });
            //myTestList.Add(new RecipeTest() { RecipeName = "Pasta con BroWi", RecipeID = 4, Description = "Eigekreation", Creator = "Roman" });
            //myTestList.Add(new RecipeTest() { RecipeName = "Salat", RecipeID = 5, Description = "Wänns muess sii", Creator = "Pedro" });
            //myTestList.Add(new RecipeTest() { RecipeName = "Tomate", RecipeID = 6, Description = "Zum pflücke", Creator = "Nöd für de Pedro" });
            //myTestList.Add(new RecipeTest() { RecipeName = "Gurke mit Spaghetti", RecipeID = 7, Description = "Isst kein Mänsch", Creator = "Roman" });

            // ArrayAdapter (Context context,int txtviewresource ID) Klasse um die Liste im gewünschten Format darzustellen
            // this steht hier für die Activity welche eine Subklasse von Context darstellt, daher ist das kein Problem)
            //ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, myTestList);
            RecipesAdapter adapter = new RecipesAdapter(this, myRecipeList); //statt myTestList

            myListView.Adapter = adapter;

            myListView.ItemClick += MyListView_ItemClick;

        }
        // Clickevent handler
        private void MyListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Console.WriteLine(myTestList[e.Position].Description);
            Intent myIntent = new Intent(this, typeof(RecipeDetailsActivity));
            Console.WriteLine("ausgabe e.position" + e.Position);
            Console.WriteLine("ausgabe e.id" + e.Id);
            myIntent.PutExtra("RecipeId", myRecipeList[e.Position].Id);//.ToString()); //statt RecipeCreator
            Console.WriteLine("RezeptId wäre:" + myRecipeList[e.Position].Id);
            StartActivityForResult(myIntent, 0);
        }

    }        
}