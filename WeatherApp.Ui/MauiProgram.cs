using Microsoft.Extensions.Logging;
using WeatherApp.Domain.Services;
using WeatherApp.Ui.Pages;
using WeatherApp.Ui.ViewModels;

namespace WeatherApp.Ui
{
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

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<IWeatherService, WeatherService>();

            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<FavouritesViewModel>();
            builder.Services.AddTransient<SettingsViewModel>();

            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<FavouritesPage>();
            builder.Services.AddTransient<SettingsPage>();

            return builder.Build();
        }
    }
}