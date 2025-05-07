using System.ComponentModel.DataAnnotations;

namespace TodoList.ModelView;

public class TaskItemView
{

    [Required(ErrorMessage = "O campo Title é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O campo de Title deve ter menos de 100 caracteres")]
    public string Title { get; set; }

    [MaxLength(300, ErrorMessage = "O campo de Description deve ter menos de 300 caracteres.")]
    public string? Description { get; set; }

    [DataType(DataType.Date, ErrorMessage = "DeadLine não é uma data válida.")]
    public DateTime? MyProperty { get; set; }

    [DataType(DataType.Date, ErrorMessage = "CompleteDate não é uma data válida.")]
    public DateTime? CompleteDate { get; set; }

}