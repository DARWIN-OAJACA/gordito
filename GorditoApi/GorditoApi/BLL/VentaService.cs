using GorditoApi.Models;
using GorditoApi.Utils;
using Microsoft.EntityFrameworkCore;

namespace GorditoApi.BLL
{
    public class VentaService : IVentaService
    {
        private readonly TiendaContext _context;

        public VentaService(TiendaContext context)
        {
            _context = context;
        }

        public async Task<Ventum> GetVentaPorId(int id)
        {
            var venta = await _context.Set<Ventum>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return venta ?? new Ventum();
        }

        public async Task<List<Ventum>> GetVentas()
        {
            var ventas = await _context.Set<Ventum>().AsNoTracking().ToListAsync();

            return ventas ?? new List<Ventum>();
        }

        public async Task<Ventum> PostVenta(Ventum Venta)
        {
            await _context.Set<Ventum>().AddAsync(Venta);
            await _context.SaveChangesAsync();

            return Venta;
        }

        public async Task<Ventum> PutVenta(Ventum Venta)
        {
            var model = await GetVentaPorId(Venta.Id);
            if (model is null || model.Id == 0)
                return new Ventum();

            _context.Set<Ventum>().Update(Venta);
            _context.SaveChanges();

            return Venta;
        }
    }
}
