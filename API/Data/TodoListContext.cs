using Microsoft.EntityFrameworkCore;
using TodoList.Mapping;
using TodoList.Models;

namespace TodoList.Data;

public class TodoListContext : DbContext
{

    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("server=localhost, 1433;database=TodoList;User Id=sa; Password=Lucas1971!; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserAccountMap());
        modelBuilder.ApplyConfiguration(new TaskItemMap());
    }

}