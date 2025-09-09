using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("GST")]
public class GstController : ControllerBase
{
    private readonly GstLogic _gstLogic;

    public GstController(GstLogic gstLogic)
    {
        _gstLogic = gstLogic;
    }

    [HttpGet("reports")]
    public async Task<IActionResult> GetGstReports()
    {
        var result = await _gstLogic.GetGstReportsAsync();
        return Ok(result);
    }

    [HttpGet("returns")]
    public async Task<IActionResult> GetGstReturns()
    {
        var result = await _gstLogic.GetGstReturnsAsync();
        return Ok(result);
    }

    [HttpGet("gstr1")]
    public async Task<IActionResult> GetGstr1([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
    {
        var result = await _gstLogic.GetGstr1Async(fromDate, toDate);
        return Ok(result);
    }

    [HttpGet("gstr3b")]
    public async Task<IActionResult> GetGstr3b([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
    {
        var result = await _gstLogic.GetGstr3bAsync(fromDate, toDate);
        return Ok(result);
    }
}