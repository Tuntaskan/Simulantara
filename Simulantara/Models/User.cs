using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Simulantara.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        public string Gender { get; set; }

        public string ProfilePhoto { get; set; }

        public int Level { get; set; } = 1;

        public int Exp { get; set; } = 0;

        public int CurrentStreak { get; set; } = 0;

        public int HighestStreak { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}