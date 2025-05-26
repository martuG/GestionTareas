using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class TareaDominoServicio
    {
        private readonly IRepositorioTareas _repositorioTareas;

        public TareaDominoServicio(IRepositorioTareas taskRepository)
        {
            _repositorioTareas = taskRepository ?? throw new System.ArgumentNullException(nameof(taskRepository));
        }

        public async Task ValidarTareaAsync(Tarea tarea)
        {
            // Verificar si hay más de 10 tareas pendientes de alta prioridad
            var highPriorityPendingCount = await _repositorioTareas.ContarPendientes();

            // Si la nueva tarea es de alta prioridad, incrementar el contador
            if (tarea.EsDeAltaPrioridad() && !tarea.EstaVencida())
            {
                highPriorityPendingCount++;
            }

            if (highPriorityPendingCount > 10)
            {
                throw new TareaAltaPrioridad(highPriorityPendingCount);
            }
        }

        public async Task ValidarTareaCompletadaAsync(Tarea tarea)
        {
            if (tarea.EstaVencida())
            {
                throw new TareaVencida();
            }

            await Task.CompletedTask;
        }
    }
}
