using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Simulantara.Models
{
    public class HabitProgress
    {
        [PrimaryKey, AutoIncrement]
        public int ProgressId { get; set; }

        public int HabitId { get; set; }

        public DateTime ProgressDate { get; set; }

        public string Note { get; set; }

        public int ExpEarned { get; set; } = 10;

        public bool IsCompleted { get; set; }
    }
}