using API.Data;
using API.Helpers;
using API.Models;
using API.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{

    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskResponseDTO>> GetAllAsync()
        {
            var tasks = await _context.Tasks.OrderByDescending(e => e.Created_at).ToListAsync();
            return TaskMapper.ToResponseDTOList(tasks);
        }

        public async Task<TaskResponseDTO> CreateTaskAsync(CreateTaskDTO createTaskDTO)
        {
            TaskItem taskItem = TaskMapper.ToTaskItem(createTaskDTO);

            _context.Tasks.Add(taskItem);
            await _context.SaveChangesAsync();

            return TaskMapper.ToResponseDTO(taskItem);
        }

        public async Task<TaskResponseDTO> GetByIdAsync(int id)
        {
            TaskItem? taskItem = await _context.Tasks.FindAsync(id);
            return taskItem != null ? TaskMapper.ToResponseDTO(taskItem) : null;
        }

        public async Task<bool> UpdateAsync(int id, UpdateTaskDTO updateTaskDTO)
        {
            TaskItem? taskItem = await _context.Tasks.FindAsync(id);

            if (taskItem == null) return false;

            taskItem.Updated_at = DateTime.UtcNow;
            taskItem.Title = updateTaskDTO.Title;
            taskItem.Description = updateTaskDTO.Description;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            TaskItem? taskItem = await _context.Tasks.FindAsync(id);

            if (taskItem == null) return false;

            _context.Tasks.Remove(taskItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
