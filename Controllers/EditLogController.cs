using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/edit-log")]
[Tags("Edit Log")]
public class EditLogController : ControllerBase
{
    private readonly EditLogLogic _editLogLogic;

    public EditLogController(EditLogLogic editLogLogic)
    {
        _editLogLogic = editLogLogic;
    }

    [HttpGet]
    public async Task<IActionResult> GetEditLog([FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
    {
        var result = await _editLogLogic.GetEditLogAsync(fromDate, toDate);
        return Ok(result);
    }

    [HttpGet("{entityType}/{entityId}")]
    public async Task<IActionResult> GetEditLogByEntity(string entityType, string entityId)
    {
        var result = await _editLogLogic.GetEditLogByEntityAsync(entityType, entityId);
        return Ok(result);
    }

    [HttpGet("user-activity")]
    public async Task<IActionResult> GetUserActivity([FromQuery] string? userId = null)
    {
        var result = await _editLogLogic.GetUserActivityAsync(userId);
        return Ok(result);
    }
}