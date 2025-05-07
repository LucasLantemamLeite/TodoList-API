using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Extension.Hash;
using TodoList.Models;
using TodoList.ModelView;
using TodoList.Services.TokenService;

namespace TodoList.Controller;

[ApiController]
[Route("v1/")]
public class AddUser : ControllerBase
{
    [HttpPost("user")]
    [AllowAnonymous]
    public async Task<IActionResult> AddNewUserAccount([FromBody] UserAccountView user_model, [FromServices] TodoListContext context)
    {

        try
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userAccount = new UserAccount
            {
                Name = user_model.Name,
                Login = user_model.Login,
                Password = GenPasswordHash.GenHashWithSalt(user_model.Password),
                Email = user_model.Email,
                PhoneNumber = user_model.PhoneNumber,
                BirthDate = user_model.BirthDate
            };

            await context.UserAccounts.AddAsync(userAccount);
            await context.SaveChangesAsync();

            var tokenService = new TokenService();
            var token = tokenService.GenerateToken(userAccount);

            return StatusCode(200, new { Message = @$"Conta criada com sucesso", Token = token, error = "[]" });

        }

        catch (DbUpdateException e)
        {

            if (e.InnerException.Message.Contains("Login"))
            {
                return StatusCode(400, new { Message = "Esse Login já foi registrado no Banco", error = $"{e.InnerException.Message}" });
            }
            else if (e.InnerException.Message.Contains("Email"))
            {
                return StatusCode(400, new { Message = "Esse Email já foi registrado no Banco", error = $"{e.InnerException.Message}" });
            }
            else
            {
                return StatusCode(400, new { Message = "Esse PhoneNumber já foi registrado no Banco", error = $"{e.InnerException.Message}" });
            }
        }

        catch (Exception e)
        {
            return StatusCode(500, new { Message = "Erro interno no servidor", Error = $"{e.InnerException?.Message ?? e.Message}" });
        }
    }
}