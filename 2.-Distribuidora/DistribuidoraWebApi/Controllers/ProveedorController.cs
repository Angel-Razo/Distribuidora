using DistribuidoraDatos.Repositorio;
using DistribuidoraEntidades;
using Microsoft.AspNetCore.Mvc;

namespace DistribuidoraWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProveedorController : Controller
    {
        private readonly IProveedorRepositorio _proveedor;

        public ProveedorController(IProveedorRepositorio proveedorRepositorio)
        {
            _proveedor = proveedorRepositorio;
        }

        [HttpGet("Obtener")]
        public Task<List<Proveedor>> get()
        {
            return _proveedor.OptenerProveedor();
        }

        [HttpPost]
        public Task<bool> post(Proveedor proveedor)
        {
            return _proveedor.crearProveedor(proveedor);
        }
    }
}
