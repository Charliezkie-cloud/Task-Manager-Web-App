using API.Models;
using API.Models.DTOs;

namespace API.Helpers
{
    public static class TaskMapper
    {
        public static TaskItemResponseDto ToResponseDto(TaskItem taskItem)
        {
            return new TaskItemResponseDto
            {
                Id = taskItem.Id,
                Created_at = taskItem.Created_at,
                Updated_at = taskItem.Updated_at,
                Name = taskItem.Name,
                Description = taskItem.Description
            };
        }

        public static List<TaskItemResponseDto> ToResponseDtoList(List<TaskItem> taskItems)
        {
            return taskItems.Select(ToResponseDto).ToList();
        }

        public static TaskItem CreateDtoToTaskItem(CreateTaskItemDto createTaskItemDto)
        {
            return new TaskItem
            {
                Created_at = DateTime.UtcNow,
                Updated_at = DateTime.UtcNow,
                Name = createTaskItemDto.Name,
                Description = createTaskItemDto.Description
            };
        }

        public static TaskItem UpdateDtoToTaskItem(UpdateTaskItemDto updateTaskItemDto)
        {
            return new TaskItem
            {
                Updated_at = DateTime.UtcNow,
                Name = updateTaskItemDto.Name,
                Description = updateTaskItemDto.Description
            };
        }
    }
}
