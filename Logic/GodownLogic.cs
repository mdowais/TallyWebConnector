using TallyConnector.Services;
using TallyConnector.Core.Models;

namespace TallyWebConnector.Services;

public class GodownLogic
{
    private readonly TallyService _tallyService;
        private readonly IHttpContextAccessor _httpContextAccessor;
    
        public GodownLogic(TallyService tallyService, IHttpContextAccessor httpContextAccessor)
        {
            _tallyService = tallyService;
            _httpContextAccessor = httpContextAccessor;
        }

    public async Task<IEnumerable<object>> GetGodownsAsync()
    {
        try
        {
            // Implementation to get godowns from Tally
            var godowns = await _tallyService.GetGodownsAsync();
            return godowns?.Cast<object>() ?? new List<object>();
        }
        catch
        {
            return new List<object>();
        }
    }

            // Use selected company from context if available
            var context = _httpContextAccessor.HttpContext;
            var selectedCompanyId = Context.CompanyContextAccessor.GetSelectedCompanyId(context!);
            // TODO: Pass selectedCompanyId to TallyConnector if supported
    public async Task<object?> GetGodownByIdAsync(string godownId)
    {
        // Implementation to get specific godown
        return await _tallyService.GetGodownAsync(godownId);
    }
}