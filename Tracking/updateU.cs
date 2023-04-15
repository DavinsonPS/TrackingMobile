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
    [Activity(Label = "updateU")]
    public class updateU : Activity
    {
        EditText txtId;
        EditText txtUser;
        EditText txtPassword;
        Button btnConsult;
        Button btnUpdate;
        Button btnDelete;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.updateUsers);
            // Create your application here
            txtId = FindViewById<EditText>(Resource.Id.txtId);
            txtUser = FindViewById<EditText>(Resource.Id.txtUser);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPasswordUser);
            btnConsult = FindViewById<Button>(Resource.Id.btnConsul);
            btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);

            btnConsult.Click += BtnConsult_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            BtnConsult_Click(sender, e);
            if (!string.IsNullOrEmpty(txtUser.Text.Trim()) && txtId.Text != "0" && !string.IsNullOrEmpty(txtId.Text.Trim()))
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Confirmación");
                builder.SetMessage("Desea eliminar el usuario " + txtUser.Text);
                builder.SetPositiveButton("Acept", (s, e) =>
                {
                    try
                    {
                        new Auxiliar().Eliminar(Int32.Parse(txtId.Text));
                        Toast.MakeText(this, "Usuario eliminado", ToastLength.Short).Show();
                        Recreate();
                    }
                    catch (Exception ex)
                    {
                        Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
                    }
                    
                });
                builder.SetNegativeButton("Cancel", (s, e) => { });
                builder.Show();
            }
            
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Confirmación");
            builder.SetMessage("Desea actualizar el usuario " + txtUser.Text);
            builder.SetPositiveButton("Acept", (s, e) =>
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtUser.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()) && !string.IsNullOrEmpty(txtId.Text.Trim()) && txtId.Text != "0")
                    {
                        new Auxiliar().Guardar(new Login()
                        {
                            Id = Int32.Parse(txtId.Text.Trim()),
                            UserName = txtUser.Text.Trim(),
                            Password = txtPassword.Text.Trim()
                        });
                        Toast.MakeText(this, "Datos actualizados.", ToastLength.Short).Show();
                        txtId.Text = "";
                        txtUser.Text = "";
                        txtPassword.Text = "";
                    }
                    else
                    {
                        if (txtId.Text == "0")
                        {
                            Toast.MakeText(this, "El id no puede ser 0", ToastLength.Short).Show();
                        }
                        else
                        {
                            Toast.MakeText(this, "El nombre de usuario, contraseña o id no pueden estar vacios", ToastLength.Short).Show();
                        }
                    }

                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
                }
            });
            builder.SetNegativeButton("Cancel", (s, e) => { });
            builder.Show();
        }

        private void BtnConsult_Click(object sender, EventArgs e)
        {
            try
            {
                Login resultado = null;
                if (!string.IsNullOrEmpty(txtId.Text.Trim()))
                {
                    resultado = new Auxiliar().Consulta(int.Parse(txtId.Text.Trim()));
                    if (resultado != null)
                    {
                        txtUser.Text = resultado.UserName.ToString();
                        txtPassword.Text = resultado.Password.ToString();
                        Toast.MakeText(this, "Consulta realizada con exito", ToastLength.Short).Show();
                    }
                    else
                    {
                        Toast.MakeText(this, "No se han encontrado datos asociados al Id", ToastLength.Long).Show();
                        txtUser.Text = "";
                        txtPassword.Text = "";
                    }
                }
                else
                {
                    Toast.MakeText(this, "El campo Id NO debe estar vacio", ToastLength.Long).Show();
                    txtUser.Text = "";
                    txtPassword.Text = "";
                }

            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}