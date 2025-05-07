using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;

namespace TodoList.Controller;

[ApiController]
[Route("v1/")]
public class DeleteTask : ControllerBase
{
    [Authorize]
    [HttpDelete("task/{taskId:int}")]
    public async Task<IActionResult> DeleteTaskItem(int taskId, [FromServices] TodoListContext context)
    {

        try
        {

            var task = await context.TaskItems.FirstOrDefaultAsync(x => x.TaskId == taskId);

            if (task == null)
                return StatusCode(404, new { Message = "Nenhuma Tarefa Encontrada", Error = "[]" });

            if (task.UserId != int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                return StatusCode(403, new { Message = "Você não tem permissão para excluir essa tarefa", Error = "[]" });

            context.TaskItems.Remove(task);
            await context.SaveChangesAsync();

            return StatusCode(200, new { Message = $"Tarefa de Id: {taskId} deletada com sucesso", Error = "[]" });
        }

        catch (Exception e)
        {
            return StatusCode(500, new { Message = "Erro interno no servidor", Error = $"{e.InnerException?.Message ?? e.Message}" });
        }
    }
}