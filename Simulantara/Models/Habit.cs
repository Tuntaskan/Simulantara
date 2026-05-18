using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Simulantara.Models;

public class Habit
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public int CategoryId { get; set; }

    public int Streak { get; set; } = 0;

    public string? LastProgressDate { get; set; }

    public string CreatedAt { get; set; }
        = DateTime.Now.ToString("yyyy-MM-dd");

    [Ignore]
    public Category? Category { get; set; }
}