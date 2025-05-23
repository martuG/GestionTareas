﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IServicioTareasDominio
    {
        Task ValidarLimiteAltaPrioridadAsync();
        Task<bool> PuedeCrearTareaAsync(Tarea tarea);
    }
}
