using Aplicacion.Dtos;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Mappers
{
    public class MapTarea
    {
        public static TareaDto ToDto(Tarea tarea)
        {
            return new TareaDto
            {
                Id = tarea.Id,
                Titulo = tarea.Titulo,
                Descripcion = tarea.Descripcion,
                FechaVencimiento = tarea.FechaVencimiento,
                Prioridad = tarea.Prioridad.ToString(),
                Estado = tarea.Estado.ToString(),
                FechaCreacion = tarea.FechaCreacion,
                FechaCompletado = tarea.FechaCreacion,
                EstaVencida = tarea.EstaVencida()
            };
        }
    }
}
