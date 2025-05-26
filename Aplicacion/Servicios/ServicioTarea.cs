using Aplicacion.Dtos;
using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Mappers;

namespace Aplicacion.Servicios
{
    public class ServicioTarea : IServicioTarea
    {
        private readonly IRepositorioTareas _tareaRepository;
        private readonly ServicioTareaDominio _tareasDominioService;

        public ServicioTarea(IRepositorioTareas tareaRepository, ServicioTareaDominio tareasDominioService)
        {
            _tareaRepository = tareaRepository ?? throw new ArgumentNullException(nameof(tareaRepository));
            _tareasDominioService = tareasDominioService ?? throw new ArgumentNullException(nameof(tareasDominioService));
        }

        public async Task<TareaDto> CrearTareaAsync(CrearTareaDto dto)
        {
            var titulo = new TituloTarea(dto.Titulo);
            var prioridad = (Prioridad)dto.Prioridad;

            var tarea = new Tarea();

            // Validar límite de tareas de alta prioridad
            if (tarea.EsDeAltaPrioridad())
            {
                var puedeCrear = await _tareasDominioService.PuedeCrearTareaAsync(tarea);
                if (!puedeCrear)
                {
                    await _tareasDominioService.ValidarLimiteAltaPrioridadAsync();
                }
            }

            await _tareaRepository.AgregarAsync(tarea);
            return MapearATareaResponse(tarea);
        }

        public async Task<TareaDto> BuscarTareaPorIdAsync(int id)
        {
            var tarea = await _tareaRepository.BuscarIdAsync(id);
            if (tarea == null)
                throw new TareaNoEncontrada(id);

            return MapearATareaResponse(tarea);
        }

        public async Task<IEnumerable<TareaDto>> BuscarTareasAsync(FiltroTareasDto filtro)
        {
            IEnumerable<Tarea> tareas;

            if (string.IsNullOrEmpty(filtro.Estado))
            {
                tareas = await _tareaRepository.ListarTareasAsync();
            }
            else
            {
                var estado = Enum.Parse<Estado>(filtro.Estado, true);
                tareas = await _tareaRepository.ListarEstadosAsync(estado);
            }

            // Aplicar ordenamiento
            tareas = AplicarOrdenamiento(tareas, filtro.OrdenarPor, filtro.Direccion);

            return tareas.Select(MapearATareaResponse);
        }

        public async Task<ResultadoOperacionDto> MarcarCompletadaAsync(int id)
        {
            var tarea = await _tareaRepository.BuscarIdAsync(id);
            if (tarea == null)
                throw new TareaNoEncontrada(id);

            try
            {
                tarea.MarcarComoCompletada();
                await _tareaRepository.ActualizarAsync(tarea);

                return ResultadoOperacionDto.ExitosoConMensaje("Tarea marcada como completada exitosamente");
            }
            catch (InvalidOperationException ex)
            {
                return ResultadoOperacionDto.Fallido(ex.Message);
            }
        }

        public async Task<TareaDto> ActualizarTareaAsync(int id, ActualizarTareaDto dto)
        {
            var tarea = await _tareaRepository.BuscarIdAsync(id);
            if (tarea == null)
                throw new TareaNoEncontrada(id);

            var nuevoTitulo = new TituloTarea(dto.Titulo);
            var nuevaPrioridad = (Prioridad)dto.Prioridad;

            tarea.ActualizarTarea(nuevoTitulo, dto.Descripcion, dto.FechaVencimiento, nuevaPrioridad);

            await _tareaRepository.ActualizarAsync(tarea);
            return MapearATareaResponse(tarea);
        }

        public async Task<ResultadoOperacionDto> EliminarTareaAsync(int id)
        {
            var existe = await _tareaRepository.ExisteAsync(id);
            if (!existe)
                throw new TareaNoEncontrada(id);

            await _tareaRepository.EliminarAsync(id);
            return ResultadoOperacionDto.ExitosoConMensaje("Tarea eliminada exitosamente");
        }

        private TareaDto MapearATareaResponse(Tarea tarea)
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
                FechaCompletado = tarea.FechaFinalizada,
                EstaVencida = tarea.EstaVencida()
            };
        }

        private IEnumerable<Tarea> AplicarOrdenamiento(IEnumerable<Tarea> tareas, string ordenarPor, string direccion)
        {
            var esAscendente = direccion?.ToLower() == "asc";

            return ordenarPor?.ToLower() switch
            {
                "fecha" => esAscendente
                    ? tareas.OrderBy(t => t.FechaVencimiento)
                    : tareas.OrderByDescending(t => t.FechaVencimiento),
                "prioridad" or _ => esAscendente
                    ? tareas.OrderBy(t => t.Prioridad)
                    : tareas.OrderByDescending(t => t.Prioridad)
            };
        }
        public async Task<IEnumerable<TareaDto>> ListarAsync()
        {
            var tasks = await _tareaRepository.ListarTareasAsync();
            return tasks.Select(MapTarea.ToDto);
        }
    }
}
