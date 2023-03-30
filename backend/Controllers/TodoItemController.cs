using Microsoft.AspNetCore.Mvc;
using Context;
using Models;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemController : ControllerBase {
    private TodoDbContext _context;

    public TodoItemController(TodoDbContext context) {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<TodoItem> Get() {
        return _context.TodoItems.ToArray();
    }

    [HttpGet("{id}")]
    public IActionResult GetItem(int id) {
        if(id < 1) {
            return NotFound("Invalid id");
        }

        TodoItem? item = _context.TodoItems
            .FirstOrDefault(item => item.ItemId == id);

        if(item == null) {
            return NotFound("Todo item not found");
        }

        return Ok(item);
    }

    [HttpPost]
    public IActionResult AddTodo(TodoItem item) {
        using(var todoItem = new TodoDbContext()) {
            todoItem.TodoItems.Add(item);
            todoItem.SaveChanges();
        }

        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateItem(TodoItem item) {
        TodoItem? todoItem = _context.TodoItems
            .FirstOrDefault(i => i.ItemId == item.ItemId);
        
        if(todoItem == null) {
            return NotFound($"item id {item.ItemId} does not exist in database");
        }

        todoItem.Title = item.Title;
        todoItem.Note = item.Note;
        todoItem.IsComplete = item.IsComplete;

        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteItem(int id) {
        TodoItem? item = _context.TodoItems
            .FirstOrDefault(i => i.ItemId == id);

        if(item == null) {
            return NotFound($"item {id} not found");
        }

        _context.TodoItems.Remove(item);
        _context.SaveChanges();

        return Ok();
    }
}
