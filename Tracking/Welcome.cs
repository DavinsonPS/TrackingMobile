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
using Toolbar = Android.Widget.Toolbar;

namespace Tracking
{
    [Activity(Label = "Welcome")]
    public class Welcome : Activity
    {
        Toolbar toolbarmenu;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Welcome);
            toolbarmenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);

            SetActionBar(toolbarmenu);
            ActionBar.Title = "Menu";
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.icAdd:
                    Intent i = new Intent(this, typeof(AddUser));
                    StartActivity(i);
                    break;

                case Resource.Id.icAdd2:
                    Intent j = new Intent(this, typeof(Create_OC));
                    StartActivity(j);
                    break;

                case Resource.Id.icAdd3:
                    Intent a = new Intent(this, typeof(Proveedores));
                    StartActivity(a);
                    break;

                case Resource.Id.icAdd4:
                    Intent b = new Intent(this, typeof(Ventas));
                    StartActivity(b);
                    break;

                case Resource.Id.icAdd5:
                    Intent c = new Intent(this, typeof(Productos));
                    StartActivity(c);
                    //SetContentView(Resource.Layout.Productos);
                    break;

                case Resource.Id.icAdd6:
                    Intent d = new Intent(this, typeof(contact));
                    StartActivity(d);
                    break;

                default:
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}