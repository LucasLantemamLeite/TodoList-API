using Microsoft.EntityFrameworkCore;
using TodoList.Mapping;
using TodoList.Models;

namespace TodoList.Data;

public class TodoListContext : DbContext
{

    public TodoListContext(DbContextOptions<TodoListContext> options) : base(options) { }

    public DbSet<UserAccount> UserAccounts
    { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserAccountMap());
        modelBuilder.ApplyConfiguration(new TaskItemMap());
    }

}