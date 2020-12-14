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
            con.CreateTable<Venta>();
        }

        public string EstadoMensaje;
        // Insert
        public int AddNewUser(string email, string password,string username)
        {
            int result = 0;
            try
            {
                result = con.Insert(new User
                {
                    Email = email,
                    Password = password,
                    Username = username
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

        //DELETE
        public int DeleteProduct(Products p)
        {
            int result = 0;
            try
            {
                result = con.Delete(p);
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public IEnumerable<Wishlist> DeleteWish(string nombre)
        {
                return con.Query<Wishlist>("DELETE FROM Wishlist WHERE = Nombre '" + nombre+"'").AsEnumerable();
        }


        //-----------------------------------------------



        // Insert
        public int AddNewProduct(int id,string nombre, string stock, string precio, string garantiaMeses, string descripcion, string imagen, string imagenUrl)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Products
                {
                    Id = id,
                    Nombre = nombre,
                    Stock = stock,
                    Precio = precio,
                    GarantiaMeses = garantiaMeses,
                    Imagen = imagen,
                    ImagenUrl = imagenUrl,
                    Descripcion = descripcion
                }); ; ;
                EstadoMensaje = "Insertado";
            }


            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public int AddtoWishlist(string nombre,int client_id, string stock, string precio, string garantiaMeses, string imagen)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Wishlist
                {
                    Nombre = nombre,
                    Cliente = client_id,
                    Stock = stock,
                    Precio = precio,
                    GarantiaMeses = garantiaMeses,
                    Imagen = imagen
                }); ;
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

        public IEnumerable<Products> GetProductsForReport(List<int> ids)
        {
            try
            {
                string v = string.Join(",", ids);
                string query = "SELECT * FROM Products WHERE Id IN (";
                for(int i = 0; i < ids.Count(); i++)
                {
                    if(ids.Count - 1 == i)
                    {
                        query += ids[i];
                    }
                    else
                    {
                        query += ids[i] + ",";
                    }
                    
                }
                query += ")";
                Console.WriteLine(query);
                return con.Query<Products>(query);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Products>();
        }

        public IEnumerable<Wishlist> GetAllWishes(int id)
        {
            try
            {
                return con.Query<Wishlist>("Select * from Wishlist Where Cliente = "+id);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Wishlist>();
        }

        public IEnumerable<Wishlist> GetAllUsersWishes2()
        {
            try
            {
                return con.Table<Wishlist>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Wishlist>();
        }

        //Updates
        public IEnumerable<User> getUser(string newPassword, string email)
        {
            return con.Query<User>("UPDATE User SET Password = '"+newPassword+ "' where Email = '"+email+"'").AsEnumerable();
        }

        //Select
        public string getUsername(string email)
        {
            string resultado =  con.Query<User>("Select Username FROM User Where Email = '"+email+"'").AsEnumerable().ToString();
            return resultado;
        }

        public IEnumerable<User> getUsername2(string email)
        {
            return con.Query<User>("Select Username FROM User Where Email = '" + email + "'").ToArray();
        }


        ///Ventas
        public int AddNewVenta(int user, int product, string date, int plazo )
        {
            int result = 0;
            try
            {
                result = con.Insert(new Venta
                {
                    UserID = user,
                    ProductoID = product,
                    Fecha_Compra = date,
                    Plazo = plazo
                }); ;
                EstadoMensaje = "Insertado";
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }
        public IEnumerable<Venta> GetAllVentas()
        {
            try
            {
                return con.Table<Venta>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Venta>();
        }

        public IEnumerable<Venta> GetVentasReport(int user)
        {
            try
            {
                return con.Query<Venta>("SELECT ProductoID, VentaID, UserID, Fecha_Compra, Plazo FROM Venta WHERE UserID = ?", user);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Venta>();
        }
    }
}
