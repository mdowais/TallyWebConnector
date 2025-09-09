using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Groups")]
public class GroupsController : ControllerBase
{
    private readonly GroupService _groupService;

    public GroupsController(GroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public async Task<IActionResult> GetGroups()
    {
        var result = await _groupService.GetGroupsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGroupById(string id)
    {
        var result = await _groupService.GetGroupByIdAsync(id);
        return Ok(result);
    }
}