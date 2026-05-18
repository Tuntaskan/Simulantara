using Simulantara.Models;

namespace Simulantara.Services;

public class HabitService
{
    private readonly DatabaseService _database;

    public HabitService(DatabaseService database)
    {
        _database = database;
    }

    public async Task<List<Habit>> GetHabitsAsync()
    {
        await _database.InitAsync();

        var habits = await _database.GetHabitsAsync();

        foreach (var habit in habits)
        {
            habit.Category =
                await _database.GetCategoryByIdAsync(
                    habit.CategoryId);
        }

        return habits;
    }

    public async Task AddHabitAsync(Habit habit)
    {
        await _database.InitAsync();

        await _database.SaveHabitAsync(habit);
    }

    public async Task UpdateHabitAsync(Habit habit)
    {
        await _database.InitAsync();

        await _database.SaveHabitAsync(habit);
    }

    public async Task DeleteHabitAsync(Habit habit)
    {
        await _database.InitAsync();

        await _database.DeleteHabitAsync(habit);
    }
}