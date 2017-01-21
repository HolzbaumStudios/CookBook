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
    // BaseAdapater ist eine abstrakte Klasse und deshalb m�ssen vorgegebene Funktionen implementiert werden
    class RecipesAdapter : BaseAdapter<RecipeTest> //statt string
    {
        private List<RecipeTest> myRecipes;
        private Context recipeContext;

        public RecipesAdapter(Context context, List<RecipeTest> recipes) //statt string
        {
            myRecipes = recipes;
            recipeContext = context;
        } 

        // Gibt dem Listview zur�ck, wieviele Items in der Liste sind und dargestellt werden sollen.
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
        public override RecipeTest this[int position]
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
            recipeName.Text = myRecipes[position].RecipeName;

            return row;
        }
    }
}