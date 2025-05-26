using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Dtos;
using Aplicacion.Servicios;
using Dominio.Excepciones;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ControladorTarea : ControllerBase
    {
        private readonly IServicioTarea _taskService;

        public ControladorTarea(IServicioTarea taskService)
        {
            _taskService = taskService ?? throw new System.ArgumentNullException(nameof(taskService));
        }

        /// Obtiene todas las tareas con filtros opcionales
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TareaDto>>> ObtenerTareas([FromQuery] FiltroTareasDto filter)
        {
            var filteredTasks = await _taskService.BuscarTareasAsync(filter);
            return Ok(filteredTasks);

        }

        /// Obtiene una tarea específica por ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TareaDto>> ObtenerTarea(int id)
        {
            try
            {
                var task = await _taskService.BuscarTareaPorIdAsync(id);
                return Ok(task);
            }
            catch (TareaNoEncontrada)
            {
                return NotFound($"Tarea con id {id} no encontrada");
            }
        }

        /// Crea una nueva tarea
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<TareaDto>> CreateTask([FromBody] CrearTareaDto createTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdTask = await _taskService.CrearTareaAsync(createTaskDto);
                return CreatedAtAction(
                    nameof(ObtenerTarea),
                    new { id = createdTask.Id },
                    createdTask);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// Actualiza una tarea existente
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TareaDto>> ActualizarTarea(int id, [FromBody] ActualizarTareaDto updateTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedTask = await _taskService.ActualizarTareaAsync(id, updateTaskDto);
                return Ok(updatedTask);
            }
            catch (TareaNoEncontrada)
            {
                return NotFound($"Tarea con id {id} no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// Marca una tarea como completada
        [HttpPatch("{id}/complete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TareaDto>> CompletarTarea(int id)
        {
            try
            {
                var completedTask = await _taskService.MarcarCompletadaAsync(id);
                return Ok(completedTask);
            }
            catch (TareaNoEncontrada)
            {
                return NotFound($"Tarea con id {id} no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// Elimina una tarea
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarTarea(int id)
        {
            try
            {
                await _taskService.EliminarTareaAsync(id);
                return NoContent();
            }
            catch (TareaNoEncontrada)
            {
                return NotFound($"Tarea con id {id} no encontrada");
            }
        }
    }
}
