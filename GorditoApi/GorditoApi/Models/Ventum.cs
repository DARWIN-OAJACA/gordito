using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GorditoApi.Models
{
    public partial class Ventum
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int IdProducto { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Producto? IdProductoNavigation { get; set; }
    }
}
