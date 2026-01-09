using API.Models.DTOs;

namespace API.Services
{
    public interface ITaskService
    {
        Task<List<TaskResponseDTO>> GetAllAsync();
        Task<TaskResponseDTO> CreateTaskAsync(CreateTaskDTO createTaskDTO);
        Task<TaskResponseDTO> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateTaskDTO async);
        Task<bool> DeleteAsync(int id);
    }
}
