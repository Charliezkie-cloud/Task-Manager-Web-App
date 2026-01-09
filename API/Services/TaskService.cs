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

        public TaskService (AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItemResponseDto>> GetAllAsync()
        {
            var tasks = await _context.Tasks.OrderByDescending(e => e.Created_at).ToListAsync();
            return TaskMapper.ToResponseDtoList(tasks);
        }

        public async Task<TaskItemResponseDto> CreateAsync(CreateTaskItemDto createTaskItemDto)
        {
            TaskItem taskItem = TaskMapper.CreateDtoToTaskItem(createTaskItemDto);

            _context.Tasks.Add(taskItem);
            await _context.SaveChangesAsync();

            return TaskMapper.ToResponseDto(taskItem);
        }

        public async Task<TaskItemResponseDto> GetByIdAsync(int id)
        {
            TaskItem? taskItem = await _context.Tasks.FindAsync(id);

            if (taskItem == null) return null;

            return TaskMapper.ToResponseDto(taskItem);
        }

        public async Task<bool> UpdateAsync(int id, UpdateTaskItemDto updateTaskItemDto)
        {
            TaskItem? taskItem = await _context.Tasks.FindAsync(id);

            if (taskItem == null) return false;

            TaskItem updatedTaskItem = TaskMapper.UpdateDtoToTaskItem(updateTaskItemDto);
            taskItem = updatedTaskItem;

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
