using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/edit-log")]
[Tags("Edit Log")]
public class EditLogController : ControllerBase
{
    private readonly EditLogService _editLogService;

    public EditLogController(EditLogService editLogService)
    {
        _editLogService = editLogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEditLog([FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
    {
        var result = await _editLogService.GetEditLogAsync(fromDate, toDate);
        return Ok(result);
    }

    [HttpGet("{entityType}/{entityId}")]
    public async Task<IActionResult> GetEditLogByEntity(string entityType, string entityId)
    {
        var result = await _editLogService.GetEditLogByEntityAsync(entityType, entityId);
        return Ok(result);
    }

    [HttpGet("user-activity")]
    public async Task<IActionResult> GetUserActivity([FromQuery] string? userId = null)
    {
        var result = await _editLogService.GetUserActivityAsync(userId);
        return Ok(result);
    }
}