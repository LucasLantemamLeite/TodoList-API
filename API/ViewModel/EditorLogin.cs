using System.ComponentModel.DataAnnotations;

namespace TodoList.ModelView;

public class LoginView
{
    [Required(ErrorMessage = "O campo de Login é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O campo de Login deve ter menos de 100 caracteres.")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O campo de Password é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O campo de Password deve ter menos de 100 caracteres.")]
    public string Password { get; set; }
}