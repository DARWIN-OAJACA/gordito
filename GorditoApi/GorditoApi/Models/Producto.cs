using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GorditoApi.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Venta = new HashSet<Ventum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Disponibilidad { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
