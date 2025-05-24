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

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTask(Guid id, UpdateTaskDto updateTask)
        {
            var task = _context.Todos.Find(id);
            if (task is null) return NotFound();

            task.Title = updateTask.Title;
            task.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);
            task.IsDone = updateTask.IsDone;
            task.Description = updateTask.Description;

            await _context.SaveChangesAsync();
            return Ok(task);

        }
    }
}
