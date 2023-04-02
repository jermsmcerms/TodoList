using Microsoft.AspNetCore.Mvc;
using Context;
using Models;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemController : ControllerBase {
    private ITodoListService _todoService;

    public TodoItemController(ITodoListService service) {
        _todoService = service;
    }

    [HttpGet]
    public IEnumerable<TodoItem> Get() {
        return _todoService.GetAll();
    }

    [HttpGet("{id}")]
    public IActionResult GetItem(int id) {
        TodoItem? item = _todoService.GetById(id);
        return item == null ? Ok(item) : NotFound("Todo item not found");
    }

    [HttpPost]
    public IActionResult AddTodo(TodoItem item) {
        return _todoService.Post(item) ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateItem(TodoItem item) {
        return _todoService.Put(item) ? Ok() : BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteItem(int id) {    
        return _todoService.Delete(id) ?  Ok() : BadRequest();
    }
}

