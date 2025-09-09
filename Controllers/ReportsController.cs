using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Reports")]
public class ReportsController : ControllerBase
{
    private readonly ReportLogic _reportLogic;

    public ReportsController(ReportLogic reportLogic)
    {
        _reportLogic = reportLogic;
    }

    [HttpGet("balance-sheet")]
    public async Task<IActionResult> GetBalanceSheet([FromQuery] DateTime? asOnDate = null)
    {
        var result = await _reportLogic.GetBalanceSheetAsync(asOnDate);
        return Ok(result);
    }

    [HttpGet("profit-loss")]
    public async Task<IActionResult> GetProfitAndLoss([FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
    {
        var result = await _reportLogic.GetProfitAndLossAsync(fromDate, toDate);
        return Ok(result);
    }

    [HttpGet("trial-balance")]
    public async Task<IActionResult> GetTrialBalance([FromQuery] DateTime? asOnDate = null)
    {
        var result = await _reportLogic.GetTrialBalanceAsync(asOnDate);
        return Ok(result);
    }

    [HttpGet("cash-flow")]
    public async Task<IActionResult> GetCashFlow([FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
    {
        var result = await _reportLogic.GetCashFlowAsync(fromDate, toDate);
        return Ok(result);
    }
}