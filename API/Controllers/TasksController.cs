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
        public async Task<ActionResult<List<TaskItemResponseDto>>> GetAll()
        {
            return await _taskService.GetAllAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TaskItemResponseDto>> Create([FromBody] CreateTaskItemDto createTaskItemDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            TaskItemResponseDto response = await _taskService.CreateAsync(createTaskItemDto);

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemResponseDto>> GetById(int id)
        {
            TaskItemResponseDto response = await _taskService.GetByIdAsync(id);

            if (response == null) return NotFound(new { message = $"Task with ID {id} not found." });

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody] UpdateTaskItemDto updateTaskItemDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            bool response = await _taskService.UpdateAsync(id, updateTaskItemDto);

            if (!response) return NotFound(new { message = $"Task with ID {id} not found. " });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            bool response = await _taskService.DeleteAsync(id);

            if (!response) return NotFound(new { message = $"Task with ID {id} not found. " });

            return NoContent();
        }
    }
}
