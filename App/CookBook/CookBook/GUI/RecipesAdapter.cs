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
    // BaseAdapater ist eine abstrakte Klasse und deshalb müssen vorgegebene Funktionen implementiert werden
    class RecipesAdapter : BaseAdapter<Recipe> //statt string
    {
        private List<Recipe> myRecipes; //statt List<RecipeTest>
        private Context recipeContext;

        public RecipesAdapter(Context context, List<Recipe> recipes) //statt List<RecipeTest>
        {
            myRecipes = recipes;
            recipeContext = context;
        } 

        // Gibt dem Listview zurück, wieviele Items in der Liste sind und dargestellt werden sollen.
        public override int Count
        {
            get
            {
                return myRecipes.Count;
            }
        }

        //
        public override long GetItemId(int position)
        {
            return position;
        }

        //
        public override Recipe this[int position] //statt RecipeTest
        {
            get
            {
                return myRecipes[position];
            }
        }

        //around 10
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(recipeContext).Inflate(Resource.Layout.RecipesListItems, null, false);
            }

            // Refferenz zum Textelement im View
            TextView recipeName = row.FindViewById<TextView>(Resource.Id.recipeName);
            recipeName.Text = myRecipes[position].Name; //statt recipename

            return row;
        }
    }
}