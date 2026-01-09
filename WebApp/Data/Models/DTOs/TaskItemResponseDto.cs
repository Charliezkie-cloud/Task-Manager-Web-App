namespace WebApp.Data.Models.DTOs
{
    public class TaskItemResponseDto
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
