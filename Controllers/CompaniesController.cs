using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Companies")]
public class CompaniesController : ControllerBase
{
    private readonly CompanyService _companyService;

    public CompaniesController(CompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var result = await _companyService.GetCompaniesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyById(string id)
    {
        var result = await _companyService.GetCompanyByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("current")]
    public async Task<IActionResult> GetCurrentCompany()
    {
        var result = await _companyService.GetCurrentCompanyAsync();
        return Ok(result);
    }
}