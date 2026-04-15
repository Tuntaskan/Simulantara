using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulantara.Models;

namespace Simulantara.Services;

public class GameService
{
    public User CurrentUser { get; set; }

    public GameService()
    {
        CurrentUser = new User();
    }

    public void AddExp(int amount)
    {
        CurrentUser.AddExp(amount);
    }
}