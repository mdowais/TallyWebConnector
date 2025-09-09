using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Reports")]
public class ReportsController : ControllerBase
{
    private readonly ReportService _reportService;

    public ReportsController(ReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("balance-sheet")]
    public async Task<IActionResult> GetBalanceSheet([FromQuery] DateTime? asOnDate = null)
    {
        var result = await _reportService.GetBalanceSheetAsync(asOnDate);
        return Ok(result);
    }

    [HttpGet("profit-loss")]
    public async Task<IActionResult> GetProfitAndLoss([FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
    {
        var result = await _reportService.GetProfitAndLossAsync(fromDate, toDate);
        return Ok(result);
    }

    [HttpGet("trial-balance")]
    public async Task<IActionResult> GetTrialBalance([FromQuery] DateTime? asOnDate = null)
    {
        var result = await _reportService.GetTrialBalanceAsync(asOnDate);
        return Ok(result);
    }

    [HttpGet("cash-flow")]
    public async Task<IActionResult> GetCashFlow([FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
    {
        var result = await _reportService.GetCashFlowAsync(fromDate, toDate);
        return Ok(result);
    }
}