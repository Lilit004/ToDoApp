using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Controllers
{
    [Route("api/todoitems")]
    [ApiController]
    public class ToDosController : Controller
    {
        private readonly ToDoDbContext _context;

        public ToDosController(ToDoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoDTO>>> GetToDos()
        {
            return await _context.ToDos.Select(x => new ToDoDTO(x)).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ToDoDTO>> CreateToDo(ToDoDTO todoDTO)
        {
            var todo = new ToDo();

            todo.Name = todoDTO.Name;
            if (todoDTO.Completed)
                todo.ToDoStatusesId = 1;
            else
                todo.ToDoStatusesId = 2;
            
            await _context.ToDos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
            nameof(GetToDos),
            new { id = todo.Id },
            new ToDoDTO(todo));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoDTO>> GetToDoById(int id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            if (todo == null)
                return NotFound("No such item");
            else
                return Ok(new ToDoDTO(todo));
        }

        [HttpGet("completed")]

        public async Task<ActionResult<IEnumerable<ToDoDTO>>> GetCompletedToDos()
        {
            return await _context.ToDos.Where(x => x.ToDoStatusesId == 1).Select(x => new ToDoDTO(x)).ToListAsync();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateToDo(int id, ToDoDTO todoDTO)
        {
            if (id != todoDTO.Id)
            {
                return BadRequest();
            }
            var todo = await _context.ToDos.FindAsync(id);
            if (todo == null)
                return NotFound("No such item");

            todo.Name = todoDTO.Name;
            if (todoDTO.Completed == true)
                todo.ToDoStatusesId = 1;
            else
                todo.ToDoStatusesId = 2;
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> RemoveToDo(int id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            if (todo == null)
                return NotFound();
            _context.ToDos.Remove(todo);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
