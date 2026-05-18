using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulantara.Models;

namespace Simulantara.Services;

public class ProgressService
{
    private readonly DatabaseService _database;
    private readonly LevelService _levelService;
    private readonly StreakService _streakService;

    public ProgressService(
        DatabaseService database,
        LevelService levelService,
        StreakService streakService)
    {
        _database = database;
        _levelService = levelService;
        _streakService = streakService;
    }

    public async Task AddProgressAsync(
        Habit habit,
        string? note = null)
    {
        await _database.InitAsync();

        var today = DateTime.Now.ToString("yyyy-MM-dd");

        var progresses =
            await _database.GetProgressByHabitAsync(habit.Id);

        bool alreadyInputToday = progresses.Any(x =>
            x.ProgressDate == today);

        if (alreadyInputToday)
            return;

        var progress = new HabitProgress
        {
            HabitId = habit.Id,
            ProgressDate = today,
            Note = note
        };

        await _database.SaveProgressAsync(progress);

        // update streak
        await _streakService.UpdateStreakAsync(habit);

        // tambah exp
        await _levelService.AddExpAsync(10);
    }
}