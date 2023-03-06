using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracking
{
    [Activity(Label = "AddUser")]
    public class AddUser : Activity
    {
        EditText txtNuevoUsuario;
        EditText txtNuevaClaveUsuario;
        Button btnRegistrarUsuario;
        Button btnCancel;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            txtNuevoUsuario = FindViewById<EditText>(Resource.Id.txtUserName);
            txtNuevaClaveUsuario = FindViewById<EditText>(Resource.Id.txtPassword);
            btnRegistrarUsuario = FindViewById<Button>(Resource.Id.btnNewUser);
            btnCancel = FindViewById<Button>(Resource.Id.btnCancel);

            btnRegistrarUsuario.Click += BtnRegistrarUsuario_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
             //Intent j = new Intent(this, typeof(MainActivity));
            //StartActivity(j);
            SetContentView(Resource.Layout.activity_main);
        }

        private void BtnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNuevoUsuario.Text.Trim()) && !string.IsNullOrEmpty(txtNuevoUsuario.Text.Trim()))
                {
                    new Auxiliar().Guardar(new Login() { Id = 0, UserName = txtNuevoUsuario.Text.Trim(), Password = txtNuevaClaveUsuario.Text.Trim() });
                    Toast.MakeText(this, "Registro guardado", ToastLength.Long).Show();
                    SetContentView(Resource.Layout.activity_main);
                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese un nombre de usuario y una clave", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}