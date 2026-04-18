using Microsoft.AspNetCore.Mvc;
using Lab4_Productos__C00888.Models;

namespace Lab4_Productos__C00888.Controllers
{
    public class ProductosController : Controller
    {
        // GET: /Productos
        public IActionResult Index()
        {
            var productos = ProductoRepositorio.ObtenerTodos();
            return View(productos);
        }

        // GET: /Productos/Detalles/1
        public IActionResult Detalles(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // GET: /Productos/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: /Productos/Crear
        [HttpPost]
        public IActionResult Crear(Producto p)
        {
            if (!ModelState.IsValid)
                return View(p);

            ProductoRepositorio.Agregar(p);
            return RedirectToAction("Index");
        }

        // GET: /Productos/Editar/1
        public IActionResult Editar(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: /Productos/Editar
        [HttpPost]
        public IActionResult Editar(Producto p)
        {
            if (!ModelState.IsValid)
                return View(p);

            ProductoRepositorio.Actualizar(p);
            return RedirectToAction("Index");
        }

        // GET: /Productos/Eliminar/1
        public IActionResult Eliminar(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: /Productos/Eliminar/1
        [HttpPost]
        public IActionResult EliminarConfirmado(int id)
        {
            ProductoRepositorio.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
