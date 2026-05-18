using Simulantara.ViewModels;

namespace Simulantara.Views;

public partial class ManageCategoryPage : ContentPage
{
    private readonly ManageCategoryViewModel _viewModel;

    public ManageCategoryPage(
        ManageCategoryViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel
            .LoadCategoriesCommand
            .ExecuteAsync(null);
    }

    private async void BackButton_Clicked(
        object sender,
        EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}