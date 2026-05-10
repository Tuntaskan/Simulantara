using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulantara.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public string Username { get; set; }

        public string Gender { get; set; }

        public string ProfilePhoto { get; set; }

        public int Level { get; set; }

        public int Exp { get; set; }

        public int HighestStreak { get; set; }
    }
}