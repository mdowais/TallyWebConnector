using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Groups")]
public class GroupsController : ControllerBase
{
    private readonly GroupLogic _groupLogic;

    public GroupsController(GroupLogic groupLogic)
    {
        _groupLogic = groupLogic;
    }

    [HttpGet]
    public async Task<IActionResult> GetGroups()
    {
        var result = await _groupLogic.GetGroupsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGroupById(string id)
    {
        var result = await _groupLogic.GetGroupByIdAsync(id);
        return Ok(result);
    }
}