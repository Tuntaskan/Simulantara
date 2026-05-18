using Simulantara.ViewModels;

namespace Simulantara.Views;

public partial class ProfilePage : ContentPage
{
    private readonly ProfileViewModel _viewModel;

    public ProfilePage(ProfileViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_viewModel.LoadProfileCommand.CanExecute(null))
        {
            await _viewModel.LoadProfileCommand.ExecuteAsync(null);
        }
    }
}