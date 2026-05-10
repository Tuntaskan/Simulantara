using Microsoft.Extensions.Logging;
using Simulantara.Services;
using Simulantara.ViewModels;
using Simulantara.Views;

namespace Simulantara;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // DATABASE
        builder.Services.AddSingleton<DatabaseService>();

        // SERVICES
        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<HabitService>();
        builder.Services.AddSingleton<ExpService>();
        builder.Services.AddSingleton<StreakService>();
        builder.Services.AddSingleton<NPCService>();
        builder.Services.AddSingleton<NotificationService>();

        // VIEWMODELS
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<AddHabitViewModel>();
        builder.Services.AddTransient<HabitDetailViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<InputProfileViewModel>();

        // PAGES
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<AddHabitPage>();
        builder.Services.AddTransient<HabitDetailPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<InputProfilePage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}