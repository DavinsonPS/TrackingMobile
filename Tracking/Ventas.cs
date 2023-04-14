using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracking
{
    [Activity(Label = "Ventas")]
    public class Ventas : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Ventas);
            // Create your application here
            Button btnHome = FindViewById<Button>(Resource.Id.btnHome);

            btnHome.Click += BtnHome_Click;
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Welcome));
            StartActivity(i);
        }
    }
}