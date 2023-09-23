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

        public async Task<bool> crearProducto(Producto producto)
        {
            try
            {
                using (var conexion = new SqlConnection(_configuracionConexion.CadenaConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("dbo.Usp_Producto_Ins", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("Clave", producto.Clave);
                    cmd.Parameters.AddWithValue("IdProveedor", producto.IdProveedor);
                    cmd.Parameters.AddWithValue("IdTipoProducto", producto.IdTipoProducto);
                    cmd.Parameters.AddWithValue("Precio", producto.Precio);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> eliminarProducto(int idProducto)
        {
            try
            {
                using (var conexion = new SqlConnection(_configuracionConexion.CadenaConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("dbo.Usp_Producto_Del", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdProducto", idProducto);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Producto>> OptenerProducto()
        {
            List<Producto> producto = new List<Producto>();
            using(var conexion=new SqlConnection(_configuracionConexion.CadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("dbo.Usp_Producto_Obt", conexion);
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

