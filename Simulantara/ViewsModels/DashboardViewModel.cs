using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulantara.Models;
using System.Collections.ObjectModel;

namespace Simulantara.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public ObservableCollection<Habit> Habits { get; set; }

        public string NPCBubbleMessage { get; set; }

        public int UserLevel { get; set; }

        public int UserExp { get; set; }

        public int CurrentStreak { get; set; }

        public DashboardViewModel()
        {
            Habits = new ObservableCollection<Habit>();

            NPCBubbleMessage = "Semangat! Sedikit progress tetap progress.";

            UserLevel = 1;
            UserExp = 20;
            CurrentStreak = 3;
        }
    }
}