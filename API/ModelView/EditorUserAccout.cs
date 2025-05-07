namespace TodoList.ModelView;
using System.ComponentModel.DataAnnotations;
using Validation.ViewModel;

public class UserAccountView
{
    [Required(ErrorMessage = "O campo Name é obrigatório.")]
    [MaxLength(130, ErrorMessage = "O campo de Name deve ter menos de 130 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo de Login é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O campo de Login deve ter menos de 130 caracteres.")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O campo Password é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O campo de Password deve ter menos de 100 caracteres.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "O campo de Email é obrigatório.")]
    [MaxLength(130, ErrorMessage = "O campo de Password deve ter menos de 100 caracteres.")]
    [EmailAddressDomain(ErrorMessage = "Não é um Email válido, verifique se o mesmo possui um ")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo de PhoneNumber é obrigatório.")]
    [MaxLength(20, ErrorMessage = "O campo de PhoneNumber deve ter menos de 100 caracteres.")]
    [Phone(ErrorMessage = "Não é um Número de Telefone válido.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "O campo de BirthDate é obrigatório.")]
    [DataType(DataType.Date, ErrorMessage = "Não é uma data válida.")]
    [BirthDateLessThanToday(MinimumAge = 18, ErrorMessage = "A idade mínima é de 18 anos.")]
    public DateTime BirthDate { get; set; }

}