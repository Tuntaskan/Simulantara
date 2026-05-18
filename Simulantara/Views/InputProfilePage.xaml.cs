using Simulantara.ViewModels;
namespace Simulantara.Views;

public partial class InputProfilePage : ContentPage
{
    public InputProfilePage(InputProfileViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}