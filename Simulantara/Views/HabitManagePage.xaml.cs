using Simulantara.ViewModels;

namespace Simulantara.Views;

public partial class HabitManagePage : ContentPage
{
    private readonly HabitManageViewModel _viewModel;

    public HabitManagePage(HabitManageViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Load semua habit dari database
        await _viewModel.LoadHabitsCommand.ExecuteAsync(null);
    }
}