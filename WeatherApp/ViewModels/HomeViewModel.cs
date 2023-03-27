using WeatherApp.Domain.Models;
using WeatherApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace WeatherApp.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly IWeatherService _service;

    [ObservableProperty]
    private CurrentWeather currentWeather;

    public ObservableCollection<Hour> Hours { get; set; } = new();

    public ObservableCollection<ForecastDay> Days { get; set; } = new();

    public HomeViewModel(IWeatherService service)
    {
        _service = service;
        Task.Run(GetWeather);
        Task.Run(Get24Hours);
        Task.Run(GetDailyForecast);
    }

    private async Task GetWeather()
    {
        CurrentWeather = await _service.GetCurrentWeatherAsync("Sambir");
    }

    private async Task Get24Hours()
    {
        var list = await _service.Get24HoursWeatherAsync("Sambir");

        foreach (var item in list)
        {
            Hours.Add(item);
        }
    }

    private async Task GetDailyForecast()
    {
        var list = await _service.GetForecastWeather("Sambir");

        foreach (var item in list)
        {
            Days.Add(item);
        }
    }
}
