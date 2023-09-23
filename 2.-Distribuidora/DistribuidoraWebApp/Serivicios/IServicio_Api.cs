using DistribuidoraEntidades;

namespace DistribuidoraWebApp.Serivicios
{
    public interface IServicio_Api
    {
        Task<List<Producto>> obtenerProductos();
        Task<bool> guardarProducto(Producto producto);
        Task<bool> actualizarProducto(Producto producto);
        Task<bool> eliminarProducto(int producto);
        Task<Producto> obtenerProductosById(int IdProducto);

    }
}
