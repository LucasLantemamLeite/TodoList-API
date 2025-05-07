using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoList.Models;

public class TaskItem
{

    [Key]
    public int TaskId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; } = null;
    public bool Done { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? DeadLine { get; set; } = null;
    public DateTime? CompleteDate { get; set; } = null;
    public int UserId { get; set; }

    [JsonIgnore]
    public UserAccount UserAccount { get; set; }

}