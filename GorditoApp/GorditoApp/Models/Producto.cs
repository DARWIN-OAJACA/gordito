using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GorditoApp.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Disponibilidad { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }

        public List<Ventum> Venta { get; set; }
    }
}
