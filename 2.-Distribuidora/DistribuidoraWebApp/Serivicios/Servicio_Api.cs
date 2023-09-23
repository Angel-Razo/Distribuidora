using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using DistribuidoraEntidades;

namespace DistribuidoraWebApp.Serivicios
{
    public class Servicio_Api:IServicio_Api
    {
        private static string _distribuidoraWebApi;

        public Servicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _distribuidoraWebApi = builder.GetSection("ApiSettings:DistribuidoraWebApi").Value;
        }

        public async Task<List<Producto>> obtenerProductos()
        {
            List<Producto> productos = new List<Producto>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_distribuidoraWebApi);
            var response = await cliente.GetAsync("Producto/Obtener");

            if (response.IsSuccessStatusCode)
            {
                var jsonresponse=await response.Content.ReadAsStringAsync();
                var result=JsonConvert.DeserializeObject<List<Producto>>(jsonresponse);
                productos = result;
            }
            return productos;
        }
        public async Task<bool> guardarProducto(Producto producto)
        {
            bool respose = false;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_distribuidoraWebApi);

            var content=new StringContent (JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("Producto",content);

            if (response.IsSuccessStatusCode)
            {
                respose = true;
            }
            return respose;
        }
        public async Task<bool> eliminarProducto(int producto)
        {
            bool productos = false;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_distribuidoraWebApi);
            var response = await cliente.DeleteAsync($"Producto/{producto}");

            if (response.IsSuccessStatusCode)
            {
               
                productos = true;
            }
            return productos;
        }

        public Task<bool> actualizarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public async Task<Producto> obtenerProductosById(int IdProducto)
        {
            Producto producto = new Producto();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_distribuidoraWebApi);
            var response = await cliente.GetAsync($"api/Producto{IdProducto}");

            if (response.IsSuccessStatusCode)
            {
                var jsonresponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Producto>(jsonresponse);
                producto = result;
            }
            return producto;

        }


    }
}
