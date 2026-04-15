using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Simulantara.Models;

namespace Simulantara.ViewsModels;
    public class MoodViewModel
    {
        public ObservableCollection<Mood> Moods { get; set; } = new ObservableCollection<Mood>();

    public void Addmood(string feeling) 
    {
        Moods.Add(new Mood
        {
            Feeling = feeling
        });
    }
}
