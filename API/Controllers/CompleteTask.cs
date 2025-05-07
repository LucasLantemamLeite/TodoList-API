using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.ModelView;

namespace TodoList.Controller;

[ApiController]
[Route("v1/")]
public class CompleteTask : ControllerBase
{
    [Authorize]
    [HttpPatch("task/{taskId:int}")]
    public async Task<IActionResult> CompleteTaskItem(int taskId, [FromBody] CompleteTaskView complete_model, [FromServices] TodoListContext context)
    {
        try
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await context.TaskItems.FirstOrDefaultAsync(x => x.TaskId == taskId);

            if (task == null)
                return StatusCode(404, new { Message = "Nenhuma Task encontrada com esse Id", Error = "[]" });

            if (task.UserId != int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                return StatusCode(403, new { Message = "Você não tem permissão de completar essa tarefa", Error = "[]" });

            if (task.Done == true)
            {
                task.CompleteDate = null;
                task.Done = false;
            }
            else
            {
                task.CompleteDate = complete_model.CompleteDate ?? DateTime.Now;
                task.Done = true;
            }

            context.TaskItems.Update(task);
            await context.SaveChangesAsync();

            if (task.Done)
                return StatusCode(200, new { Message = $"Tarefa de Id: {taskId} foi marcada como Concluída", Error = "[]" });

            return StatusCode(200, new { Message = $"Tarefa de Id: {taskId} foi marcada como não Concluída", Error = "[]" });

        }
        catch (Exception e)
        {
            return StatusCode(500, new { Message = "Erro interno no servidor", Error = $"{e.InnerException?.Message ?? e.Message}" });
        }
    }
}