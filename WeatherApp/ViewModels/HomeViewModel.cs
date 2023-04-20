using WeatherApp.Domain.Models;
using WeatherApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace WeatherApp.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    public CurrentWeatherService CurrentWeatherService { get; }

    public HomeViewModel(CurrentWeatherService testService)
    {
        CurrentWeatherService = testService;
    }

    [RelayCommand]
    private async Task RefreshWeather()
    {
        await CurrentWeatherService.RefreshWeather();
    }

}
