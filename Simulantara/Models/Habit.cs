using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulantara.Models;

public class Habit
{
    public string Name { get; set; }
    public bool IsCompleted { get; set; }

    public int ExpReward => 10;
}