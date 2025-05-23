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
    public class TasksController : ControllerBase
    {
        private readonly IServicioTarea _taskService;

        public TasksController(IServicioTarea taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<ActionResult<TareaDto>> CrearTarea([FromBody] CrearTareaDto createTaskDto)
        {
            try
            {
                var task = await _taskService.CrearTareaAsync(createTaskDto);
                return CreatedAtAction(nameof(ObtenerTareas), new { id = task.Id }, task);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, warning = true });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TareaDto>> BuscarTarea(int id)
        {
            try
            {
                var task = await _taskService.BuscarTareaPorIdAsync(id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<TareaDto[]>> ObtenerTareas([FromQuery] FiltroTareasDto filter)
        {
            var tasks = await _taskService.BuscarTareasAsync(filter);
            return Ok(tasks);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarTarea(int id, [FromBody] ActualizarTareaDto updateTaskDto)
        {
            try
            {
                await _taskService.ActualizarTareaAsync(id, updateTaskDto);
                return NoContent();
            }
            //catch (Exception ex)
            //{
            //    return NotFound(ex.Message);
            //}
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/complete")]
        public async Task<ActionResult> CompletarTarea(int id)
        {
            try
            {
                await _taskService.MarcarCompletadaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarTarea(int id)
        {
            try
            {
                await _taskService.EliminarTareaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
