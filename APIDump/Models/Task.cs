using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tasks")]
    public class TaskItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("created_at")]
        public DateTime Created_at { get; set; }

        [Column("updated_at")]
        public DateTime Updated_at { get; set; }

        [Required]
        [Column("title")]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required]
        [Column("description")]
        [StringLength(500)]
        public string? Description { get; set; }
    }
}
