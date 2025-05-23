using Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public interface IServicioTarea
    {
        Task<TareaDto> CrearTareaAsync(CrearTareaDto dto);
        Task<TareaDto> BuscarTareaPorIdAsync(int id);
        Task<IEnumerable<TareaDto>> BuscarTareasAsync(FiltroTareasDto filtro);
        Task<ResultadoOperacionDto> MarcarCompletadaAsync(int id);
        Task<TareaDto> ActualizarTareaAsync(int id, ActualizarTareaDto dto);
        Task<ResultadoOperacionDto> EliminarTareaAsync(int id);
    }
}
