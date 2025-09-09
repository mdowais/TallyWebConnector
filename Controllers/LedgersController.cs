using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Ledgers")]
public class LedgersController : ControllerBase
{
    private readonly LedgerLogic _ledgerLogic;

    public LedgersController(LedgerLogic ledgerLogic)
    {
        _ledgerLogic = ledgerLogic;
    }

    [HttpGet]
    public async Task<IActionResult> GetLedgers()
    {
        var result = await _ledgerLogic.GetLedgersAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLedgerById(string id)
    {
        var result = await _ledgerLogic.GetLedgerByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("{id}/balance")]
    public async Task<IActionResult> GetLedgerBalance(string id)
    {
        var result = await _ledgerLogic.GetLedgerBalanceAsync(id);
        return Ok(result);
    }
}