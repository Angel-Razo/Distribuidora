﻿using DistribuidoraEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraDatos.Repositorio
{
    public interface ITipoProductoRepositorio
    {
        Task<List<TipoProducto>> OptenerTipoProducto();
    }
}
