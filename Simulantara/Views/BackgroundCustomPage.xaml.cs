using Simulantara.ViewModels;

namespace Simulantara.Views;

public partial class BackgroundCustomPage : ContentPage
{
    private readonly BackgroundCustomViewModel _viewModel;

    public BackgroundCustomPage(
        BackgroundCustomViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadBackgroundsCommand.ExecuteAsync(null);
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
    }

    private async void OnHabitClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(HabitManagePage));
    }

    private async void OnNpcClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NpcCustomPage));
    }
}