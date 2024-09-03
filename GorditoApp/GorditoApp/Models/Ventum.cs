using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GorditoApp.Models
{
    public class Ventum
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Cantidad")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "Debe ingresar la cantidad")]
        public int Cantidad { get; set; }
        [DisplayName("Fecha")]
        public DateTime Fecha { get; set; }
        [DisplayName("Precio Costo")]
        [Range(0.1, Double.PositiveInfinity, ErrorMessage = "Debe seleccionar un producto primero")]
        public decimal PrecioCosto { get; set; }
        [DisplayName("Precio Venta")]
        [Range(0.1, Double.PositiveInfinity, ErrorMessage = "Debe ingresar el precio venta del producto")]
        public decimal PrecioVenta { get; set; }

        [DisplayName("Id Producto")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "Debe seleccionar un producto")]
        public int IdProducto { get; set; }

        [DisplayName("Producto")]
        public Producto? producto { get; set; }
    }
}
