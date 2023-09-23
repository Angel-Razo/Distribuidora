using DistribuidoraEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using DistribuidoraDatos.Configracion;

namespace DistribuidoraDatos.Repositorio
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly ConfiguracionConexion _configuracionConexion;

        public ProductoRepositorio(IOptions<ConfiguracionConexion> configuracion)
        {
            _configuracionConexion = configuracion.Value;
        }
        public async Task<List<Producto>> OptenerProducto()
        {
            List<Producto> producto = new List<Producto>();
            using(var conexion=new SqlConnection(_configuracionConexion.CadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("dbo.Usp_Productor_Obt", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var read=await cmd.ExecuteReaderAsync())
                {
                    while (await read.ReadAsync())
                    {
                        Producto prod = new Producto();
                        prod.IdProducto = (int)read["IdProducto"];
                        prod.IdProveedor = (int)read["IdProveedor"];
                        prod.IdTipoProducto = (int)read["IdTipoProducto"];
                        prod.Nombre = read.GetString("Nombre"); 
                        prod.Clave = read.GetString("Clave");
                        prod.EsActivo = (bool)read["EsActivo"];
                        prod.Precio = (decimal)read["Precio"];

                        producto.Add(prod);
                      
                    }
                }

            }

            return producto;
        }
    }
}

