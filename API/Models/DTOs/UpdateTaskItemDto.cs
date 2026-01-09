using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs
{
    public class UpdateTaskItemDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string? Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 100 characters..")]
        public string? Description { get; set; }
    }
}
