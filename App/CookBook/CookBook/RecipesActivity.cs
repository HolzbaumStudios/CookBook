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
    [Activity(Label = "Recipes", MainLauncher =false)]
    public class RecipesActivity : Activity
    {
        // Variablen deklarieren
        int count = 1;
        private List<string> myTestList;
        private ListView myListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Instanzieren
            SetContentView(Resource.Layout.Recipes);
            myListView = FindViewById<ListView>(Resource.Id.listView1);

            myTestList = new List<string>();
            myTestList.Add("Bob");
            myTestList.Add("Tom");
            myTestList.Add("Jim");
            myTestList.Add("Pedro");
            myTestList.Add("Roman");
            myTestList.Add("SirWoody");
            myTestList.Add("LeeSin");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("Bob");
            myTestList.Add("TheEnd");

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, myTestList);

            myListView.Adapter = adapter;

            myListView.ItemClick += MyListView_ItemClick;


        }

        private void MyListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(myTestList[e.Position]);
        }
    }
}