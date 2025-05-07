using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services.TokenService;

namespace TodoList.Controller;

[ApiController]
[Route("v1/")]
public class AddUser : ControllerBase
{
    [HttpPost("user")]
    [AllowAnonymous]
    public async Task<IActionResult> AddNewUserAccount([FromBody] UserAccount user_model, [FromServices] TodoListContext context)
    {

        try
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await context.UserAccounts.AddAsync(user_model);
            await context.SaveChangesAsync();

            var tokenService = new TokenService();
            var token = tokenService.GenerateToken(user_model);

            return StatusCode(200, new { Message = $"Conta criada com sucesso\nToken de Acesso: {token}", error = "[]" });

        }
        catch (Exception e)
        {
            return StatusCode(500, new { Message = "Erro interno no servidor", Error = $"{e.InnerException?.Message ?? e.Message}" });
        }


    }
}