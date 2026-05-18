using Simulantara.Models;
using Simulantara.ViewModels;

namespace Simulantara.Views;

public partial class HabitDetailPage : ContentPage
{
    private readonly HabitDetailViewModel _viewModel;

    public HabitDetailPage(HabitDetailViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadProgressesCommand.ExecuteAsync(null);
    }

    public async Task LoadHabit(Habit habit)
    {
        await _viewModel.SetHabit(habit);
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Views.HabitManagePage));
    }
}