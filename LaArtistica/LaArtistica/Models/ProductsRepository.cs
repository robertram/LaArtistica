using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;
using LaArtistica.Models;

namespace LaArtistica.Models
{
    class ProductsRepository
    {
        private SQLiteConnection con;

        private static ProductsRepository instancia;

        public static ProductsRepository Instancia
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
            instancia = new ProductsRepository(filename);
        }
        private ProductsRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Products>();
        }

        public string EstadoMensaje;
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
                }); ;
                EstadoMensaje = "Insertado";
            }


            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        //Select
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

        public IEnumerable<Products> GetSelectedProduct(string nombre, string imagen)
        {
            try
            {
                return con.Query<Products>("select * from Products where Nombre=? and Imagen=?", nombre, imagen);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Products>();
        }

    }
}
