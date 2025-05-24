namespace TodoListAPI.Models
{
    public class UpdateTaskDto
    {
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
