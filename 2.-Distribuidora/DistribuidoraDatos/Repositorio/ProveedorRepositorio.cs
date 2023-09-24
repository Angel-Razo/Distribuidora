using DistribuidoraDatos.Configracion;
using DistribuidoraEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace DistribuidoraDatos.Repositorio
{
    public class ProveedorRepositorio : IProveedorRepositorio
    {
        private readonly ConfiguracionConexion _configuracionConexion;

        public ProveedorRepositorio(IOptions<ConfiguracionConexion> configuracion)
        {
            _configuracionConexion = configuracion.Value;
        }
        public async Task<List<Proveedor>> OptenerProveedor()
        {
            List<Proveedor> producto = new List<Proveedor>();
            using (var conexion = new SqlConnection(_configuracionConexion.CadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("dbo.Usp_Proveedor_Obt", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var read = await cmd.ExecuteReaderAsync())
                {
                    while (await read.ReadAsync())
                    {
                        Proveedor prod = new Proveedor();
                        prod.IdProveedor = (int)read["IdProveedor"];
                        prod.Nombre = read.GetString("Nombre");
                        prod.Descripcion = read.GetString("Descripcion");
                        producto.Add(prod);

                    }
                }

            }

            return producto;
        }
    }
}
