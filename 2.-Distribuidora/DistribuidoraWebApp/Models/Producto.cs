namespace DistribuidoraWebApp.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public bool EsActivo { get; set; }
        public int IdProveedor { get; set; }
        public decimal Precio { get; set; }
        public int IdTipoProducto { get; set; }
    }
}
