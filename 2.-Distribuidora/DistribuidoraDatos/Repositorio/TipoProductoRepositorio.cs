using DistribuidoraDatos.Configracion;
using DistribuidoraEntidades;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraDatos.Repositorio
{
    public class TipoProductoRepositorio:ITipoProductoRepositorio
    {
        private readonly ConfiguracionConexion _configuracionConexion;

        public TipoProductoRepositorio(IOptions<ConfiguracionConexion> configuracion)
        {
            _configuracionConexion = configuracion.Value;
        }
        public async Task<List<TipoProducto>> OptenerTipoProducto()
        {
            List<TipoProducto> response = new List<TipoProducto>();
            using (var conexion = new SqlConnection(_configuracionConexion.CadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("dbo.Usp_TipoProducto_Obt", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var read = await cmd.ExecuteReaderAsync())
                {
                    while (await read.ReadAsync())
                    {
                        TipoProducto prod = new TipoProducto();
                        prod.IdTipoProducto = (int)read["IdTipoProducto"];
                        prod.Nombre = read.GetString("Nombre");
                        prod.Descripcion = read.GetString("Descripcion");
                        response.Add(prod);

                    }
                }

            }

            return response;
        }
    }
}
