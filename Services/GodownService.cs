using TallyConnector.Services;
using TallyConnector.Core.Models;

namespace TallyWebConnector.Services;

public class GodownService
{
    private readonly TallyService _tallyService;

    public GodownService(TallyService tallyService)
    {
        _tallyService = tallyService;
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

    public async Task<object?> GetGodownByIdAsync(string godownId)
    {
        // Implementation to get specific godown
        return await _tallyService.GetGodownAsync(godownId);
    }
}