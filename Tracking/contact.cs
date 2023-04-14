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
    [Activity(Label = "contact")]
    public class contact : Activity
    {
        EditText txtCompleteName;
        EditText txtPhone;
        EditText txtEmail;
        EditText txtMessage;
        Button btnSend;
        Button btnCancel;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.contact);
            txtCompleteName = FindViewById<EditText>(Resource.Id.txtCompleteNameC);
            txtPhone = FindViewById<EditText>(Resource.Id.txtCelPhoneC);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmailC);
            txtMessage = FindViewById<EditText>(Resource.Id.txtMessageC);
            
            btnCancel = FindViewById<Button>(Resource.Id.btnCancelC);
            btnSend = FindViewById<Button>(Resource.Id.btnSendC);

            btnCancel.Click += BtnCancel_Click;
            btnSend.Click += BtnSend_Click;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Confirmación");
            builder.SetMessage("¿Desea enviar el formulario?");
            builder.SetPositiveButton("Acept", (s, e) =>
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtCompleteName.Text.Trim()) && !string.IsNullOrEmpty(txtPhone.Text.Trim()) && !string.IsNullOrEmpty(txtEmail.Text.Trim()) && !string.IsNullOrEmpty(txtMessage.Text.Trim()))
                    {
                        new Auxiliar().GuardarContact(new CreateContact()
                        {
                            Id = 0,
                            Name = txtCompleteName.Text.Trim(),
                            PhoneNumber = txtPhone.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            Message = txtMessage.Text.Trim(),
                        });
                        Toast.MakeText(this, "Registro exitoso", ToastLength.Long).Show();
                        //Para limpiar campos
                        txtCompleteName.Text = "";
                        txtPhone.Text = "";
                        txtEmail.Text = "";
                        txtMessage.Text = "";

                    }
                    else
                    {
                        Toast.MakeText(this, "Por favor complete todos los campos", ToastLength.Long).Show();
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Intent j = new Intent(this, typeof(Welcome));
            StartActivity(j);
        }
    }
}