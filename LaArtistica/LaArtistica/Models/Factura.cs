using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LaArtistica.Models
{

    [Table("Factura")]
    class Factura
    {
        [PrimaryKey, AutoIncrement]
        public int Factura_Id { get; set; }

        [MaxLength(100)]
        public String Cliente { get; set; }

        [MaxLength(100)]
        public String Producto_ID { get; set; }

        [MaxLength(100)]
        public String Cantidad { get; set; }

        [MaxLength(100)]
        public String Impuesto { get; set; }

        [MaxLength(100)]
        public String PrecioFinal { get; set; }

        [MaxLength(100)]
        public String Fecha { get; set; }

        [MaxLength(100)]
        public String GarantiaAplicada { get; set; }

        [MaxLength(100)]
        public String EsAbono { get; set; }

        [MaxLength(100)]
        public String DineroPorAbonar { get; set; }

        [MaxLength(100)]
        public String TasaDeInteres { get; set; }

        [MaxLength(100)]
        public String DineroAbonado { get; set; }


    }
}
