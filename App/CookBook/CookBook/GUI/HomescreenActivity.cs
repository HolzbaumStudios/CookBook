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

namespace CookBook
{
    [Activity(Label = "Homescreen", MainLauncher =false)]
    public class HomescreenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Homescreen);
                ImageButton btnRecipes = FindViewById<ImageButton>(Resource.Id.imageButtonRecipes);
                btnRecipes.Click += (object sender, EventArgs e) =>
                {
                    var myIntent = new Intent(this, typeof(RecipesActivity));
                    StartActivityForResult(myIntent, 0);
                    //SetContentView(Resource.Layout.Recipes);

                };
        }
    }
}