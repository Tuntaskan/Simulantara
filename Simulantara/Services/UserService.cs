using Simulantara.Models;

namespace Simulantara.Services;

public class UserService
{
    private readonly DatabaseService _databaseService;

    public UserService(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task<User?> GetUserAsync()
    {
        return await _databaseService
            .GetConnection()
            .Table<User>()
            .FirstOrDefaultAsync();
    }

    public async Task<int> SaveUserAsync(User user)
    {
        if (user.UserId != 0)
        {
            return await _databaseService
                .GetConnection()
                .UpdateAsync(user);
        }

        user.CreatedAt = DateTime.Now;
        user.Level = 1;
        user.Exp = 0;

        return await _databaseService
            .GetConnection()
            .InsertAsync(user);
    }

    public async Task<int> DeleteUserAsync(User user)
    {
        return await _databaseService
            .GetConnection()
            .DeleteAsync(user);
    }
}