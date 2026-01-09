using API.Models;
using API.Models.DTOs;

namespace API.Helpers
{
    public static class TaskMapper
    {
        public static TaskResponseDTO ToResponseDTO(TaskItem taskItem)
        {
            return new TaskResponseDTO
            {
                Id = taskItem.Id,
                Created_at = taskItem.Created_at,
                Updated_at = taskItem.Updated_at,
                Title = taskItem.Title,
                Description = taskItem.Description
            };
        }

        public static TaskItem ToTaskItem(CreateTaskDTO taskResponseDTO)
        {
            return new TaskItem
            {
                Created_at = DateTime.UtcNow,
                Updated_at = DateTime.UtcNow,
                Title = taskResponseDTO.Title,
                Description = taskResponseDTO.Description
            };
        }

        public static List<TaskResponseDTO> ToResponseDTOList(List<TaskItem> taskItems)
        {
            return taskItems.Select(ToResponseDTO).ToList();
        }
    }
}
