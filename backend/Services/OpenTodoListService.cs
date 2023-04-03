using Models;
using Context;

namespace Services;

public class OpenTodoListService : ITodoListService {
    private readonly TodoDbContext _context;

    public OpenTodoListService(TodoDbContext context) {
        _context = context;
    }

    public IEnumerable<TodoItem> GetAll() {
        if(_context.TodoItems == null) {
            return Enumerable.Empty<TodoItem>();
        }

        return _context.TodoItems.ToArray();
    }

    public TodoItem? GetById(int id) {
        return _context.TodoItems
            .FirstOrDefault(item => item.ItemId == id);
    }

    public bool Put(TodoItem item) {
        TodoItem? todoItem = _context.TodoItems
            .FirstOrDefault(i => i.ItemId == item.ItemId);
        
        if(todoItem == null) {
            return false;
        }

        todoItem.Title = item.Title;
        todoItem.Note = item.Note;
        todoItem.IsComplete = item.IsComplete;
        todoItem.DueDate = item.DueDate;

        return _context.SaveChanges() > 0;
    }

    public bool Post(TodoItem item) {
        _context.Add(item);
       return _context.SaveChanges() > 0;
    }

    public bool Delete(int id) {
    TodoItem? item = _context.TodoItems
            .FirstOrDefault(i => i.ItemId == id);

        if(item == null) {
            return false;
        }

        _context.Remove(item);
        return _context.SaveChanges() > 0;
    }
};

