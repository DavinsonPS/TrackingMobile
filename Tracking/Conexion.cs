using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Java.Util;

namespace Tracking
{
    public class Producto
    {
        public string Codigo { get; set; }
        [MaxLength(20)]

        public int Total { get; set; }
        [MaxLength(20)]

        public int Proveedor { get; set; }
        [MaxLength(11)]

        public int Name { get; set;}
        [MaxLength(30)]

        public DateTime Date { get; set;}

        public string Observations { get; set; }
        
    }
    public class Login
    {
        public Login() { }

        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        [MaxLength(50)]

        public string UserName { get; set; }
        [MaxLength(20)]

        public string Password { get; set; }
    }

    public class CreateContact
    {
        public CreateContact() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Email { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        [MaxLength(10)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Message { get; set;}
    }

    public class Auxiliar
    {
        static object locker = new object();
        SQLiteConnection conexion;

        public Auxiliar()
        {
            conexion = Conectar();
            conexion.CreateTable<Login>();
            conexion.CreateTable<CreateContact>();
        }

        public SQLite.SQLiteConnection Conectar()
        {
            SQLiteConnection conexionAuxiliar;
            string nombreArchivo = "tdea.db3"; //nombre de la base de datos
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string rutaCompleta = Path.Combine(ruta, nombreArchivo);
            conexionAuxiliar = new SQLiteConnection(rutaCompleta);
            return conexionAuxiliar;
        }

        #region Manejo de los datos Login
        //El manejo de los datos
        //Seleccionar todo
        public IEnumerable<Login> SeleccionarTodo()
        {
            lock (locker)
            {
                return (from i in conexion.Table<Login>() select i).ToList();
            }
        }
        //Seleccionar un registro
        public Login SeleccionarUno(string userName, string password)
        {
            lock (locker)
            {
                return conexion.Table<Login>().FirstOrDefault(x => x.UserName == userName && x.Password == password);
            }
        }
        //Seleccionar un registro de contact
        public CreateContact SeleccionarUnContact(int Id)
        {
            lock (locker)
            {
                return conexion.Table<CreateContact>().FirstOrDefault(x => x.Id == Id);
            }
        }
        //Seleccionar todos los registros de Contact
        public IEnumerable<CreateContact> SeleccionarTodosContact()
        {
            lock (locker)
            {
                return (from i in conexion.Table<CreateContact>() select i).ToList();
            }
        }
        //Guardar
        //Actualizar o insertar
        public int Guardar(Login registro)
        {
            lock (locker)
            {
                if (registro.Id == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }
        //Eliminar
        public int Eliminar(int ID)
        {
            lock (locker)
            {
                return conexion.Delete<Login>(ID);
            }
        }
        #endregion
        //Guardar Contact
        //Actualizar o insertar
        public int GuardarContact(CreateContact contact)
        {
            lock (locker)
            {
                if (contact.Id == 0)
                {
                    return conexion.Insert(contact);
                }
                else
                {
                    return conexion.Update(contact);
                }
            }
        }

        //Eliminar Contact
        public int EliminarContact(int ID)
        {
            lock (locker)
            {
                return conexion.Delete<CreateContact>(ID);
            }
        }
    }
}