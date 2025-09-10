using Microsoft.AspNetCore.Mvc;
using TallyConnector.Core.Models;
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
// Ledgers and Vouchers endpoints for groups
[ApiController]
[Route("groups/{groupId}/ledgers")]
public class GroupLedgersController : ControllerBase
{
    private readonly LedgerLogic _ledgerLogic;

    public GroupLedgersController(LedgerLogic ledgerLogic)
    {
        _ledgerLogic = ledgerLogic;
    }

    [HttpGet]
    public async Task<IActionResult> GetLedgersForGroup(string groupId)
    {
        var ledgers = await _ledgerLogic.GetLedgersByGroupIdAsync(groupId);
        return Ok(ledgers);
    }

    [HttpGet("{ledgerId}/vouchers")]
    public async Task<IActionResult> GetVouchersForLedger(string groupId, string ledgerId, [FromServices] VoucherLogic voucherLogic)
    {
        var vouchers = await voucherLogic.GetVouchersByLedgerIdAsync(ledgerId);
        return Ok(vouchers);
    }
}