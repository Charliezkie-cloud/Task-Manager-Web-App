using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tasks")]
    public class TaskItem
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("created_at")]
        [DataType(DataType.DateTime)]
        public DateTime Created_at { get; set; }

        [Column("updated_at")]
        [DataType(DataType.DateTime)]
        public DateTime Updated_at { get; set; }

        [Required]
        [Column("name")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [Column("description")]
        [StringLength(500)]
        public string? Description { get; set; }
    }
}
