using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Ledgers")]
public class LedgersController : ControllerBase
{
    private readonly LedgerService _ledgerService;

    public LedgersController(LedgerService ledgerService)
    {
        _ledgerService = ledgerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLedgers()
    {
        var result = await _ledgerService.GetLedgersAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLedgerById(string id)
    {
        var result = await _ledgerService.GetLedgerByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("{id}/balance")]
    public async Task<IActionResult> GetLedgerBalance(string id)
    {
        var result = await _ledgerService.GetLedgerBalanceAsync(id);
        return Ok(result);
    }
}