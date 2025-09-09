using TallyConnector.Services;
using TallyConnector.Core.Models;

namespace TallyWebConnector.Services;

public class StockGroupLogic
{
    private readonly TallyService _tallyService;

    public StockGroupLogic(TallyService tallyService)
    {
        _tallyService = tallyService;
    }

    public async Task<IEnumerable<object>> GetStockGroupsAsync()
    {
        try
        {
            var context = _httpContextAccessor.HttpContext;
            var selectedCompanyId = Context.CompanyContextAccessor.GetSelectedCompanyId(context!);
            var stockGroups = selectedCompanyId != null
                ? await _tallyService.GetStockGroupsAsync(selectedCompanyId)
                : await _tallyService.GetStockGroupsAsync();
            return stockGroups?.Cast<object>() ?? new List<object>();
        }
        catch
        {
            return new List<object>();
        }
    }

    public async Task<object?> GetStockGroupByIdAsync(string stockGroupId)
    {
        // Implementation to get specific stock group
        return await _tallyService.GetStockGroupAsync(stockGroupId);
    }
}