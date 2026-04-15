using Simulantara.ViewModels;

namespace Simulantara.Views;

public partial class HabitPage : ContentPage
{
    public HabitPage(HabitViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}