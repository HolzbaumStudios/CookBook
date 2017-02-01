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

namespace CookBook.Recipes
{
    /// <summary>
    /// This class keeps all the ingredient information. The storing and loading is handled by the Recipe Manager.
    /// </summary>
    public class Ingredient
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public int UnitId { get; set; }
    }
}