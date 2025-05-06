namespace TodoList.Models;

public class UserAccount
{

    public enum ERole { admin, user, guest };

    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    private string _email;
    public string Email { get => _email; set => _email = value.ToLower(); }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public ERole Role { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatAt { get; set; } = DateTime.Now;

    public List<TaskItem> TaskItems { get; set; } = new();

}