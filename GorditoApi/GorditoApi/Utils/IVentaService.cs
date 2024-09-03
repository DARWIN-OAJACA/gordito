using GorditoApi.Models;

namespace GorditoApi.Utils
{
    public interface IVentaService
    {
        Task<List<Ventum>> GetVentas();
        Task<Ventum> GetVentaPorId(int id);
        Task<Ventum> PostVenta(Ventum Venta);

        Task<Ventum> PutVenta(Ventum Venta);
    }
}
