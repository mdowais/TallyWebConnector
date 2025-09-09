using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/stock-items")]
[Tags("Stock Items")]
public class StockItemsController : ControllerBase
{
    private readonly StockItemLogic _stockItemService;

    public StockItemsController(StockItemLogic stockItemService)
    {
        _stockItemService = stockItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStockItems()
    {
        var result = await _stockItemService.GetStockItemsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStockItemById(string id)
    {
        var result = await _stockItemService.GetStockItemByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("{id}/balance")]
    public async Task<IActionResult> GetStockItemBalance(string id)
    {
        var result = await _stockItemService.GetStockItemBalanceAsync(id);
        return Ok(result);
    }
}