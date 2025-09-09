using TallyConnector.Services;
using TallyConnector.Core.Models;

namespace TallyWebConnector.Services;

public class LedgerLogic
{
    private readonly TallyService _tallyService;
        private readonly IHttpContextAccessor _httpContextAccessor;
    
        public LedgerLogic(TallyService tallyService, IHttpContextAccessor httpContextAccessor)
        {
            _tallyService = tallyService;
            _httpContextAccessor = httpContextAccessor;
        }

    public async Task<IEnumerable<object>> GetLedgersAsync()
    {
        try
        {
            var context = _httpContextAccessor.HttpContext;
            var selectedCompanyId = Context.CompanyContextAccessor.GetSelectedCompanyId(context!);
            var ledgers = selectedCompanyId != null
                ? await _tallyService.GetLedgersAsync(selectedCompanyId)
                : await _tallyService.GetLedgersAsync();
            return ledgers?.Cast<object>() ?? new List<object>();
        }
        catch
        {
            return new List<object>();
        }
    }

    public async Task<object?> GetLedgerByIdAsync(string ledgerId)
                    // Use selected company from context if available
                    var context = _httpContextAccessor.HttpContext;
                    var selectedCompanyId = Context.CompanyContextAccessor.GetSelectedCompanyId(context!);
                    // TODO: Pass selectedCompanyId to TallyConnector if supported
        // Implementation to get specific ledger
        return await _tallyService.GetLedgerAsync(ledgerId);
    }

    public async Task<IEnumerable<object>> GetLedgerBalanceAsync(string ledgerId)
    {
        // Implementation to get ledger balance
        // This would typically involve calling Tally's balance query
        return await Task.FromResult(new List<object>());
    }
}