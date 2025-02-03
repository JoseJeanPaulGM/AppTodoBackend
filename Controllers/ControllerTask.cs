using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TdoTareasBackend.Models;
using TdoTareasBackend.Services;

namespace TdoTareasBackend.Controllers
{
    [Route("api/task")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ControllerTask : Controller
    {
        private readonly ITareasService _tareasService;

        public ControllerTask(ITareasService tareasService)
        {
            _tareasService = tareasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tareas>>> GetTareas()
        {
            var tareas = await _tareasService.GetAllTareasAsync();
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tareas>> GetTarea(int id)
        {
            try
            {
                var tarea = await _tareasService.GetTareaByIdAsync(id);
                return Ok(tarea);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Tareas>> PostTarea(Tareas tarea)
        {
            var nuevaTarea = await _tareasService.CreateTareaAsync(tarea);
            return CreatedAtAction(nameof(GetTarea), new { id = nuevaTarea.Id }, nuevaTarea);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(int id, Tareas tarea)
        {
            try
            {
                await _tareasService.UpdateTareaAsync(id, tarea);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            try
            {
                var result = await _tareasService.DeleteTareaAsync(id);
                if (!result)
                    return NotFound();
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("estado/{isComplete}")]
        public async Task<ActionResult<IEnumerable<Tareas>>> GetTareasByCompletionAsync(bool isComplete)
        {
            var tareas = await _tareasService.GetTareasByCompletionAsync(isComplete);
            return Ok(tareas);

        }

    }
}
