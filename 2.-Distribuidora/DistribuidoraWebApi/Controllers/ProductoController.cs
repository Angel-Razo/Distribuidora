using DistribuidoraEntidades;
using Microsoft.AspNetCore.Mvc;
using DistribuidoraDatos.Repositorio;

namespace DistribuidoraWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProductoRepositorio _producto;

        public ProductoController(IProductoRepositorio productoRepositorio)
        {
            _producto = productoRepositorio;
        }

        [HttpGet("Obtener")]
        public Task<List<Producto>> get()
        {
            return _producto.OptenerProducto();
        }
        [HttpPost]
        public Task<bool> post([FromBody]Producto producto)
        {
            return _producto.crearProducto(producto);
        }

        [HttpDelete("{idProducto:int}")]
        public Task<bool> delete(int idProducto)
        {
            return _producto.eliminarProducto(idProducto);
        }
    }
}
