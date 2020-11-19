using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using LaArtistica.Models;

namespace LaArtistica.Models
{
     class UserRepository
    {
        private SQLiteConnection con;

        private static UserRepository instancia;

        public static UserRepository Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al inicializador, acción detenida");
                return instancia;
            }
        }
        public static void Inicializador(String filename)
        {
            if (filename == null)
            {
                throw new ArgumentException();
            }
            if (instancia != null)
            {
                instancia.con.Close();
            }
            instancia = new UserRepository(filename);
        }
        private UserRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<User>(); 
            con.CreateTable<Products>();
        }

        public string EstadoMensaje;
        // Insert
        public int AddNewUser(string email, string password)
        {
            int result = 0;
            try
            {
                result = con.Insert(new User
                {
                    Email = email,
                    Password = password
                });
                EstadoMensaje = "Insertado";
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }
        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return con.Table<User>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<User>();
        }


        //-----------------------------------------------

        

        // Insert
        public int AddNewProduct(string nombre, string stock, string precio, string garantiaMeses, string imagen)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Products
                {
                    Nombre = nombre,
                    Stock = stock,
                    Precio = precio,
                    GarantiaMeses = garantiaMeses,
                    Imagen = imagen
                });
                EstadoMensaje = "Insertado";
            }


            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }
        public IEnumerable<Products> GetAllProducts()
        {
            try
            {
                return con.Table<Products>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Products>();
        }

    }
}
