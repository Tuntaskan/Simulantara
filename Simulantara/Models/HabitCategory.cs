using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Simulantara.Models
{
    public class HabitCategory
    {
        [PrimaryKey, AutoIncrement]
        public int CategoryId { get; set; }

        public int? UserId { get; set; }

        public string CategoryName { get; set; }

        public string Icon { get; set; }

        public bool IsDefault { get; set; }
    }
}