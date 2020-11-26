using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LaArtistica.Models
{
    [Table("Wishlist")]
    class Wishlist
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public int Cliente { get; set; }

        [MaxLength(100)]
        public String Nombre { get; set; }

        [MaxLength(100)]
        public String Stock { get; set; }

        [MaxLength(100)]
        public String Precio { get; set; }

        [MaxLength(100)]
        public String GarantiaMeses { get; set; }

        public String Imagen { get; set; }
    }
}
