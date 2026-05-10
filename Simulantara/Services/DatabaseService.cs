using SQLite;
using Simulantara.Models;

namespace Simulantara.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _database;

    public DatabaseService()
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "simulantara.db3");

        _database = new SQLiteAsyncConnection(dbPath);

        InitializeDatabase();
    }

    private async void InitializeDatabase()
    {
        await _database.CreateTableAsync<User>();
        await _database.CreateTableAsync<HabitCategory>();
        await _database.CreateTableAsync<Habit>();
        await _database.CreateTableAsync<HabitProgress>();
        await _database.CreateTableAsync<NPCMessage>();

        await SeedDefaultCategories();
        await SeedNPCMessages();
    }

    public SQLiteAsyncConnection GetConnection()
    {
        return _database;
    }

    private async Task SeedDefaultCategories()
    {
        var categories = await _database.Table<HabitCategory>().ToListAsync();

        if (categories.Count == 0)
        {
            await _database.InsertAllAsync(new List<HabitCategory>
            {
                new HabitCategory
                {
                    CategoryName = "Study",
                    Icon = "study.png",
                    IsDefault = true
                },

                new HabitCategory
                {
                    CategoryName = "Health",
                    Icon = "health.png",
                    IsDefault = true
                },

                new HabitCategory
                {
                    CategoryName = "Spiritual",
                    Icon = "spiritual.png",
                    IsDefault = true
                },

                new HabitCategory
                {
                    CategoryName = "Fitness",
                    Icon = "fitness.png",
                    IsDefault = true
                },

                new HabitCategory
                {
                    CategoryName = "Productivity",
                    Icon = "productivity.png",
                    IsDefault = true
                }
            });
        }
    }

    private async Task SeedNPCMessages()
    {
        var messages = await _database.Table<NPCMessage>().ToListAsync();

        if (messages.Count == 0)
        {
            await _database.InsertAllAsync(new List<NPCMessage>
            {
                new NPCMessage
                {
                    MessageText = "Semangat! Progress kecil tetap berarti!",
                    MoodType = "Happy"
                },

                new NPCMessage
                {
                    MessageText = "Kamu makin dekat dengan versi terbaikmu!",
                    MoodType = "Motivation"
                },

                new NPCMessage
                {
                    MessageText = "Jangan berhenti sekarang!",
                    MoodType = "Energetic"
                }
            });
        }
    }
}