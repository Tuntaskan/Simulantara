using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Simulantara.Models
{
    public class NPCMessage
    {
        [PrimaryKey, AutoIncrement]
        public int MessageId { get; set; }

        public string MessageText { get; set; }

        public string MoodType { get; set; }
    }
}