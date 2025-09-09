using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Units")]
public class UnitsController : ControllerBase
{
    private readonly UnitLogic _unitService;

    public UnitsController(UnitLogic unitService)
    {
        _unitService = unitService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUnits()
    {
        var result = await _unitService.GetUnitsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUnitById(string id)
    {
        var result = await _unitService.GetUnitByIdAsync(id);
        return Ok(result);
    }
}