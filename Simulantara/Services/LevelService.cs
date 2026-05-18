using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulantara.Models;

namespace Simulantara.Services;

public class LevelService
{
    private readonly DatabaseService _database;

    public LevelService(DatabaseService database)
    {
        _database = database;
    }

    public async Task AddExpAsync(int amount)
    {
        await _database.InitAsync();

        var user = await _database.GetUserAsync();

        if (user == null)
            return;

        user.Exp += amount;

        while (user.Exp >= 100)
        {
            user.Exp -= 100;
            user.Level++;
        }

        await _database.SaveUserAsync(user);
    }
}