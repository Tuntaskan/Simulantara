using Simulantara.ViewModels;

namespace Simulantara.Views;

public partial class AddHabitPage : ContentPage
{
    private readonly AddHabitViewModel _viewModel;

    public AddHabitPage(AddHabitViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadCategories();

        await _viewModel.LoadBackgroundAsync();
    }
}