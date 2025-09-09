using Microsoft.AspNetCore.Mvc;
using TallyConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Core")]
public class CoreController : ControllerBase
{
    private readonly TallyService _tallyService;

    public CoreController(TallyService tallyService)
    {
        _tallyService = tallyService;
    }

    [HttpGet("check")]
    public async Task<IActionResult> CheckTallyConnection()
    {
        var result = await _tallyService.CheckAsync();
        return Ok(result);
    }

    [HttpGet("info")]
    public async Task<IActionResult> GetTallyInfo()
    {
        var result = await _tallyService.GetLicenseInfoAsync();
        return Ok(result);
    }
}