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
    [Activity(Label = "Proveedores")]
    public class Proveedores : Activity
    {
        EditText txtNitProveedor;
        EditText Nombre;
        Button btnHome;
        Button btnSearch;
        Button btnDelete;
        Button btnAdd;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Proveedores);
            txtNitProveedor = FindViewById<EditText>(Resource.Id.txtNitProveedor);
            Nombre = FindViewById<EditText>(Resource.Id.txtNameProv);
            btnHome = FindViewById<Button>(Resource.Id.btnHome);
            btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnAdd = FindViewById<Button>(Resource.Id.btnAdd);

            btnHome.Click += BtnHome_Click;
            btnSearch.Click += BtnSearch_Click;
            btnDelete.Click += BtnDelete_Click;
            btnAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Funciona el botón Add", ToastLength.Short).Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Funciona el botón Delete", ToastLength.Short).Show();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Funciona el botón Search", ToastLength.Short).Show();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Welcome));
            StartActivity(i);
            
        }
    }
}