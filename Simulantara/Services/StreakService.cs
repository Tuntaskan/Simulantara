using Simulantara.Models;

namespace Simulantara.Services;

public class StreakService
{
    private readonly DatabaseService _database;

    public StreakService(DatabaseService database)
    {
        _database = database;
    }

    public async Task UpdateStreakAsync(Habit habit)
    {
        await _database.InitAsync();

        var today = DateTime.Now.Date;

        if (string.IsNullOrEmpty(habit.LastProgressDate))
        {
            habit.Streak = 1;
        }
        else
        {
            var lastDate =
                DateTime.Parse(habit.LastProgressDate);

            var diff =
                (today - lastDate.Date).Days;

            if (diff == 1)
            {
                habit.Streak++;
            }
            else if (diff > 1)
            {
                habit.Streak = 1;
            }
        }

        habit.LastProgressDate =
            today.ToString("yyyy-MM-dd");

        await _database.SaveHabitAsync(habit);
    }
}