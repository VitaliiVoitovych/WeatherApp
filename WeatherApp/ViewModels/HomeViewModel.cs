using WeatherApp.Domain.Models;
using WeatherApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WeatherApp.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly IWeatherService service = new WeatherService();

    [ObservableProperty]
    private Weather weather;
    public HomeViewModel()
    {
        Task.Run(GetWeather);
    }

    private async Task GetWeather()
    {
        Weather = await service.GetCurrentWeatherAsync("Vancouver");
    }

    [RelayCommand]
    private async Task Test()
    {
        Weather = await service.GetCurrentWeatherAsync("Sambir");
    }
}
