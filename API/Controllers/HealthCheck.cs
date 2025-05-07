using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controller;

[ApiController]
[Route("v1/")]
public class CheckAPI : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("health-check")]
    public async Task<IActionResult> HealthCheck()
    {
        try
        {
            return StatusCode(200, new { Message = "API em pleno funcionamento!", Error = "[]" });
        }
        catch (Exception e)
        {
            return StatusCode(500, new { Message = "Erro interno no servidor", Error = $"{e.InnerException?.Message ?? e.Message}" });
        }
    }

}