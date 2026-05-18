using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Simulantara.Models;

public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Username { get; set; } = "";

    public Gender Gender { get; set; }

    public string? ProfileImage { get; set; }

    public int Level { get; set; } = 1;

    public int Exp { get; set; } = 0;

    public int CurrentNpcId { get; set; }

    public int CurrentBackgroundId { get; set; }
}