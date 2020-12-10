using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using LaArtistica.Models;
using System.Linq;

namespace LaArtistica.Models
{
    class VentaRepository
    {
        private SQLiteConnection con;

        private static VentaRepository instancia;

        public static VentaRepository Instancia
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
            instancia = new VentaRepository(filename);
        }
        private VentaRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Venta>();
        }

        public string EstadoMensaje;
        // Insert
        public int AddNewVenta(int user, int product)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Venta
                {
                    UserID = user,
                    ProductoID= product
                });
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
                return con.Query<Venta>("SELECT ProductoID FROM Venta WHERE UserID = ?",user);
            }
            catch(Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Venta>();
        }
    }
}
