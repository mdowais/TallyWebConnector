using TallyConnector.Services;
using TallyConnector.Core.Models;

namespace TallyWebConnector.Services;

public class CompanyLogic
{
    private readonly TallyService _tallyService;
    

    public CompanyLogic(TallyService tallyService)
    {
        _tallyService = tallyService;
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
            return companies?.FirstOrDefault(c => c.GUID == companyId);
        }
        catch
        {
            return null;
        }
    }

    
}