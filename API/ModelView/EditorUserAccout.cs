namespace TodoList.ModelView;
using System.ComponentModel.DataAnnotations;

public class UserAccountView 
{   
    [Required(ErrorM)]
    public string Name { get; set; }


}