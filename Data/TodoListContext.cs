using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data;

public class TodoList : DbContext
{

    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("server=localhost, 1433;database=TodoList;User Id=sa; Password=Lucas1971!; TrustServerCertificate=true;");

}