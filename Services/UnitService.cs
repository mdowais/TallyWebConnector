using TallyConnector.Services;
using TallyConnector.Core.Models;

namespace TallyWebConnector.Services;

public class UnitService
{
    private readonly TallyService _tallyService;

    public UnitService(TallyService tallyService)
    {
        _tallyService = tallyService;
    }

    public async Task<IEnumerable<object>> GetUnitsAsync()
    {
        try
        {
            // Implementation to get units from Tally
            var units = await _tallyService.GetUnitsAsync();
            return units?.Cast<object>() ?? new List<object>();
        }
        catch
        {
            return new List<object>();
        }
    }

    public async Task<object?> GetUnitByIdAsync(string unitId)
    {
        // Implementation to get specific unit
        return await _tallyService.GetUnitAsync(unitId);
    }
}