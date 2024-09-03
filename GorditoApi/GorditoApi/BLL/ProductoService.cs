using GorditoApi.Models;
using GorditoApi.Utils;
using Microsoft.EntityFrameworkCore;

namespace GorditoApi.BLL
{
    public class ProductoService : IProductoService
    {
        private readonly TiendaContext _context;

        public ProductoService(TiendaContext context)
        {
            _context = context;
        }

        public async Task<Producto> GetProductoPorId(int id)
        {
            var producto = await _context.Set<Producto>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return producto ?? new Producto();
        }

        public async Task<List<Producto>> GetProductos()
        {
            var productos = await _context.Set<Producto>().AsNoTracking().ToListAsync();

            return productos ?? new List<Producto>();
        }

        public async Task<Producto> PostProducto(Producto producto)
        {
            await _context.Set<Producto>().AddAsync(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        public async Task<Producto> PutProducto(Producto producto)
        {
            var model = await GetProductoPorId(producto.Id);
            if(model is null || model.Id == 0)
            {
                return new Producto();
            }
            _context.Set<Producto>().Update(producto);
            //var entity = _context.Set<Producto>().Update(producto);
            //entity.Property(x => x.Nombre).IsModified = false;

            _context.SaveChanges();

            return producto;
        }
    }
}
