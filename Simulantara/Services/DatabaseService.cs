using SQLite;
using Simulantara.Models;

namespace Simulantara.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection _database;

    public async Task InitAsync()
    {
        if (_database != null)
            return;

        string dbPath = Path.Combine(
            FileSystem.AppDataDirectory,
            "simulantara.db");

        _database = new SQLiteAsyncConnection(dbPath);

        // =========================
        // TABLES
        // =========================
        await _database.CreateTableAsync<User>();
        await _database.CreateTableAsync<Habit>();
        await _database.CreateTableAsync<Category>();
        await _database.CreateTableAsync<HabitProgress>();
        await _database.CreateTableAsync<NPC>();
        await _database.CreateTableAsync<Background>();

        // Seed default data
        await SeedCategoriesAsync();
        await SeedNPCsAsync();
        await SeedBackgroundsAsync();
    }

    // ======================================================
    // USER
    // ======================================================

    public async Task<User?> GetUserAsync()
    {
        return await _database.Table<User>()
            .FirstOrDefaultAsync();
    }

    public async Task<int> SaveUserAsync(User user)
    {
        if (user.Id != 0)
            return await _database.UpdateAsync(user);

        return await _database.InsertAsync(user);
    }

    // ======================================================
    // HABITS
    // ======================================================

    public async Task<List<Habit>> GetHabitsAsync()
    {
        return await _database.Table<Habit>().ToListAsync();
    }

    public async Task<int> SaveHabitAsync(Habit habit)
    {
        if (habit.Id != 0)
            return await _database.UpdateAsync(habit);

        return await _database.InsertAsync(habit);
    }

    public async Task<int> DeleteHabitAsync(Habit habit)
    {
        return await _database.DeleteAsync(habit);
    }

    // ======================================================
    // CATEGORY
    // ======================================================

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _database.Table<Category>().ToListAsync();
    }

    public async Task<int> SaveCategoryAsync(Category category)
    {
        if (category.Id != 0)
            return await _database.UpdateAsync(category);

        return await _database.InsertAsync(category);
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _database.Table<Category>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    // ======================================================
    // PROGRESS
    // ======================================================

    public async Task<List<HabitProgress>> GetProgressByHabitAsync(int habitId)
    {
        return await _database.Table<HabitProgress>()
            .Where(x => x.HabitId == habitId)
            .ToListAsync();
    }

    public async Task<int> SaveProgressAsync(HabitProgress progress)
    {
        return await _database.InsertAsync(progress);
    }

    // ======================================================
    // NPC
    // ======================================================

    public async Task<List<NPC>> GetNPCsAsync()
    {
        return await _database.Table<NPC>().ToListAsync();
    }

    // ======================================================
    // BACKGROUND
    // ======================================================

    public async Task<List<Background>> GetBackgroundsAsync()
    {
        return await _database.Table<Background>().ToListAsync();
    }

    // ======================================================
    // SEED DATA
    // ======================================================

    private async Task SeedCategoriesAsync()
    {
        var categories = await GetCategoriesAsync();

        if (categories.Count > 0)
            return;

        var defaultCategories = new List<Category>
        {
            new Category { Name = "Study", IsDefault = true },
            new Category { Name = "Health", IsDefault = true },
            new Category { Name = "Spiritual", IsDefault = true },
            new Category { Name = "Fitness", IsDefault = true },
            new Category { Name = "Productivity", IsDefault = true }
        };

        await _database.InsertAllAsync(defaultCategories);
    }

    private async Task SeedNPCsAsync()
    {
        var npcs = await GetNPCsAsync();

        if (npcs.Count > 0)
            return;

        var defaultNPCs = new List<NPC>
        {
            new NPC
            {
                Name = "Default NPC",
                Image = "hutao.png",
                UnlockLevel = 1
            },
            new NPC
            {
                Name = "Knight NPC",
                Image = "hutao.png",
                UnlockLevel = 10
            },
            new NPC
            {
                Name = "Mage NPC",
                Image = "hutao.png",
                UnlockLevel = 20
            }
        };

        await _database.InsertAllAsync(defaultNPCs);
    }

    private async Task SeedBackgroundsAsync()
    {
        var backgrounds = await GetBackgroundsAsync();

        if (backgrounds.Count > 0)
            return;

        var defaultBackgrounds = new List<Background>
        {
            new Background
            {
                Name = "Default Background",
                Image = "background0.jpeg",
                UnlockLevel = 1
            },
            new Background
            {
                Name = "Forest",
                Image = "background0.jpeg",
                UnlockLevel = 10
            },
            new Background
            {
                Name = "Castle",
                Image = "background0.jpeg",
                UnlockLevel = 20
            }
        };

        await _database.InsertAllAsync(defaultBackgrounds);
    }

    public async Task<NPC?> GetNpcByIdAsync(int id)
    {
        return await _database.Table<NPC>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Background?> GetBackgroundByIdAsync(int id)
    {
        return await _database.Table<Background>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}