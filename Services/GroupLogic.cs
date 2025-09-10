using TallyConnector.Services;
using TallyConnector.Core.Models;

namespace TallyWebConnector.Services;

public class GroupLogic
{
    private readonly TallyService _tallyService;

    public GroupLogic(TallyService tallyService)
    {
        _tallyService = tallyService;
    }

    public async Task<IEnumerable<object>> GetGroupsAsync()
    {
        try
        {
            // Implementation to get groups from Tally
            var groups = await _tallyService.GetGroupsAsync();
            return groups?.Cast<object>() ?? new List<object>();
        }
        catch
        {
            return new List<object>();
        }
    }

    public async Task<object?> GetGroupByIdAsync(string groupId)
    {
        var request = new MasterRequestOptions();
        request.LookupField = MasterLookupField.GUID;
        // Implementation to get specific group
        return await _tallyService.GetGroupAsync(groupId, request);
    }
}