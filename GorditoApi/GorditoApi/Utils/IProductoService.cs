using GorditoApi.Models;

namespace GorditoApi.Utils
{
    public interface IProductoService
    {
        Task<List<Producto>> GetProductos();
        Task<Producto> GetProductoPorId(int id);
        Task<Producto> PostProducto(Producto producto);

        Task<Producto> PutProducto(Producto producto);
    }
}
