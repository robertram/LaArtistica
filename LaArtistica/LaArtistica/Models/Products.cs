using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LaArtistica.Models
{
    [Table("Products")]
    public class Products
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public String Nombre { get; set; }

        [MaxLength(100)]
        public String Stock { get; set; }

        [MaxLength(100)]
        public String Precio { get; set; }

        [MaxLength(100)]
        public String GarantiaMeses { get; set; }

        public String Imagen { get; set; }

        public String Descripcion { get; set; }
    }
}
