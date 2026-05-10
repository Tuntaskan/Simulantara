using Simulantara.Models;

namespace Simulantara.Services;

public class HabitService
{
    private readonly DatabaseService _databaseService;

    public HabitService(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    // HABIT CRUD

    public async Task<List<Habit>> GetHabitsAsync()
    {
        return await _databaseService
            .GetConnection()
            .Table<Habit>()
            .ToListAsync();
    }

    public async Task<int> SaveHabitAsync(Habit habit)
    {
        if (habit.HabitId != 0)
        {
            return await _databaseService
                .GetConnection()
                .UpdateAsync(habit);
        }

        habit.CreatedAt = DateTime.Now;
        habit.IsActive = true;

        return await _databaseService
            .GetConnection()
            .InsertAsync(habit);
    }

    public async Task<int> DeleteHabitAsync(Habit habit)
    {
        return await _databaseService
            .GetConnection()
            .DeleteAsync(habit);
    }

    // CATEGORY

    public async Task<List<HabitCategory>> GetCategoriesAsync()
    {
        return await _databaseService
            .GetConnection()
            .Table<HabitCategory>()
            .ToListAsync();
    }

    public async Task<int> SaveCategoryAsync(HabitCategory category)
    {
        return await _databaseService
            .GetConnection()
            .InsertAsync(category);
    }

    // PROGRESS

    public async Task<List<HabitProgress>> GetHabitProgressAsync(int habitId)
    {
        return await _databaseService
            .GetConnection()
            .Table<HabitProgress>()
            .Where(x => x.HabitId == habitId)
            .ToListAsync();
    }

    public async Task<int> AddProgressAsync(HabitProgress progress)
    {
        return await _databaseService
            .GetConnection()
            .InsertAsync(progress);
    }
}