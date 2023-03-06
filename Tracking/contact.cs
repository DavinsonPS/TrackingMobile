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
        EditText txtEMail;
        EditText txtMessage;
        Button btnSend;
        Button btnCancel;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            txtCompleteName = FindViewById<EditText>(Resource.Id.txtCompleteName);
            txtPhone = FindViewById<EditText>(Resource.Id.txtCelPhone);
            txtEMail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtMessage = FindViewById<EditText>(Resource.Id.txtMessage);
            
            btnCancel = FindViewById<Button>(Resource.Id.btnCancel);

            
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            /*Intent i = new Intent(this, typeof(Welcome));
            StartActivity(i);*/
            SetContentView(Resource.Layout.Welcome);
        }

        
    }
}