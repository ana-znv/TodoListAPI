namespace TodoListAPI.Models.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }
        public bool IsDone { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
