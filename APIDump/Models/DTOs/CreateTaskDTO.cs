using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs
{
    public class CreateTaskDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Title must be between 3 and 100 characters.")]
        public string? Title { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }
    }
}
