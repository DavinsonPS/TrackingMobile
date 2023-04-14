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
    [Activity(Label = "Create_OC")]
    public class Create_OC : Activity
    {
        EditText txtNitProveedor;
        EditText txtNumberOC;
        Button btnAcept;
        Button btnCancel;
        Button btnHome;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Create_OC);
            txtNitProveedor = FindViewById<EditText>(Resource.Id.txtNitProveedor);
            txtNumberOC = FindViewById<EditText>(Resource.Id.txtOC);
            btnAcept = FindViewById<Button>(Resource.Id.btnSend);
            btnCancel = FindViewById<Button>(Resource.Id.btnCancel);
            btnHome = FindViewById<Button>(Resource.Id.btnHome);

            btnAcept.Click += BtnAcept_Click;
            btnCancel.Click += BtnCancel_Click;
            btnHome.Click += BtnHome_Click;

        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Welcome));
            StartActivity(i);
            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Welcome));
            StartActivity(i);

        }

        private void BtnAcept_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Funciona el botón aceptar", ToastLength.Short).Show();
        }
    }
}