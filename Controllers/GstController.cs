using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("GST")]
public class GstController : ControllerBase
{
    private readonly GstService _gstService;

    public GstController(GstService gstService)
    {
        _gstService = gstService;
    }

    [HttpGet("reports")]
    public async Task<IActionResult> GetGstReports()
    {
        var result = await _gstService.GetGstReportsAsync();
        return Ok(result);
    }

    [HttpGet("returns")]
    public async Task<IActionResult> GetGstReturns()
    {
        var result = await _gstService.GetGstReturnsAsync();
        return Ok(result);
    }

    [HttpGet("gstr1")]
    public async Task<IActionResult> GetGstr1([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
    {
        var result = await _gstService.GetGstr1Async(fromDate, toDate);
        return Ok(result);
    }

    [HttpGet("gstr3b")]
    public async Task<IActionResult> GetGstr3b([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
    {
        var result = await _gstService.GetGstr3bAsync(fromDate, toDate);
        return Ok(result);
    }
}