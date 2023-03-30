using Microsoft.EntityFrameworkCore;
using Models;

namespace Context;

public class TodoDbContext : DbContext {
    public DbSet<TodoItem> TodoItems {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=Todo.db");
}
