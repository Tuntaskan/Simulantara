using Simulantara.ViewModels;

namespace Simulantara.Views;

public partial class NpcCustomPage : ContentPage
{
    private readonly NpcCustomViewModel _viewModel;

    public NpcCustomPage(NpcCustomViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadNPCsCommand.ExecuteAsync(null);
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
    }

    private async void OnHabitClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(HabitManagePage));
    }

    private async void OnBackgroundClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BackgroundCustomPage));
    }
}