using Microsoft.Extensions.Logging;
using Simulantara.ViewModels;
using Simulantara.Services;
using Simulantara.Views;

namespace Simulantara
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<GameService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<FinancePage>();
            builder.Services.AddSingleton<HabitPage>();
            builder.Services.AddSingleton<NPCPage>();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

