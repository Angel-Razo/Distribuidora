using DistribuidoraDatos.Repositorio;
using DistribuidoraEntidades;
using Microsoft.AspNetCore.Mvc;

namespace DistribuidoraWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoProductoController : Controller
    {

        private readonly ITipoProductoRepositorio _tipoProductoRepositorio;

        public TipoProductoController(ITipoProductoRepositorio tipoProductoRepositorio)
        {
            _tipoProductoRepositorio = tipoProductoRepositorio;
        }

        [HttpGet("Obtener")]
        public Task<List<TipoProducto>> get()
        {
            return _tipoProductoRepositorio.OptenerTipoProducto();
        }
    }
}
