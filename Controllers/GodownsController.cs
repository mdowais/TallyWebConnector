using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Godowns")]
public class GodownsController : ControllerBase
{
    private readonly GodownLogic _godownLogic;

    public GodownsController(GodownLogic godownLogic)
    {
        _godownLogic = godownLogic;
    }

    [HttpGet]
    public async Task<IActionResult> GetGodowns()
    {
        var result = await _godownLogic.GetGodownsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGodownById(string id)
    {
        var result = await _godownLogic.GetGodownByIdAsync(id);
        return Ok(result);
    }
}