using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Extension.Hash;
using TodoList.ModelView;
using TodoList.Services.TokenKey;
using TodoList.Services.TokenService;

namespace TodoList.Controller;


[ApiController]
[Route("v1/")]
public class UserAccountLogin : ControllerBase
{

    [AllowAnonymous]
    [HttpPost("user-login")]
    public async Task<IActionResult> Login([FromBody] LoginView login_model, [FromServices] TodoListContext context)
    {

        try
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userAccount = await context.UserAccounts.AsNoTracking().FirstOrDefaultAsync(x => x.Login == login_model.Login);

            if (userAccount == null)
                return StatusCode(404, new { Message = "Credências incorretas", error = "[]" });

            if (userAccount.Active == false)
                return StatusCode(400, new { Message = "Esta conta foi desativada por um Administrador", error = "[]" });

            var tokenService = new TokenService();
            var token = tokenService.GenerateToken(userAccount);

            if (userAccount.Login == login_model.Login && VerifyPasswordHash.VerifyPasswordHashWithSalt(login_model.Password, userAccount.Password))
                return StatusCode(200, new { Message = "Login realizado com sucesso", Token = token, error = "[]" });

            return StatusCode(400, new { Message = "Credências incorretas", error = "[]" });
        }

        catch (Exception e)
        {
            return StatusCode(500, new { Message = "Erro interno no servidor", Error = $"{e.InnerException?.Message ?? e.Message}" });
        }
    }
}