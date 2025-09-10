using Microsoft.AspNetCore.Mvc;
using TallyWebConnector.Services;

namespace TallyWebConnector.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Companies")]
public class CompaniesController : ControllerBase
{
    private readonly CompanyLogic _companyLogic;

    public CompaniesController(CompanyLogic companyLogic)
    {
        _companyLogic = companyLogic;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var result = await _companyLogic.GetCompaniesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyById(string id)
    {
        var result = await _companyLogic.GetCompanyByIdAsync(id);
        return Ok(result);
    }

    
}