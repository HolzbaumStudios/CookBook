using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;

namespace CookBook
{
    [Activity(Label = "CookBook", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Testscreen);

            Button clickEvent = FindViewById<Button>(Resource.Id.clickEvent);
            Button enableButton = FindViewById<Button>(Resource.Id.CallButton);
            Button btnPedro = FindViewById<Button>(Resource.Id.btnPedro);

            clickEvent.Click += (object sender, EventArgs e) =>
            {
                clickEvent.Text = "Hey it's your first click!";
                enableButton.Clickable = true;
                enableButton.Enabled = true;
            };

            btnPedro.Click += (object sender, EventArgs e) =>
            {
                fPedro(sender, e);
            };
        }

        // Pedro Test Function
        private void fPedro(object sender, EventArgs e)
        {

            int a = 2;
            int b = 3;
            int c = 1;
            int resultat;
            string antwort;
            string text = "My favorite number is: ";

            resultat = a + a * b + c;
            antwort = text + resultat;

            TextView txtPedro = FindViewById<TextView>(Resource.Id.txtPedro);
            txtPedro.Text = antwort;

        }

    }
}

