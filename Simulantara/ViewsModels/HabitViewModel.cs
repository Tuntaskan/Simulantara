using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Simulantara.Models;
using Simulantara.Services;

namespace Simulantara.ViewModels;

public class HabitViewModel
{
    public ObservableCollection<Habit> Habits { get; set; }

    private GameService _gameService;

    public HabitViewModel(GameService gameService)
    {
        _gameService = gameService;

        Habits = new ObservableCollection<Habit>
        {
            new Habit { Name = "Olahraga" },
            new Habit { Name = "Belajar" },
            new Habit { Name = "Minum Air" }
        };
    }
}