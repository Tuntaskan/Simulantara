using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulantara.Models;

public class User
{
    public string Name { get; set; } = "Player";
    public int Level { get; set; } = 1;
    public int Exp { get; set; } = 0;

    public int MaxExp => Level * 100;

    public void AddExp(int amount)
    {
        Exp += amount;

        if (Exp >= MaxExp)
        {
            Exp -= MaxExp;
            Level++;
        }
    }
}