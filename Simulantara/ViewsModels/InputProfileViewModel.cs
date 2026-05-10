using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Simulantara.ViewModels
{
    public class InputProfileViewModel : BaseViewModel
    {
        public string Username { get; set; }

        public string Gender { get; set; }

        public string ProfilePhoto { get; set; }

        public ICommand SaveProfileCommand { get; set; }
    }
}