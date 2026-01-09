using System.ComponentModel.DataAnnotations;

namespace WebApp.Data.Models.DTOs
{
    public class CreateTaskItemDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string? Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 500 characters.")]
        public string? Description { get; set; }
    }
}
