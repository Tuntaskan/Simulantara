using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Simulantara.Models
{
    public class Habit
    {
        [PrimaryKey, AutoIncrement]
        public int HabitId { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public string HabitName { get; set; }

        public string HabitDetail { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public DateTime StartDate { get; set; } = DateTime.Now;
    }
}