namespace WebApp.Data.Models;

public class TaskItem
{
    public int Id { get; set; }

    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
