using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Models;
using TodoListAPI.Models.Entities;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Todo>> GetAllTasks()
        {
            var tasks = await _context.Todos.ToListAsync();
            return tasks;
        }

        [HttpPost]
        public async Task<Todo> AddTask(AddTaskDto addTask)
        {
            var task = new Todo()
            {
                Title = addTask.Title,
                CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                UpdatedAt = DateOnly.FromDateTime(DateTime.Now),
                IsDone = false,
                Description = addTask.Description
            };

            await _context.Todos.AddAsync(task);
            await _context.SaveChangesAsync();

            return task;
        }
    }
}
