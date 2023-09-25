using DistribuidoraEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraDatos.Repositorio
{
    public interface IProveedorRepositorio
    {
        Task<List<Proveedor>> OptenerProveedor();

        Task<bool> crearProveedor(Proveedor proveedor);
    }
}
