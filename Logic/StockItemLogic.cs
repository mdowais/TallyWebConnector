using TallyConnector.Services;
using TallyConnector.Core.Models;

namespace TallyWebConnector.Services;

public class StockItemLogic
{
    private readonly TallyService _tallyService;

    public StockItemLogic(TallyService tallyService)
    {
        _tallyService = tallyService;
    }

    public async Task<IEnumerable<object>> GetStockItemsAsync()
    {
        try
        {
            var context = _httpContextAccessor.HttpContext;
            var selectedCompanyId = Context.CompanyContextAccessor.GetSelectedCompanyId(context!);
            var stockItems = selectedCompanyId != null
                ? await _tallyService.GetStockItemsAsync(selectedCompanyId)
                : await _tallyService.GetStockItemsAsync();
            return stockItems?.Cast<object>() ?? new List<object>();
        }
        catch
        {
            return new List<object>();
        }
    }

    public async Task<object?> GetStockItemByIdAsync(string stockItemId)
    {
        // Implementation to get specific stock item
        return await _tallyService.GetStockItemAsync(stockItemId);
    }

    public async Task<IEnumerable<object>> GetStockItemBalanceAsync(string stockItemId)
    {
        // Implementation to get stock item balance
        return await Task.FromResult(new List<object>());
    }
}