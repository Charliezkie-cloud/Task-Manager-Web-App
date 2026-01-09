using WebApp.Data.Models.DTOs;

namespace WebApp.Services
{
    public interface ITaskApiService
    {
        Task<List<TaskItemResponseDto>> GetAllAsync();
        Task<TaskItemResponseDto> CreateAsync(CreateTaskItemDto createTaskItemDto);
        Task<TaskItemResponseDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateTaskItemDto updateTaskItemDto);
        Task<bool> DeleteAsync(int id);
    }

    public class TaskApiService : ITaskApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TaskApiService> _logger;

        public TaskApiService(HttpClient httpClient, ILogger<TaskApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<TaskItemResponseDto>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("api/tasks");

                if (response.IsSuccessStatusCode)
                {
                    List<TaskItemResponseDto>? tasks = await response.Content.ReadFromJsonAsync<List<TaskItemResponseDto>>();

                    if (tasks == null) return new List<TaskItemResponseDto>();

                    return tasks;
                }

                _logger.LogError($"Failed to fetch tasks. Status: {response.StatusCode}");
                return new List<TaskItemResponseDto>();
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching tasks from API.");
                return new List<TaskItemResponseDto>();
            }
        }

        public async Task<TaskItemResponseDto> CreateAsync(CreateTaskItemDto createTaskItemDto)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/tasks", createTaskItemDto);

                if (response.IsSuccessStatusCode)
                {
                    TaskItemResponseDto? responseDto = await response.Content.ReadFromJsonAsync<TaskItemResponseDto>();
                    if (responseDto == null) return null;
                    return responseDto;
                }

                _logger.LogError($"Error creating a tasks from API. Status: {response.StatusCode}");
                return null;
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating a tasks from API.");
                return null;
            }
        }

        public async Task<TaskItemResponseDto> GetByIdAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"api/tasks/{id}");

                if (response.IsSuccessStatusCode)
                {
                    TaskItemResponseDto? responseDto = await response.Content.ReadFromJsonAsync<TaskItemResponseDto>();
                    if (responseDto == null) return null;
                    return responseDto;
                }

                _logger.LogError($"Error fetching a task {id} from API. Status: {response.StatusCode}");
                return null;
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching a task from API.");
                return null;
            }
        }

        public async Task<bool> UpdateAsync(int id, UpdateTaskItemDto updateTaskItemDto)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/tasks/{id}", updateTaskItemDto);

                if (response.IsSuccessStatusCode) return true;

                _logger.LogError($"Error updating a task {id} from API. Status: {response.StatusCode}");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating a task from API.");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"api/tasks/{id}");

                if (response.IsSuccessStatusCode) return true;

                _logger.LogError($"Error deleting a task {id} from API. Status: {response.StatusCode}");
                return false;
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting a task from API.");
                return false;
            }
        }
    }
}
