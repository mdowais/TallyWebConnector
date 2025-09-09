using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/stock-groups")]
[Tags("Stock Groups")]
public class StockGroupsController : ControllerBase
{
    private readonly StockGroupService _stockGroupService;

    public StockGroupsController(StockGroupService stockGroupService)
    {
        _stockGroupService = stockGroupService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStockGroups()
    {
        var result = await _stockGroupService.GetStockGroupsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStockGroupById(string id)
    {
        var result = await _stockGroupService.GetStockGroupByIdAsync(id);
        return Ok(result);
    }
}