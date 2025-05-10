using System.ComponentModel.DataAnnotations;

namespace TodoList.ModelView;

public class CompleteTaskView
{
    [DataType(DataType.DateTime, ErrorMessage = "CompleteDate não é uma data válida.")]
    public DateTime? CompleteDate { get; set; }

}