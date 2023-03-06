using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace Tracking
{
    [Activity(Label = "Tracking", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText txtUsuario;
        EditText txtPassword;
        Button btnLogin;
        Button btnRegister;
        string user;
        string password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            txtUsuario = FindViewById<EditText>(Resource.Id.txtUserName);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegisterUser);
            user = "admin";
            password= "admin";

            btnLogin.Click += BtnLogin_Click;
            btnRegister.Click += BtnRegister_Click;
        }

        private void BtnRegister_Click(object sender, System.EventArgs e)
        {
            SetContentView(Resource.Layout.AddUser);
            /*Intent i = new Intent(this, typeof(AddUser));
            StartActivity(i);*/
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            if(txtUsuario.Text == user && txtPassword.Text == password)
            {
                Intent i = new Intent(this, typeof(Welcome));
                StartActivity(i);
                
            }
            else
            {
                Toast.MakeText(this, "Nombre de usuario y/o clave inválida(s)", ToastLength.Long).Show();
            }


            /*try
            {
                Login resultado = null;
                if (!string.IsNullOrEmpty(txtUsuario.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    resultado = new Auxiliar().SeleccionarUno(txtUsuario.Text.Trim(), txtPassword.Text.Trim());
                    if (resultado != null)
                    {
                        txtUsuario.Text = resultado.UserName.ToString();
                        Toast.MakeText(this, "Login realizado con exito", ToastLength.Short).Show();
                        var bienvenido = new Intent(this, typeof(Welcome));
                        bienvenido.PutExtra("usuario", FindViewById<EditText>(Resource.Id.txtUserName).Text);
                        StartActivity(bienvenido);
                        Finish();
                    }
                    else
                    {
                        Toast.MakeText(this, "Nombre de usuario y/o clave inválida(s)", ToastLength.Long).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "Nombre de usuario y/o clave son vacios", ToastLength.Long).Show();
                }

            }
            catch
            {

            }*/
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}