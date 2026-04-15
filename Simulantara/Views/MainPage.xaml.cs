using Simulantara.ViewsModels;
using Simulantara.Views;

namespace Simulantara;

public partial class MainPage : ContentPage
{
    public MainPage(MainPage vm)
    {
        this.InitializeComponent();
        BindingContext = vm;
    }

    void InitializeComponent()
    {
       
    }
}