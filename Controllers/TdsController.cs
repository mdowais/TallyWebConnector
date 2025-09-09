using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("TDS")]
public class TdsController : ControllerBase
{
    private readonly TdsService _tdsService;

    public TdsController(TdsService tdsService)
    {
        _tdsService = tdsService;
    }

    [HttpGet("reports")]
    public async Task<IActionResult> GetTdsReports()
    {
        var result = await _tdsService.GetTdsReportsAsync();
        return Ok(result);
    }

    [HttpGet("returns")]
    public async Task<IActionResult> GetTdsReturns()
    {
        var result = await _tdsService.GetTdsReturnsAsync();
        return Ok(result);
    }

    [HttpGet("quarterly")]
    public async Task<IActionResult> GetTdsQuarterly([FromQuery] int quarter, [FromQuery] int year)
    {
        var result = await _tdsService.GetTdsQuarterlyAsync(quarter, year);
        return Ok(result);
    }
}