using Simulantara.Models;

namespace Simulantara.Services;

public class StreakService
{
    private readonly DatabaseService _databaseService;
    private readonly UserService _userService;

    public StreakService(
        DatabaseService databaseService,
        UserService userService)
    {
        _databaseService = databaseService;
        _userService = userService;
    }

    public async Task UpdateStreakAsync()
    {
        var user = await _userService.GetUserAsync();

        if (user == null)
            return;

        var latestProgress = await _databaseService
            .GetConnection()
            .Table<HabitProgress>()
            .OrderByDescending(x => x.ProgressDate)
            .FirstOrDefaultAsync();

        if (latestProgress == null)
            return;

        var difference = (DateTime.Now.Date - latestProgress.ProgressDate.Date).Days;

        if (difference == 1)
        {
            user.CurrentStreak++;
        }
        else if (difference > 1)
        {
            user.CurrentStreak = 0;
        }

        if (user.CurrentStreak > user.HighestStreak)
        {
            user.HighestStreak = user.CurrentStreak;
        }

        await _userService.SaveUserAsync(user);
    }
}