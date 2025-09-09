using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Vouchers")]
public class VouchersController : ControllerBase
{
    private readonly VoucherLogic _voucherService;

    public VouchersController(VoucherLogic voucherService)
    {
        _voucherService = voucherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetVouchers()
    {
        var result = await _voucherService.GetVouchersAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVoucherById(string id)
    {
        var result = await _voucherService.GetVoucherByIdAsync(id);
        return Ok(result);
    }
}

[ApiController]
[Route("api/voucher-types")]
[Tags("Vouchers")]
public class VoucherTypesController : ControllerBase
{
    private readonly VoucherLogic _voucherService;

    public VoucherTypesController(VoucherLogic voucherService)
    {
        _voucherService = voucherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetVoucherTypes()
    {
        var result = await _voucherService.GetVoucherTypesAsync();
        return Ok(result);
    }
}