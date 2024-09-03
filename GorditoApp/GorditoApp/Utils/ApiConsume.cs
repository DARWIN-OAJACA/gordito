using GorditoApp.Models;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;

namespace GorditoApp.Utils
{
    public class ApiConsume
    {
        private const string link = "https://localhost:7160/api/";
        #region PRODUCTO
        public async Task<List<Producto>> GetProductos()
        {
            List<Producto> productos = new();
            using (var httpClient = new HttpClient())
            {
                string url = link + "producto";
                using (var response = await httpClient.GetAsync(url))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    productos = JsonConvert.DeserializeObject<List<Producto>>(result);
                }
            }

            return productos;
        }
        public async Task<Producto> GetProductoPorId(int id)
        {
            Producto producto = new();
            using (var httpClient = new HttpClient())
            {
                string url = link + $"producto/{id}";
                using (var response = await httpClient.GetAsync(url))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    producto = JsonConvert.DeserializeObject<Producto>(result);
                }
            }

            return producto;
        }
        #endregion

        #region VENTA
        public async Task<List<Ventum>> GetVentas()
        {
            List<Ventum> ventas = new();
            using (var httpClient = new HttpClient())
            {
                string url = $"{link}venta";
                using (var response = await httpClient.GetAsync(url))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    ventas = JsonConvert.DeserializeObject<List<Ventum>>(result);
                }
            }

            for (int i = 0; i < ventas.Count; i++)
            {
                var venta = ventas[i];
                var producto = await GetProductoPorId(venta.IdProducto);
                ventas[i].producto = producto ?? new Producto();
            }

            return ventas;
        }

        public async Task<Ventum> GetVentaPorId(int id)
        {
            Ventum venta = new();
            using (var httpClient = new HttpClient())
            {
                string url = $"{link}venta/{id}";
                using (var response = await httpClient.GetAsync(url))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    venta = JsonConvert.DeserializeObject<Ventum>(result);
                }
            }

            return venta;
        }

        public async Task<Ventum> PostVenta(Ventum model)
        {
            Ventum venta = new();

            using (var httpClient = new HttpClient())
            {
                string url = $"{link}venta";
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(url, content))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    venta = JsonConvert.DeserializeObject<Ventum>(result);
                }
            }

            return venta;
        }

        public async Task<Ventum> PutVenta(int id, Ventum model)
        {
            Ventum venta = new();

            using(var httpClient = new HttpClient())
            {
                string url = $"{link}venta/{id}";
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync(url, content))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    venta = JsonConvert.DeserializeObject<Ventum>(result);
                }
            }

            return venta;
        }
        #endregion
    }
}
