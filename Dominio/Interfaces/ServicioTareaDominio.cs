using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public class ServicioTareaDominio : IServicioTareasDominio
    {
        private readonly IRepositorioTareas _repositorioTareas;
        private const int limiteTareas = 10;

        public ServicioTareaDominio(IRepositorioTareas tareaRepo)
        {
            _repositorioTareas = tareaRepo ?? throw new ArgumentNullException(nameof(tareaRepo));
        }

        public async Task ValidarLimiteAltaPrioridadAsync()
        {
            var cantidadTareasAltaPrioridad = await _repositorioTareas.ContarPendientes();

            if (cantidadTareasAltaPrioridad >= limiteTareas)
            {
                throw new InvalidOperationException($"Advertencia: Ya hay {cantidadTareasAltaPrioridad} tareas pendientes de alta prioridad. Se recomienda completar algunas antes de crear más.");
            }
        }

        public async Task<bool> PuedeCrearTareaAsync(Tarea tarea)
        {
            if (tarea.EsDeAltaPrioridad())
            {
                var cantidadTareasAltaPrioridad = await _repositorioTareas.ContarPendientes();
                return cantidadTareasAltaPrioridad < limiteTareas;
            }

            return true;
        }

    }
}
