using GorditoApi.Models;
using GorditoApi.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GorditoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }


        // GET: api/<VentaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ventas = await _ventaService.GetVentas();

            return Ok(ventas);
        }

        // GET api/<VentaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var venta = await _ventaService.GetVentaPorId(id);
            if (venta is null || venta.Id == 0)
                return BadRequest(venta);

            return Ok(venta);
        }

        // POST api/<VentaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ventum model)
        {
            var venta = await _ventaService.PostVenta(model);
            if (venta is null || venta.Id == 0)
                return BadRequest(venta);

            return Ok(venta);
        }

        //[HttpPost("Post1")]
        //public async Task<IActionResult> Post1([FromBody] Ventum model)
        //{
        //    var venta = await _ventaService.PostVenta(model);
        //    if (venta is null || venta.Id == 0)
        //        return BadRequest(venta);

        //    return Ok(venta);
        //}

        // PUT api/<VentaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Ventum model)
        {
            var venta = await _ventaService.PutVenta(model);

            if (venta is null || venta.Id == 0)
                return BadRequest(venta);

            return Ok(venta);
        }

        // DELETE api/<VentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
