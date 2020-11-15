using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LaArtistica.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50), Unique]
        public String Username { get; set; }

        [MaxLength(50), Unique]
        public String Email { get; set; }

        [MaxLength(50)]
        public String Password { get; set; }




    }
}
