using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LaArtistica.Models
{
    [Table("Venta")]
    public class Venta
    {
        [PrimaryKey, AutoIncrement]
        public int VentaID { get; set; }
        public int UserID { get; set; }
        public int ProductoID { get; set; }
        public int Plazo { get; set; }

        [MaxLength(255)]
        public String Fecha_Compra { get; set; }
    }
}
