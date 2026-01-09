using API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public interface ITaskService
    {
        public Task<List<TaskItemResponseDto>> GetAllAsync();
        public Task<TaskItemResponseDto> CreateAsync(CreateTaskItemDto createTaskItemDto);
        public Task<TaskItemResponseDto> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(int id, UpdateTaskItemDto updateTaskItemDto);
        public Task<bool> DeleteAsync(int id);
    }
}
