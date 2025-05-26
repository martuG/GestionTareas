using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IRepositorioTareas
    {
        Task<Tarea> BuscarPorIdAsync(int id);
        Task<IEnumerable<Tarea>> ListarTareasAsync();
        Task<IEnumerable<Tarea>> ListarEstadosAsync(Estado estado);
        Task<IEnumerable<Tarea>> ListarEstadoPrioridad(Estado estado, Prioridad prioridad);
        Task<int> ContarTareasPendientesAsync();
        Task AgregarAsync(Tarea tarea);
        Task ActualizarAsync(Tarea tarea);
        Task EliminarAsync(int id);
        Task<bool> ExisteAsync(int id);
    }
}
