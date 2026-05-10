using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulantara.Models;
using System.Collections.ObjectModel;

namespace Simulantara.ViewModels
{
    public class HabitDetailViewModel : BaseViewModel
    {
        public Habit Habit { get; set; }

        public ObservableCollection<HabitProgress> ProgressList { get; set; }

        public HabitDetailViewModel()
        {
            ProgressList = new ObservableCollection<HabitProgress>();
        }
    }
}