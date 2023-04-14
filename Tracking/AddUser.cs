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
            SetContentView(Resource.Layout.AddUser);
            txtNuevoUsuario = FindViewById<EditText>(Resource.Id.txtNewUserName);
            txtNuevaClaveUsuario = FindViewById<EditText>(Resource.Id.txtNewPassword);
            btnRegistrarUsuario = FindViewById<Button>(Resource.Id.btnNewUser);
            btnCancel = FindViewById<Button>(Resource.Id.btnCancel);

            btnRegistrarUsuario.Click += BtnRegistrarUsuario_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Intent j = new Intent(this, typeof(MainActivity));
            StartActivity(j);
        }

        private void BtnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Confirmación");
            builder.SetMessage("¿Desea registrar el usuario?");
            builder.SetPositiveButton("Acept", (s, e) =>
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtNuevoUsuario.Text.Trim()) && !string.IsNullOrEmpty(txtNuevaClaveUsuario.Text.Trim()))
                    {
                        new Auxiliar().Guardar(new Login()
                        {
                            Id = 0,
                            UserName = txtNuevoUsuario.Text.Trim(),
                            Password = txtNuevaClaveUsuario.Text.Trim()
                        });
                        Toast.MakeText(this, "Usuario registrado exitosamente", ToastLength.Long).Show();
                        Intent j = new Intent(this, typeof(MainActivity));
                        StartActivity(j);
                    }
                    else
                    {
                        Toast.MakeText(this, "Por favor ingrese un nombre de usuario y una clave", ToastLength.Long).Show();
                    }
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
                }
            });
            builder.SetNegativeButton("Cancel", (s, e) => { });
            builder.Show();
        }
    }
}