using Simulantara.Services;
using Simulantara.Views;

namespace Simulantara;

public partial class App : Application
{
    private readonly DatabaseService _databaseService;
    private readonly IServiceProvider _serviceProvider;

    public App(
        DatabaseService databaseService,
        IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _databaseService = databaseService;
        _serviceProvider = serviceProvider;

        MainPage = new ContentPage
        {
            Content = new ActivityIndicator
            {
                IsRunning = true,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            }
        };

        InitializeApp();
    }

    private async void InitializeApp()
    {
        await _databaseService.InitAsync();

        var user = await _databaseService.GetUserAsync();

        if (user == null)
        {
            MainPage = new NavigationPage(
                _serviceProvider.GetRequiredService<InputProfilePage>());
        }
        else
        {
            MainPage = _serviceProvider.GetRequiredService<AppShell>();
        }
    }
}