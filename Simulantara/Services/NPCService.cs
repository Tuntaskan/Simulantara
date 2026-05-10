using Simulantara.Models;

namespace Simulantara.Services;

public class NPCService
{
    private readonly DatabaseService _databaseService;

    public NPCService(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task<NPCMessage?> GetRandomMessageAsync()
    {
        var messages = await _databaseService
            .GetConnection()
            .Table<NPCMessage>()
            .ToListAsync();

        if (!messages.Any())
            return null;

        Random random = new();

        return messages[random.Next(messages.Count)];
    }
}