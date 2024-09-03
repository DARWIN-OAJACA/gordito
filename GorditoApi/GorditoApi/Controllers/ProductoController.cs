using GorditoApi.BLL;
using GorditoApi.Models;
using GorditoApi.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GorditoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = await _productoService.GetProductos();

            return (Ok(productos));
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _productoService.GetProductoPorId(id);

            return (Ok(producto));
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto model)
        {
            if(model is null)
                return BadRequest(ModelState);

            var producto = await _productoService.PostProducto(model);
            return Ok(producto);
        }

        // PUT api/<ProductoController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Producto model)
        {
            if(model is null)
                return BadRequest(ModelState);

            var producto = await _productoService.PutProducto(model);
            if(producto.Id == 0)
                return BadRequest(ModelState);
            else
                return Ok(producto);
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
