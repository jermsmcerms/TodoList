using Microsoft.AspNetCore.Mvc;
using Models;

public interface ITodoListService {
    IEnumerable<TodoItem> GetAll();
    TodoItem? GetById(int id);
    bool Put(TodoItem item);
    bool Post(TodoItem item);
    bool Delete(int id);
};

