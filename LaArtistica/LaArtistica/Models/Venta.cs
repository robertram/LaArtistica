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
    }
}
