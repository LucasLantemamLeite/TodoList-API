using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;

namespace TodoList.Controller;

[ApiController]
[Route("v1/")]
public class GetTask : ControllerBase
{

    [Authorize]
    [HttpGet("task")]
    public async Task<IActionResult> GetTaskItem([FromServices] TodoListContext context)
    {
        try
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return StatusCode(404, new { Message = "Nenhum Id encontrado", error = "[]" });

            var userAccount = await context.UserAccounts.AsNoTracking().Include(x => x.TaskItems).FirstOrDefaultAsync(x => x.Id == int.Parse(userId));

            if (userAccount == null)
                return StatusCode(404, new { Message = "Nenhuma Task encontrada", error = "[]" });

            return StatusCode(200, new { Message = $"Tarefas encontrada do usuário: {userId}", Tasks = userAccount.TaskItems, error = "[]" });

        }
        catch (Exception e)
        {
            return StatusCode(500, new { Message = "Erro interno no servidor", Error = $"{e.InnerException?.Message ?? e.Message}" });
        }
    }
}