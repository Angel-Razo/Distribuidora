using DistribuidoraEntidades;
using DistribuidoraWebApp.Models;
using DistribuidoraWebApp.Serivicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DistribuidoraWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicio_Api _servicio_Api;

        public HomeController(IServicio_Api servicio_Api)
        {
            _servicio_Api = servicio_Api;
        }

        public async Task<IActionResult> Index()
        {

            List<Producto> productos = await _servicio_Api.obtenerProductos();


            return View(productos);
        }
        public async Task<List<Proveedor>> obtenerProveedores()
        {

            List<Proveedor> response = await _servicio_Api.obtenerProveedor();


            return response;
        }

        public async Task<IActionResult> producto(int idProducto)
        {
            Producto producto=new Producto();

            if (idProducto > 0)
            {
                producto = await _servicio_Api.obtenerProductosById(idProducto);

                ViewBag.Accion = "Nuevo Producto";
            }

            return View(producto);
        }


        public async Task<IActionResult> guardarProducto(Producto producto)
        {

            bool respose = await _servicio_Api.guardarProducto(producto);

            if (respose)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NoContent();
            }
        }

        public async Task<IActionResult> guardarProveedor(Proveedor proveedor)
        {

            bool respose = await _servicio_Api.guardarProveedor(proveedor);

            if (respose)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NoContent();
            }
        }
        public async Task<IActionResult> eliminarproducto(int idProducto)
        {

            var respose = await _servicio_Api.eliminarProducto(idProducto);

            if (respose)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NoContent();
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}