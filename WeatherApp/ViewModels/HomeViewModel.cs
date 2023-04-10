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
        Task.Run(GetWeatherAndForecastAsync);
    }

    [RelayCommand]
    private async Task RefreshWeather()
    {
        await GetWeatherAsync();
    }

    private async Task GetWeatherAndForecastAsync()
    {
        await GetWeatherAsync();
        await Get24HoursAsync();
        await GetDailyForecastAsync();
    }

    private async Task GetWeatherAsync()
    {
        CurrentWeather = await _service.GetCurrentWeatherAsync("Sambir");
    }

    private async Task Get24HoursAsync()
    {
        var hours = _service.Get24HoursWeatherAsync("Sambir");

        await foreach (var hour in hours)
        {
            Hours.Add(hour);
        }
    }

    private async Task GetDailyForecastAsync()
    {
        var days = _service.GetForecastWeather("Sambir");

        await foreach (var day in days)
        {
            Days.Add(day);
        }
    }
}
