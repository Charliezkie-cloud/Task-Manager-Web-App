using API.Helpers;
using API.Models;
using API.Models.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskResponseDTO>>> GetAll()
        {
            var responseDTO = await _taskService.GetAllAsync();
            return Ok(responseDTO);
        }

        [HttpPost]
        public async Task<ActionResult<TaskResponseDTO>> Create([FromBody] CreateTaskDTO createTaskDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            TaskResponseDTO responseDTO = await _taskService.CreateTaskAsync(createTaskDTO);

            return CreatedAtAction(nameof(GetById), new { id = responseDTO.Id }, responseDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResponseDTO>> GetById(int id)
        {
            TaskResponseDTO responseDTO = await _taskService.GetByIdAsync(id);

            if (responseDTO == null)
                return NotFound(new { message = $"Task with ID {id} not found." });

            return Ok(responseDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskDTO updateTaskDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool response = await _taskService.UpdateAsync(id, updateTaskDTO);

            if (!response)
                return NotFound(new { message = $"Task with ID {id} not found." });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _taskService.DeleteAsync(id);

            if (!response)
                return NotFound(new { message = $"Task with ID {id} not found." });

            return NoContent();
        }
    }
}
