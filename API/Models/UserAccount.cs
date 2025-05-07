using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models;

public class UserAccount
{

    public enum ERole { Guest, Admin, User };

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    [Column("PasswordHash")]
    public string Password { get; set; }
    private string _email;
    public string Email { get => _email; set => _email = value.ToLower(); }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public ERole Role { get; set; } = (ERole)2;
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public List<TaskItem> TaskItems { get; set; } = new();

}