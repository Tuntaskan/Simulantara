using Simulantara.Views;

namespace Simulantara;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register Routes
        Routing.RegisterRoute(nameof(InputProfilePage), typeof(InputProfilePage));
        Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
        Routing.RegisterRoute(nameof(HabitManagePage), typeof(HabitManagePage));
        Routing.RegisterRoute(nameof(AddHabitPage), typeof(AddHabitPage));
        Routing.RegisterRoute(nameof(HabitDetailPage), typeof(HabitDetailPage));
        Routing.RegisterRoute(nameof(ManageCategoryPage), typeof(ManageCategoryPage));
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        Routing.RegisterRoute(nameof(NpcCustomPage), typeof(NpcCustomPage));
        Routing.RegisterRoute(nameof(BackgroundCustomPage), typeof(BackgroundCustomPage));
    }
}