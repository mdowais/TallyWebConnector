using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Godowns")]
public class GodownsController : ControllerBase
{
    private readonly GodownService _godownService;

    public GodownsController(GodownService godownService)
    {
        _godownService = godownService;
    }

    [HttpGet]
    public async Task<IActionResult> GetGodowns()
    {
        var result = await _godownService.GetGodownsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGodownById(string id)
    {
        var result = await _godownService.GetGodownByIdAsync(id);
        return Ok(result);
    }
}