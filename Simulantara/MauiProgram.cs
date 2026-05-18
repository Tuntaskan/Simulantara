using Microsoft.Extensions.Logging;
using Simulantara.Services;
using Simulantara.ViewModels;
using Simulantara.Views;
using CommunityToolkit.Maui;

namespace Simulantara;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<AppShell>();

        // =========================
        // SERVICES
        // =========================
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<HabitService>();
        builder.Services.AddSingleton<ProgressService>();
        builder.Services.AddSingleton<LevelService>();
        builder.Services.AddSingleton<NotificationService>();
        builder.Services.AddSingleton<NPCService>();
        builder.Services.AddSingleton<StreakService>();

        // =========================
        // VIEWMODELS
        // =========================
        builder.Services.AddTransient<InputProfileViewModel>();
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<HabitManageViewModel>();
        builder.Services.AddTransient<HabitDetailViewModel>();
        builder.Services.AddTransient<AddHabitViewModel>();
        builder.Services.AddTransient<ManageCategoryViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<NpcCustomViewModel>();
        builder.Services.AddTransient<BackgroundCustomViewModel>();

        // =========================
        // VIEWS
        // =========================
        builder.Services.AddTransient<InputProfilePage>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<HabitManagePage>();
        builder.Services.AddTransient<HabitDetailPage>();
        builder.Services.AddTransient<AddHabitPage>();
        builder.Services.AddTransient<ManageCategoryPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<NpcCustomPage>();
        builder.Services.AddTransient<BackgroundCustomPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}