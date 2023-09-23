using DistribuidoraEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraDatos.Repositorio
{
    public interface IProductoRepositorio
    {
        Task<List<Producto>> OptenerProducto();
        Task<Producto> OptenerProductoById(int idProducto);
        Task<bool> eliminarProducto(int idProducto);
        Task<bool> crearProducto(Producto producto);
    }
}
