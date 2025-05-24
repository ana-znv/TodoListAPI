namespace TodoListAPI.Models
{
    public class AddTaskDto
    {
        public required string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
