using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using WeatherApp.Pages;
using WeatherApp.Services;
using WeatherApp.ViewModels;

namespace WeatherApp
{
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

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IWeatherService, WeatherService>();
            builder.Services.AddSingleton<SettingsService>();
            builder.Services.AddSingleton<CurrentWeatherService>();

            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<FavouritesViewModel>();
            builder.Services.AddTransient<SettingsViewModel>();
            builder.Services.AddTransient<DetailsWeatherViewModel>();

            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<FavouritesPage>();
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<DetailsWeatherPage>();

            return builder.Build();
        }
    }
}