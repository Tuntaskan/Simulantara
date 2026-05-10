using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulantara.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Simulantara.ViewModels
{
    public class AddHabitViewModel : BaseViewModel
    {
        public string HabitName { get; set; }

        public string HabitDetail { get; set; }

        public HabitCategory SelectedCategory { get; set; }

        public ObservableCollection<HabitCategory> Categories { get; set; }

        public ICommand SaveHabitCommand { get; set; }

        public AddHabitViewModel()
        {
            Categories = new ObservableCollection<HabitCategory>();
        }
    }
}