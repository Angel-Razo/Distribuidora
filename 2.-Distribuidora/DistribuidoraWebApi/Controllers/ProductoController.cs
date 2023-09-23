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

        [HttpGet]
        public Task<List<Producto>> get()
        {
            return _producto.OptenerProducto();
        }
    }
}
