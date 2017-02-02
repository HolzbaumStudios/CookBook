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
    // Set this activity as the first activity to start
    [Activity(Label = "Homescreen", MainLauncher =true)]
    public class HomescreenActivity : Activity
    {   
        /// <summary>
        /// Auto-generated OnCreate method for an activity
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Attach a layout to this activity
            SetContentView(Resource.Layout.Homescreen);
            ImageButton btnRecipes = FindViewById<ImageButton>(Resource.Id.imageButtonRecipes);
            
            /// <summary>
            /// OnClick mehtod for an object -> Load a new Activity
            /// </summary>
            /// <param name="sender, e"></param>
            btnRecipes.Click += (object sender, EventArgs e) =>
                {
                    var myIntent = new Intent(this, typeof(RecipesActivity));
                    StartActivityForResult(myIntent, 0);
                };
        }
    }
}