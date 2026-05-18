using Simulantara.Models;

namespace Simulantara.Services;

public class UserService
{
    private readonly DatabaseService _database;

    public UserService(DatabaseService database)
    {
        _database = database;
    }

    public async Task<User?> GetUserAsync()
    {
        await _database.InitAsync();
        return await _database.GetUserAsync();
    }

    public async Task SaveUserAsync(User user)
    {
        await _database.InitAsync();
        await _database.SaveUserAsync(user);
    }

    public async Task<bool> HasProfileAsync()
    {
        await _database.InitAsync();

        var user = await _database.GetUserAsync();

        return user != null;
    }

    public async Task<NPC?> GetCurrentNpcAsync(int npcId)
    {
        await _database.InitAsync();
        return await _database.GetNpcByIdAsync(npcId);
    }

    public async Task<Background?> GetCurrentBackgroundAsync(int backgroundId)
    {
        await _database.InitAsync();
        return await _database.GetBackgroundByIdAsync(backgroundId);
    }
}