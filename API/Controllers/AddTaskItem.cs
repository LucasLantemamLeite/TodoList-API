using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;
using TodoList.ModelView;

namespace TodoList.Controller;

[ApiController]
[Route("v1/")]
public class AddTask : ControllerBase
{

    [Authorize]
    [HttpPost("task")]
    public async Task<IActionResult> AddTaskItem([FromBody] TaskItemView task_model, [FromServices] TodoListContext context)
    {
        try
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return StatusCode(200, new { Message = $"Nenhum Id encontrado", error = "[]" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var taskItem = new TaskItem
            {
                Title = task_model.Title,
                Description = task_model.Description,
                DeadLine = task_model.DeadLine,
                CompleteDate = task_model.CompleteDate,
                UserId = int.Parse(userId)
            };

            await context.TaskItems.AddAsync(taskItem);
            await context.SaveChangesAsync();

            return StatusCode(200, new { Message = $"Tarefa criada com sucesso para o Usuário: {userId}", error = "[]" });

        }
        catch (Exception e)
        {
            return StatusCode(500, new { Message = "Erro interno no servidor", Error = $"{e.InnerException?.Message ?? e.Message}" });
        }
    }

}