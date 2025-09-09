using TallyConnector.Services;
using TallyConnector.Core.Models;

namespace TallyWebConnector.Services;

public class CompanyLogic
{
    private readonly TallyService _tallyService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CompanyLogic(TallyService tallyService, IHttpContextAccessor httpContextAccessor)
    {
        _tallyService = tallyService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IEnumerable<object>> GetCompaniesAsync()
    {
        try
        {
            // Implementation to get companies from Tally
            var companies = await _tallyService.GetCompaniesAsync();
            return companies?.Cast<object>() ?? new List<object>();
        }
        catch
        {
            return new List<object>();
        }
    }

    public async Task<object?> GetCompanyByIdAsync(string companyId)
    {
        try
        {
            // Implementation to get specific company
            var companies = await _tallyService.GetCompaniesAsync();
            return companies?.FirstOrDefault(c => c.Name == companyId);
        }
        catch
        {
            return null;
        }
    }

    public async Task<object?> GetCurrentCompanyAsync()
    {
        try
        {
            // Use selected company from context if available
            var context = _httpContextAccessor.HttpContext;
            var selectedCompanyId = Context.CompanyContextAccessor.GetSelectedCompanyId(context!);
            if (!string.IsNullOrEmpty(selectedCompanyId))
            {
                // You may need to update TallyService to support company selection
                return await _tallyService.GetCompanyInfoAsync(selectedCompanyId);
            }
            // Fallback to license info
            return await _tallyService.GetLicenseInfoAsync();
        }
        catch
        {
            return null;
        }
    }
}