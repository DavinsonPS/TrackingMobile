using Android.App;
using Android.Content;
using Android.OS;
using Android.Renderscripts;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracking
{
    [Activity(Label = "Notification")]
    public class Notification : Activity
    {
        public List<CreateContact> NotificationsList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Notifications);

            NotificationsList = new Auxiliar().SeleccionarTodosContact().ToList();
            var layout = FindViewById<LinearLayout>(Resource.Id.layoutNotification);
            var inflater = LayoutInflater.FromContext(this); 
            foreach (var contact in NotificationsList)
            {
                var vistaLayout = inflater.Inflate(Resource.Layout.Notifications, null);
                var name = vistaLayout.FindViewById<TextView>(Resource.Id.txtName);
                var cel = vistaLayout.FindViewById<TextView>(Resource.Id.txtPhone);
                var email = vistaLayout.FindViewById<TextView>(Resource.Id.txtEmail);
                var message = vistaLayout.FindViewById<TextView>(Resource.Id.txtMessage);
                var button = vistaLayout.FindViewById<Button>(Resource.Id.btnDeleteM);

                name.Text = contact.Name;
                cel.Text = contact.PhoneNumber;
                email.Text = contact.Email;
                message.Text = contact.Message;
                
                name.Visibility = ViewStates.Visible;
                cel.Visibility = ViewStates.Visible;
                email.Visibility = ViewStates.Visible;
                message.Visibility = ViewStates.Visible;
                button.Visibility = ViewStates.Visible;

                button.Click += (sender, args) =>
                {
                    AlertDialog.Builder builder = new AlertDialog.Builder(this);
                    builder.SetTitle("Confirmación");
                    builder.SetMessage("¿Desea eliminar el registro?");
                    builder.SetPositiveButton("Acept", (s, e) =>
                    {
                        try
                        {
                            new Auxiliar().EliminarContact(contact.Id);
                            Toast.MakeText(this, "Registro eliminado con exito", ToastLength.Long).Show();
                            Recreate();
                        }
                        catch (System.Exception ex)
                        {
                            Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
                        }
                    });
                    builder.SetNegativeButton("Cancel", (s, e) => { });
                    builder.Show();
                };
                layout.AddView(vistaLayout);
            }
        }
    }
}