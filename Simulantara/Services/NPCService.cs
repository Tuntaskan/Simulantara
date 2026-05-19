using Simulantara.Models;

namespace Simulantara.Services;

public class NPCService
{
    private readonly DatabaseService _database;

    public NPCService(DatabaseService database)
    {
        _database = database;
    }

    public async Task<List<NPC>> GetAllNPCsAsync()
    {
        await _database.InitAsync();

        return await _database.GetNPCsAsync();
    }

    public async Task<List<Background>>
    GetAllBackgroundsAsync()
    {
        await _database.InitAsync();

        return await _database.GetBackgroundsAsync();
    }

    public async Task<List<NPC>> GetUnlockedNPCsAsync()
    {
        await _database.InitAsync();

        var user = await _database.GetUserAsync();

        if (user == null)
            return new List<NPC>();

        var npcs = await _database.GetNPCsAsync();

        return npcs
            .Where(x => x.UnlockLevel <= user.Level)
            .ToList();
    }

    public async Task<List<Background>> GetUnlockedBackgroundsAsync()
    {
        await _database.InitAsync();
        
        var user = await _database.GetUserAsync();

        if (user == null)
            return new List<Background>();

        var backgrounds =
            await _database.GetBackgroundsAsync();

        return backgrounds
            .Where(x => x.UnlockLevel <= user.Level)
            .ToList();
    }
}