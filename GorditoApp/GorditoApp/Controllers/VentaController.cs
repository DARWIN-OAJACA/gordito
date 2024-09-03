using GorditoApp.Models;
using GorditoApp.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GorditoApp.Controllers
{
    public class VentaController : Controller
    {
        ApiConsume api = new ApiConsume();

        // GET: VentaController
        public async Task<IActionResult> Index()
        {
            var ventas = await api.GetVentas();

            return View(ventas);
        }

        // GET: VentaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var venta = await api.GetVentaPorId(id);

            return View(venta);
        }

        public async Task<JsonResult> ObtenerProducto(int id)
        {
            var producto = await api.GetProductoPorId(id);

            return Json(producto);
        }

        // GET: VentaController/Create
        public async Task<IActionResult> Create()
        {
            var venta = new Ventum();
            venta.Fecha = DateTime.Now;
            var productos = await api.GetProductos();
            productos.Add(new Producto() { Id = 0, Nombre = "" });

            ViewBag.Productos = new SelectList(productos.OrderBy(x => x.Nombre), "Id", "Nombre");
            return View(venta);
        }

        // POST: VentaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public async Task<IActionResult> Create(Ventum model)
        {
            try
            {
                var venta = await api.PostVenta(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VentaController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var venta = await api.GetVentaPorId(id);

            var productos = await api.GetProductos();
            productos = productos.Where(x => x.Id == venta.IdProducto).ToList();

            ViewBag.Productos = new SelectList(productos.OrderBy(x => x.Nombre), "Id", "Nombre", venta.IdProducto);

            return View(venta);
        }

        // POST: VentaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ventum model)
        {
            try
            {
                var venta = await api.PutVenta(id, model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VentaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VentaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
