using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Simulantara.Models;

public class HabitProgress
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int HabitId { get; set; }

    public string ProgressDate { get; set; }
        = DateTime.Now.ToString("yyyy-MM-dd");

    public string? Note { get; set; }
}