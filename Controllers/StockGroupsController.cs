using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/stock-groups")]
[Tags("Stock Groups")]
public class StockGroupsController : ControllerBase
{
    private readonly StockGroupLogic _stockGroupLogic;

    public StockGroupsController(StockGroupLogic stockGroupLogic)
    {
        _stockGroupLogic = stockGroupLogic;
    }

    [HttpGet]
    public async Task<IActionResult> GetStockGroups()
    {
        var result = await _stockGroupLogic.GetStockGroupsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStockGroupById(string id)
    {
        var result = await _stockGroupLogic.GetStockGroupByIdAsync(id);
        return Ok(result);
    }
}