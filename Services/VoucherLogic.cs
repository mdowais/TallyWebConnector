using TallyConnector.Services;
using TallyConnector.Core.Models;

namespace TallyWebConnector.Services;

public class VoucherLogic
{
    private readonly TallyService _tallyService;

    public VoucherLogic(TallyService tallyService)
    {
        _tallyService = tallyService;
    }

    public async Task<IEnumerable<object>> GetVouchersAsync()
    {
        try
        {
            // Implementation to get vouchers from Tally
            var vouchers = await _tallyService.GetVouchersAsync();
            return vouchers?.Cast<object>() ?? new List<object>();
        }
        catch
        {
            return new List<object>();
        }
    }

    public async Task<IEnumerable<object>> GetVoucherTypesAsync()
    {
        try
        {
            // Implementation to get voucher types from Tally
            var voucherTypes = await _tallyService.GetVoucherTypesAsync();
            return voucherTypes?.Cast<object>() ?? new List<object>();
        }
        catch
        {
            return new List<object>();
        }
    }

    public async Task<object?> GetVoucherByIdAsync(string voucherId)
    {
        // Implementation to get specific voucher
        return await _tallyService.GetVoucherAsync(voucherId);
    }
// Returns vouchers for a ledger
public async Task<IEnumerable<object>> GetVouchersByLedgerIdAsync(string ledgerId)
{
    // TODO: Implement actual logic to fetch vouchers by ledgerId
    return new List<object>();
}
}