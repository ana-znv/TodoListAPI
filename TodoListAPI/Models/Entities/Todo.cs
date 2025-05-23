namespace TodoListAPI.Models.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDone { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
