using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class RepositorioTareas : IRepositorioTareas
    {
        private readonly ContextTareas _context;

        public RepositorioTareas(ContextTareas context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Tarea> BuscarPorIdAsync(int id)
        {
            return await _context.Tareas.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tarea>> ListarTareasAsync()
        {
            return await _context.Tareas.ToListAsync();
        }

        public async Task<IEnumerable<Tarea>> ListarEstadosAsync(Estado estado)
        {
            return await _context.Tareas.Where(t => t.Estado == estado).ToListAsync();
        }

        public async Task<IEnumerable<Tarea>> ListarEstadoPrioridad(Estado estado, Prioridad prioridad)
        {
            return await _context.Tareas.Where(t => t.Estado == estado && t.Prioridad == prioridad).ToListAsync();
        }

        public async Task<int> ContarTareasPendientesAsync()
        {
            return await _context.Tareas.CountAsync(t => t.Estado == Estado.Pendiente && t.Prioridad == Prioridad.Alta);
        }

        public async Task AgregarAsync(Tarea tarea)
        {
            if (tarea == null)
                throw new ArgumentNullException(nameof(tarea));

            await _context.Tareas.AddAsync(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Tarea tarea)
        {
            if (tarea == null)
                throw new ArgumentNullException(nameof(tarea));

            _context.Tareas.Update(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var tarea = await BuscarPorIdAsync(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _context.Tareas.AnyAsync(t => t.Id == id);
        }
    }
}
